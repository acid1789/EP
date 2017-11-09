using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstnameLastname_CE07
{
    class PartTime : Hourly
    {
        public PartTime(string Name, string Address, decimal PayPerHour, decimal HoursPerWeek)
            :base(Name, Address, PayPerHour, HoursPerWeek)
        {
        }
    }
}
