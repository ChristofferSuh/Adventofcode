using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day_Three
{
    class BinaryDiagnostic
    {
        string filepath = @"C:\Users\cs\Desktop\Advent of Code\3\Day3.txt";
        int[] gamma = new int[12];
        int[] epsilon = new int[12];

        public void PartOne()
        {
            StreamReader reader = new StreamReader(new MemoryStream(File.ReadAllBytes(filepath)));
            char[,] BinaryInput = new char[1000,12 ];        
            
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    for (long i = 0; i < 1000; i++)
                    {
                        char[] test = reader.ReadLine().ToCharArray();
                        for (int j = 0; j < test.Length; j++)
                        {

                            BinaryInput.SetValue(test[j], i, j);
                        }
                    }
                }
            }

            for (int i = 0; i < BinaryInput.GetLength(1); i++)
            {
                int count1 = 0;
                int count0 = 0;
                    
                for (int j = 0; j < BinaryInput.GetLength(0); j++)
                {
                    var value = BinaryInput.GetValue(j, i);
                    if (value.Equals('1'))
                    {
                        count1++;
                    }
                    if (value.Equals('0'))
                    {
                        count0++;
                    }
                }

                if (count1 > count0)
                {
                    gamma[i] = 1;
                    epsilon[i] = 0;
                }
                else
                {
                    gamma[i] = 0;
                    epsilon[i] = 1;
                }
            }
            long a = Convert.ToInt64(String.Join("", gamma),2);
            long b = Convert.ToInt64(String.Join("", epsilon),2);
            long c = a * b;
        }
              

        public void PartTwo()
        {
            int counter = 0;
            int OxygenFilter = 0;
            int ScrubberFilter = 0;

            List<string> Oxygen = new List<string>(File.ReadAllLines(filepath));
            List<string> Scrubber = new List<string>(Oxygen);
            int OxygenCount1 = 0;
            int OxygenCount0 = 0;
            int ScrubberCount1 = 0;
            int ScrubberCount0 = 0;

            while (counter < 12)
            {
                if (Oxygen.Count() > 1)
                {
                    OxygenCount1 = Oxygen.Where(x => x.Substring(counter, 1).Equals("1")).Count();
                    OxygenCount0 = Oxygen.Where(x => x.Substring(counter, 1).Equals("0")).Count();

                    if (OxygenCount1 >= OxygenCount0)
                    {
                        OxygenFilter = 1;

                    }
                    else
                    {
                        OxygenFilter = 0;
                    }
                    Oxygen = Oxygen.Where(x => x.Substring(counter, 1).Equals(OxygenFilter.ToString())).ToList();
                }               

                if (Scrubber.Count > 1)
                {
                    ScrubberCount1 = Scrubber.Where(x => x.Substring(counter, 1).Equals("1")).Count();
                    ScrubberCount0 = Scrubber.Where(x => x.Substring(counter, 1).Equals("0")).Count();
                    if (ScrubberCount1 >= ScrubberCount0)
                    {
                        ScrubberFilter = 0;

                    }
                    else
                    {
                        ScrubberFilter = 1;
                    }
                    Scrubber = Scrubber.Where(x => x.Substring(counter, 1).Equals(ScrubberFilter.ToString())).ToList();
                }     
                counter++;
                if (Oxygen.Count() == 1 && Scrubber.Count() == 1)
                {
                    long a = Convert.ToInt64(Oxygen.First(), 2);
                    long b = Convert.ToInt64(Scrubber.First(), 2);
                    long c = a * b;
                }
            }          
        }
    }
}
