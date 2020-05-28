using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infastracture.Models
{
    public class User: Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
