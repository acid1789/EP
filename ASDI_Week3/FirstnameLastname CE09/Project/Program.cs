using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.IO;

namespace FirstnameLastname_CE09
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the dvd library
            DVD[] library = LoadDVDsFromDatabase();
            if (library == null)
                return;

            // Setup cart & inventory
            List<DVD> cart = new List<DVD>();
            List<DVD> inventory = new List<DVD>(library);

            // Do the menu loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== DVD Emporium ==");
                Console.WriteLine("1) View Inventory");
                Console.WriteLine("2) View Shopping Cart");
                Console.WriteLine("3) Add DVD to Cart");
                Console.WriteLine("4) Remove DVD from Cart");
                Console.WriteLine("5) Exit");
                Console.Write("What would you like to do? ");
                string il = Console.ReadLine();
                string inputLine = il.ToString();

                if (inputLine == "1" || inputLine == "view inventory")
                    DisplayInventory(inventory, "DVD Emporium Inventory");
                else if (inputLine == "2" || inputLine == "view shopping cart")
                    DisplayInventory(cart, "Shopping Cart Contents");
                else if (inputLine == "3" || inputLine == "add dvd to cart")
                    MoveDVD(inventory, cart, "Current Inventory");
                else if (inputLine == "4" || inputLine == "remove dvd from cart")
                    MoveDVD(cart, inventory, "Current Cart");
                else if (inputLine == "5" || inputLine == "exit")
                    return;
                else
                {
                    Console.WriteLine("Invalid input: " + il);
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                }
            }

        }

        static void DisplayInventory(List<DVD> dvds, string title)
        {
            Console.Clear();
            Console.WriteLine("== {0} ==", title);
            foreach (DVD dvd in dvds)
            {
                Console.WriteLine(dvd.ToString());
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();            
        }

        static void MoveDVD(List<DVD> from, List<DVD> to, string title)
        {
            Console.Clear();
            Console.WriteLine("== {0} ==", title);
            int index = 1;
            foreach (DVD dvd in from)
            {
                Console.WriteLine("{0}) {1}", index++, dvd.ToString());
            }
            Console.WriteLine("{0}) Cancel", index++);
            Console.Write("Select an Option: ");
            string input = Console.ReadLine();
            index = -1;
            if (!int.TryParse(input, out index) || index < 1 || index > (from.Count + 1))
            {
                Console.WriteLine("Invalid selection\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            index--;
            if (index == from.Count)
                return;
        
            DVD checkout = from[index];
            from.RemoveAt(index);
            to.Add(checkout);
        }

        static DVD[] LoadDVDsFromDatabase()
        {
            int port = 8889;
            string connectFile = File.Exists("C:/VFW/connect.txt") ? "C:/VFW/connect.txt" : "C:/VFW/connection.txt";
            string[] ipLines = File.ReadAllLines(connectFile);
            if (ipLines.Length > 1)
                int.TryParse(ipLines[1], out port);

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = string.Format("Server={0};uid=dbsAdmin;pwd=password;database=ExampleDB;port={1}", ipLines[0], port);

            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect to db");
                Console.WriteLine(ex.ToString());
                return null;
            }

            List<DVD> dvds = new List<DVD>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM dvd", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DVD dvd = new DVD() { Title = (string)reader[1], Price = (decimal)reader[2], Rating = (float)reader[3] };
                dvds.Add(dvd);
            }
            reader.Close();

            con.Close();

            return dvds.ToArray();
        }
    }
}
