using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstnameLastname_CE07
{
    abstract class Employee : IComparable
    {
        public string name;
        public string address;

        public Employee(string Name, string Address)
        {
            name = Name;
            address = Address;
        }

        public int CompareTo(object obj)
        {
            Employee other = (Employee)obj;
            if (other == null)
                return -1;

            return name.CompareTo(other.name);
        }

        public abstract decimal CalcuatePay();
    }
}
