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
    public class ClientController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CalendarController> _logger;

        public ClientController(ILogger<CalendarController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Client>> GetClients(int timeKeeperID)
        {
            using (var context = new ApplicationContext())
            {
                return await context.Clients.Where(c => c.TimeKeeper.ID == timeKeeperID).ToListAsync();
            }
        }
    }
}
