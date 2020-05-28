using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infastracture.Models
{
    public class Client: Person
    {
        public TimeKeeper TimeKeeper { get; set; }
        public List<TimeEntry> TimeEntries { get; set; }

        public int Age { get; set; }
        public string City { get; set; }
    }
}
