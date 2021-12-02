using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day_Two
{
   public class Dive
    {
        public string[] StringValues { get; set; }
        public int TotalDepth { get; set; }
        public int TotalHorisontal { get; set; }
        public Dive()
        {
            TotalDepth = 0;
            TotalHorisontal = 0;
            StringValues = new Helper("C:\\Users\\cs\\Desktop\\Advent of Code\\2\\Day2.txt").FileToArray();
        }

        public void PartOne()
        {
            foreach (var item in StringValues)
            {
                string direction = item.Substring(0, item.Length - 2);
                int directionalunits = Convert.ToInt32(item.Substring(item.Length - 1, 1));

                if (direction == "forward")
                {
                    TotalHorisontal += directionalunits;
                }

                if (direction == "up")
                {
                    TotalDepth -= directionalunits;
                }

                if (direction == "down")
                {
                    TotalDepth += directionalunits;
                }

            }
            Console.WriteLine(TotalDepth * TotalHorisontal);
            Console.ReadLine();
        }

        public void PartTwo()
        {
            int Aim = 0;
            foreach (var item in StringValues)
            {
                string direction = item.Substring(0, item.Length - 2);
                int directionalunits = Convert.ToInt32(item.Substring(item.Length - 1, 1));

                if (direction == "forward")
                {
                    TotalHorisontal += directionalunits;
                    if (Aim != 0)
                    {
                        TotalDepth += Aim * directionalunits;
                    }
                }

                if (direction == "up")
                {
                    // TotalDepth -= directionalunits;
                    Aim -= directionalunits;
                }

                if (direction == "down")
                {
                    //TotalDepth += directionalunits;
                    Aim += directionalunits;
                }

            }
            Console.WriteLine(TotalDepth * TotalHorisontal);
            Console.ReadLine();
        }

    }
}
