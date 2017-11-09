using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstnameLastname_CE07
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            
            while (true)
            {
                Console.WriteLine("1) Add Employee");
                Console.WriteLine("2) Remove Employee");
                Console.WriteLine("3) Display Payroll");
                Console.WriteLine("4) Exit");
                Console.Write("Choice: ");

                string il = Console.ReadLine();
                string inputLine = il.ToLower();
                if (inputLine == "1" || inputLine == "add employee")
                    AddEmployee(employees);
                else if (inputLine == "2" || inputLine == "remove employee")
                    RemoveEmployee(employees);
                else if (inputLine == "3" || inputLine == "display payroll")
                    DisplayPayroll(employees);
                else if (inputLine == "4" || inputLine == "exit")
                {
                    DoExit();
                    return;
                }
                else
                    Console.WriteLine("Invalid selection: {0}", il);
                
            }
        }

        static void AddEmployee(List<Employee> employees)
        {
            while (true)
            {
                Console.WriteLine("== Add Employee == ");
                Console.WriteLine("1) Full Time");
                Console.WriteLine("2) Part Time");
                Console.WriteLine("3) Contractor");
                Console.WriteLine("4) Salaried");
                Console.WriteLine("5) Manager");
                Console.WriteLine("6) Previous Menu");
                Console.Write("Choice: ");

                string il = Console.ReadLine();
                string inputLine = il.ToLower();
                Employee e = null;

                Console.WriteLine("");
                if (inputLine == "1" || inputLine == "full time")
                {
                    string name = GetName();
                    string addr = GetAddress();
                    decimal pph = GetPayPerHour();
                    e = new FullTime(name, addr, pph);
                }
                else if (inputLine == "2" || inputLine == "part time")
                {
                    string name = GetName();
                    string addr = GetAddress();
                    decimal pph = GetPayPerHour();
                    decimal hpw = GetHoursPerWeek();
                    e = new PartTime(name, addr, pph, hpw);
                }
                else if (inputLine == "3" || inputLine == "contractor")
                {
                    string name = GetName();
                    string addr = GetAddress();
                    decimal pph = GetPayPerHour();
                    decimal hpw = GetHoursPerWeek();
                    decimal nbb = GetNoBenefitBonus();
                    e = new Contractor(name, addr, pph, hpw, nbb);
                }
                else if (inputLine == "4" || inputLine == "salaried")
                {
                    string name = GetName();
                    string addr = GetAddress();
                    decimal salary = GetSalary();
                    e = new Salaried(name, addr, salary);
                }
                else if (inputLine == "5" || inputLine == "manager")
                {
                    string name = GetName();
                    string addr = GetAddress();
                    decimal salary = GetSalary();
                    decimal bonus = GetBonus();
                    e = new Manager(name, addr, salary, bonus);
                }
                else if (inputLine == "6" || inputLine == "previous menu")
                    return;
                else
                    Console.WriteLine("Invalid Selection: " + il);

                if (e != null)
                {
                    employees.Add(e);
                    employees.Sort();
                }
            }
        }

        static void RemoveEmployee(List<Employee> employees)
        {
            Console.WriteLine("== Remove Employee == ");
        }

        static void DisplayPayroll(List<Employee> employees)
        {
            Console.Clear();
            Console.WriteLine("== Display Payroll == ");
            foreach (Employee e in employees)
            {
                Console.WriteLine("{0}\t{1}\t{2}", e.name, e.address, e.CalcuatePay());
            }
        }

        static void DoExit()
        {
            Console.WriteLine("Exiting...");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static string GetName()
        {
            Console.Write("Employee Name: ");
            string line = Console.ReadLine();
            return line;
        }

        static string GetAddress()
        {
            Console.Write("Employee Address: ");
            string line = Console.ReadLine();
            return line;
        }

        static decimal GetDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string line = Console.ReadLine();
                try
                {
                    decimal d = decimal.Parse(line);
                    return d;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid decimal input: " + line);
                }
            }

        }

        static decimal GetPayPerHour()
        {
            return GetDecimal("Pay per hour: ");
        }

        static decimal GetHoursPerWeek()
        {
            return GetDecimal("Hours per week: ");
        }

        static decimal GetNoBenefitBonus()
        {
            return GetDecimal("No benefit bonus: ");
        }

        static decimal GetSalary()
        {
            return GetDecimal("Salary: ");
        }

        static decimal GetBonus()
        {
            return GetDecimal("Bonus: ");
        }
    }
}
