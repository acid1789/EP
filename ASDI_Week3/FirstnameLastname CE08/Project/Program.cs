using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FirstnameLastname_CE08
{
    class Program
    {
        static string[] ReadAllLines_StreamReaderIsHorribleAndShouldNotBeUsed(string fileName)
        {
            List<string> lines = new List<string>();
            StreamReader sr = new StreamReader(fileName);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
            }
            sr.Close();
            return lines.ToArray();
        }

        static void WriteAllText_StreamWriterIsHorribleAndSHouldNotBeUsed(string fileName, string output)
        {
            StreamWriter sw = new StreamWriter(fileName, false);
            sw.WriteLine(output);
            sw.Close();
        }

        static void Main(string[] args)
        {
            string[] dataFields = File.ReadAllLines("DataFieldsLayout.txt");


            int index = -1;
            while (true)
            {
                Console.WriteLine("Which data file do you want to transform? (1, 2, 3)");
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.WriteLine("");
                index = cki.KeyChar - '0';
                if (index >= 1 && index <= 3)
                    break;
                Console.WriteLine("Invalid input");
            }

            string dataFileName = string.Format("DataFile{0}.txt", index);
            Console.WriteLine("Processing file {0}...", dataFileName);
            //string[] dataFileLines = File.ReadAllLines(dataFileName);
            string[] dataFileLines = ReadAllLines_StreamReaderIsHorribleAndShouldNotBeUsed(dataFileName);
            string json = "[";
            int cap = dataFileLines.Length - 1;
            for (int i = 1; i < cap; i++)
            {
                json += "{";
                string[] elements = dataFileLines[i].Split('|');
                for (int j = 0; j < dataFields.Length; j++)
                {
                    json += string.Format("\"{0}\":\"{1}\"", dataFields[j], elements[j]);
                    if (j < dataFields.Length - 1)
                        json += ",";
                }
                json += "}";

                if (i < cap - 1)
                    json += ",";                    
            }
            json += "]";

            //File.WriteAllText("output.json", json);
            WriteAllText_StreamWriterIsHorribleAndSHouldNotBeUsed("output.json", json);
        }
    }
}
