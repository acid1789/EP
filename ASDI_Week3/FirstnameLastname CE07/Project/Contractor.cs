using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstnameLastname_CE07
{
    class Contractor : Hourly
    {
        decimal noBenefitsBonus;

        public Contractor(string Name, string Address, decimal PayPerHour, decimal HoursPerWeek, decimal NoBenefitBonus)
            : base(Name, Address, PayPerHour, HoursPerWeek)
        {
            noBenefitsBonus = NoBenefitBonus;
        }

        public override decimal CalcuatePay()
        {
            decimal basePay = base.CalcuatePay();

            return basePay + (basePay * noBenefitsBonus);
        }
    }
}
