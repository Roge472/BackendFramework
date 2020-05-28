using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DB;
using Core.Infastracture.Models;
using Core.Infastracture.Models.Time;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BackendFramework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeEntryController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CalendarController> _logger;

        public TimeEntryController(ILogger<CalendarController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<TimeEntry>> GetMonthData(int timeKeeperID, DateTime startDate, DateTime endDate)
        {
            using (var context = new ApplicationContext())
            {
                var timeKeeper = await context.TimeKeepers.Include(t => t.TimeEntries).ThenInclude(t => t.Client).SingleOrDefaultAsync(t => t.ID == timeKeeperID);
                foreach (var timeEntry in timeKeeper.TimeEntries)
                {
                    timeEntry.TimeKeeper = null;
                    if (timeEntry.Client != null)
                    {
                        timeEntry.Client.TimeEntries = null;
                        timeEntry.Client.TimeKeeper = null;
                    }
                }
                return timeKeeper.TimeEntries;
            }
        }

        [HttpDelete]
        public async Task DeleteTimeEntry(int timeEntryId)
        {
            using (var context = new ApplicationContext())
            {
                var a = await context.TimeEntries.SingleOrDefaultAsync(t => t.ID == timeEntryId);
                context.TimeEntries.Remove(a);
                await context.SaveChangesAsync();
            }
        }

        [HttpPost]
        public async Task<int> CreateTimeEntry([FromBody]TimeEntry timeEntry)
        {
            using (var context = new ApplicationContext())
            {
                if (timeEntry.Client != null)
                {
                    timeEntry.Client = context.Clients.SingleOrDefault(c => c.ID == timeEntry.Client.ID);
                }
                this.timeToMoscowTime(timeEntry);
                timeEntry.TimeKeeper = context.TimeKeepers.SingleOrDefault(t => t.ID == timeEntry.TimeKeeper.ID);
                context.TimeEntries.Add(timeEntry);
                await context.SaveChangesAsync();
            }
            return timeEntry.ID;
        }


        [HttpPut]
        public async Task UpdateTimeEntry([FromBody]TimeEntry timeEntry)
        {
            using (var context = new ApplicationContext())
            {
                var t = await context.TimeEntries.SingleOrDefaultAsync(t => t.ID == timeEntry.ID);
                mergeTimeEntry(t, timeEntry);
                this.timeToMoscowTime(t);
                context.TimeEntries.Update(t);
                await context.SaveChangesAsync();
            }
        }

        private void mergeTimeEntry(TimeEntry source, TimeEntry merge)
        {
            if (merge.Client != null)
            {
                source.ClientID = merge.Client.ID;
            }
            source.TimeKeeperID = merge.TimeKeeper.ID;
            source.EndTime = merge.EndTime;
            source.StartTime = merge.StartTime;
            source.WorkTime = merge.WorkTime;
            source.Note = merge.Note;
        }

        private void timeToMoscowTime(TimeEntry time)
        {
            time.StartTime = time.StartTime.AddHours(3);
            time.EndTime = time.EndTime.AddHours(3);
        }
    }
}
