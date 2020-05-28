using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Infastracture.Models
{
    public class TimeEntry:BaseModel
    {
        public int? ClientID { get; set; }
        public Client Client { get; set; }
        public int? TimeKeeperID { get; set; }
        public TimeKeeper TimeKeeper { get; set; }

        public string WorkTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeType TimeType { get; set; }

        public string Note { get; set; }
        public string InternalComment { get; set; }
        public string Office { get; set; }
        public string Language { get; set; }
    }
}
