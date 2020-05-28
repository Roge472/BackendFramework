using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infastracture.Models
{
    public abstract class Person: BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
