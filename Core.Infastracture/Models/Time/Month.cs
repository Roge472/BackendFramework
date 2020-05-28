using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infastracture.Models.Time
{
    public class Month:BaseModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Day> Days { get; set; }

    }
}
