using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infastracture.Models.Time
{
    public class Day : BaseModel
    {
        public DateTime Date { get; set; }
        List<TimeEntry> TimeEntries { get; set; }
    }
}
