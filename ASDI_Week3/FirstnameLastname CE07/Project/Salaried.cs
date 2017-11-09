using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstnameLastname_CE07
{
    class Salaried : Employee
    {
        decimal salary;

        public Salaried(string Name, string Address, decimal Salary)
            : base(Name, Address)
        {
            salary = Salary;
        }

        public override decimal CalcuatePay()
        {
            return salary;
        }
    }
}
