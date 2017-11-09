using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstnameLastname_CE07
{
    class FullTime : Hourly
    {
        public FullTime(string Name, string Address, decimal PayPerHour)
            : base(Name, Address, PayPerHour, 40)
        {
        }
    }
}
