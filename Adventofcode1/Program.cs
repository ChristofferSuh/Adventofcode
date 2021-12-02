using System;
using System.IO;

namespace Adventofcode1
{
    class Program
    {
        static void Main(string[] args)
        {
            int compareprevious = 0;
            int comparecurrent = 0;
            int increasecounts = 0;
            string filepath = @"C:\Users\cs\Desktop\Advent of Code\1\Measurements.txt";
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    while (!sr.EndOfStream)
                    {
                        comparecurrent = Convert.ToInt32(sr.ReadLine()); 
                        if (comparecurrent > compareprevious)
                        {
                            Console.WriteLine(comparecurrent.ToString() + " Increased Value");
                            increasecounts++;
                        }
                        else if (comparecurrent < compareprevious)
                        {
                            Console.WriteLine(comparecurrent.ToString() + " Decreased Value");
                        }
                        else if (comparecurrent == compareprevious)
                        {
                            Console.WriteLine(comparecurrent.ToString() + "Value is the same");
                        }

                        compareprevious = comparecurrent;
                       
                    }
                    Console.WriteLine("Number of increments: " + increasecounts.ToString());
                    Console.ReadLine();
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
