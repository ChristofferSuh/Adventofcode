using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day_Seven
{
   public class The_Treachery_of_Whales
    {
        public List<int> Input { get; set; }
        string filepath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Input\7\7.txt");

        public The_Treachery_of_Whales()
        {
           Input = File.ReadLines(filepath)
          .SelectMany(x => x.Split(','))
          .Select(int.Parse)
          .ToList();
        }

     public void PartOne()
        {
            Input.Sort();
            int a = Input[Input.Count() / 2];
            int fuelcount = 0;

            foreach (var Crab in Input)
            {
                int diff = Math.Abs(Crab - a);
                fuelcount += diff;
            }
            Console.WriteLine("test");
        }



        public void PartTwo()
        {

            int avg = (int)Input.Average();//(int)Math.Round(Queryable.Average(Input.AsQueryable())) -1;
            int fuelcount = 0;
            foreach (var Crab in Input)
            {
                int diff = Math.Abs(Crab - avg);
                for (int i = 1; i <= diff; i++)
                {
                    fuelcount += i;
                }
            }
            Console.WriteLine("test");
        }
    }


}
