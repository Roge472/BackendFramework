using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infastracture.Models
{
    public class TimeKeeper : Person
    {
        public List<TimeEntry> TimeEntries { get; set; }
        public List<Client> Clients { get; set; }
    }
}
