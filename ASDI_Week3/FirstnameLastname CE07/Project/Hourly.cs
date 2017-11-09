using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstnameLastname_CE07
{
    class Hourly : Employee
    {
        decimal payPerHour;
        decimal hoursPerWeek;

        public Hourly(string Name, string Address, decimal PayPerHour, decimal HoursPerWeek)
            : base(Name, Address)
        {
            payPerHour = PayPerHour;
            hoursPerWeek = HoursPerWeek;
        }

        public override decimal CalcuatePay()
        {
            return payPerHour * hoursPerWeek * 52;
        }
    }
}
