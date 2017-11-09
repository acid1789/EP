using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstnameLastname_CE07
{
    class Manager : Salaried
    {
        decimal bonus;

        public Manager(string Name, string Address, decimal Salary, decimal Bonus)
            : base(Name, Address, Salary)
        {
            bonus = Bonus;
        }

        public override decimal CalcuatePay()
        {
            decimal basePay = base.CalcuatePay();
            return basePay + bonus;
        }
    }
}
