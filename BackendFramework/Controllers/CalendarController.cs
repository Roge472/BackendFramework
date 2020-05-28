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
    public class CalendarController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CalendarController> _logger;

        public CalendarController(ILogger<CalendarController> logger)
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
    }
}
