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
    public class TimeKeeperController : ControllerBase
    {
        private readonly ILogger<CalendarController> _logger;

        public TimeKeeperController(ILogger<CalendarController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<TimeKeeper>> GetTimeKeepers()
        {
            using (var context = new ApplicationContext())
            {
                return await context.TimeKeepers.ToListAsync();
            }
        }
    }
}
