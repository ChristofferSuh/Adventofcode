using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day_Five
{
    class HydroThermalVenture
    {
        string filepath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Input\5\test.txt");
        string[] input;
        public List<Coordination> Coordinations { get; set; }
        public Dictionary<string,int> OverlapPoints { get; set; }




        public HydroThermalVenture()
        {
            Coordinations = new List<Coordination>();
            OverlapPoints = new Dictionary<string, int>();
            input = File.ReadAllLines(filepath);
        }
        public void PartOne()
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i].Replace(',', '.');
                var test = input[i].Split("->");
                var xy1 = test[0].Split(',');
                var xy2 = test[1].Split(',');
                Coordinations.Add(new Coordination(xy1, xy2));
            }

            foreach (var item in Coordinations)
            {
                foreach (var span in item.Span)
                {
                    if (!OverlapPoints.ContainsKey(span))
                    {
                        OverlapPoints.Add(span, 1);
                    }
                    else
                    {
                        OverlapPoints.TryGetValue(span, out int OldValue);
                        OverlapPoints[span] += 1;
                    }
                }
            }
            int result = OverlapPoints.Values.Where(x => x >= 2).Count();
        }



    }

    class Coordination
    {
        public List<string> Span { get; set; }
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public Coordination(string[] xy1in, string[] xy2in)
        {
            Span = new List<string>();

            x1 = int.Parse(xy1in[0]);
            y1 = int.Parse(xy1in[1]);
            x2 = int.Parse(xy2in[0]);
            y2 = int.Parse(xy2in[1]);
            CalculateSpan();

        }

        public void CalculateSpan()
        {
            int max = 0;
            int counter = 0;

            

            if (x1 == x2)
            {
                if (y1 >= y2)
                {
                    max = y1;
                    counter = y2;
                }
                else
                {
                    max = y2;
                    counter = y1;
                }
                while (counter <= max)
                {
                    Span.Add(x1.ToString()+","+counter.ToString());
                    counter++;
                }
            }
           else if (y1 == y2)
            {
                if (x1 >= x2)
                {
                    max = x1;
                    counter = x2;
                }
                else
                {
                    max = x2;
                    counter = x1;
                }
                while (counter <= max)
                {
                    Span.Add(counter.ToString()+","+y1.ToString());
                    counter++;
                }
            }
            else //This needs to be commented out for Part One
            {
                      
                int xmax = Math.Max(x1, x2);
                int ymax = Math.Max(y1, y2);
                int xmin = Math.Min(x1, x2);
                int ymin = Math.Min(y1, y2);
                int abs = xmax - xmin;
                for (int i = 0; i <= abs; i++)
                {
                    Span.Add(x1.ToString() + "," + y1.ToString());
                    if (Math.Max(x1, x2) == x1)
                    {
                        x1--;
                    }
                    else
                    {
                        x1++;
                    }
                    if (Math.Max(y1, y2) == y1)
                    {
                        y1--;
                    }
                    else
                    {
                        y1++;
                    }
                    
            

                }

            }



        }
    }

}
