using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day_Six
{
    class LanternFish
    {
        string filepath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Input\6\6.txt");
        string[] input;
        public List<Fish> SchoolOfFish { get; set; }
        public Dictionary<int, int> FishGroup { get; set; }

        public LanternFish()
        {
            FishGroup = new Dictionary<int, int>();
            input = File.ReadAllLines(filepath);
            SchoolOfFish = new List<Fish>();
        }

        public void PartOne()
        {
            int count = 1;
            string[] splitinput;
            for (int i = 0; i < input.Length; i++)
            {
                splitinput = input[i].Split(',');
                for (int j = 0; j < splitinput.Length; j++)
                {
                    SchoolOfFish.Add(new Fish(int.Parse(splitinput[j])));
                }
            }
            while (count <= 80)
            {
                foreach (var fish in SchoolOfFish.ToList())
                {
                    object a = fish.DaySubtraction();
                    if (a == null)
                    {
                        continue;
                    }
                    else
                    {
                        SchoolOfFish.Add(a as Fish);
                    }

                }
                Console.WriteLine(SchoolOfFish.Count());
                count++;
            }


        }

        public void PartTwo()
        {
            List<int> input = File.ReadLines(filepath)
                .SelectMany(x => x.Split(','))
                .Select(int.Parse)
                .ToList();

            long[] fishes = new long[9];

            for (int i = 0; i < fishes.Length; i++)
            {
                fishes[i] = input.Where(x => x.Equals(i)).Count();
            }

            for(int i = 0; i <256; i++)
            {
                var temp = fishes[0];
                for (var j = 0; j < fishes.Length - 1; j++)
                {
                    fishes[j] = fishes[j + 1];
                }
                fishes[fishes.Length - 1] = temp;
                fishes[6] += fishes[8];
            }            
            long sum = fishes.ToList().Select(x => x).Sum();

            Console.WriteLine("Test");
        }
    }
}
