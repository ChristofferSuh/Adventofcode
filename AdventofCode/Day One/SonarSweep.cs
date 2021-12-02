using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day_One
{
    class SonarSweep
    {
        public void PartOne()
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

        public void PartTwo()
        {
            string filepath = @"C:\Users\cs\Desktop\Advent of Code\1\Measurements.txt";
            string[] stringvalues = System.IO.File.ReadAllLines(filepath);
            int[] measurements = new int[stringvalues.Length];
            List<Window> windows = new List<Window>();

            for (int i = 0; i < stringvalues.Length; i++)
            {
                measurements[i] = Convert.ToInt32(stringvalues[i]);
            }


            for (int i = 0; i <= measurements.Length; i++)
            {
                if (i + 2 < measurements.Length)
                {
                    windows.Add(new Window(measurements[i], measurements[i + 1], measurements[i + 2]));
                }
                //if (i+3 > measurements.Length)
                //{
                //    Console.WriteLine("test");
                //}
                else
                {
                    break;

                }
            }

            int previousvalue = 0;
            int currentvalue = 0;
            int counter = 1;
            int increasedcounter = 1;

            foreach (var item in windows)
            {
                currentvalue = item.SumAll();

                if (currentvalue > previousvalue)
                {
                    Console.WriteLine("Group nr: " + counter + " has increased value   ---Current Value: " + currentvalue + "Previous Value: " + previousvalue);
                    increasedcounter++;
                }
                else if (currentvalue < previousvalue)
                {
                    Console.WriteLine("Group nr: " + counter + " has decreased value  ---Current Value: " + currentvalue + "Previous Value: " + previousvalue);

                }
                else
                {
                    Console.WriteLine("Group nr: " + counter + " has the same value  ---Current Value: " + currentvalue + "Previous Value: " + previousvalue);

                }
                previousvalue = currentvalue;
                counter++;

            }

            Console.WriteLine("Total increases: " + increasedcounter);
            Console.ReadLine();
        }
    }

     class Window
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public Window(int inA, int inB, int inC)
        {
            a = inA;
            b = inB;
            c = inC;
        }

        public int SumAll()
        {
            return a + b + c;
        }

    }



}


