using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day_Eight
{
    class Seven_Segment_Search
    {
        public List<string> Input { get; set; }
        public Dictionary<string, string> PatternValue { get; set; }
        string filepath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Input\8\8.txt");

        public Seven_Segment_Search()
        {
            Input = File.ReadLines(filepath).ToList()
           .SelectMany(x => x.Split('\n'))
           .ToList();
            PatternValue = new Dictionary<string, string>();
        }

        public void PartOne()
        {
            int[] CountSegmentValues = new int[9];

            foreach (var item in Input)
            {
                List<string> PatternValueSplit = new List<string>();
                PatternValueSplit.AddRange(item.Split('|'));
                PatternValue.Add(PatternValueSplit[0], PatternValueSplit[1]);

            }

            foreach (var item in PatternValue.Values)
            {
                List<string> Values = new List<string>();
                Values.AddRange(item.Split(' ', StringSplitOptions.RemoveEmptyEntries));

                foreach (var value in Values)
                {
                    switch (value.Length)
                    {
                        case 1:
                            CountSegmentValues[value.Length] += 1;
                            break;
                        case 2:
                            CountSegmentValues[value.Length] += 1;
                            break;
                        case 3:
                            CountSegmentValues[value.Length] += 1;
                            break;
                        case 4:
                            CountSegmentValues[value.Length] += 1;
                            break;
                        case 5:
                            CountSegmentValues[value.Length] += 1;
                            break;
                        case 6:
                            CountSegmentValues[value.Length] += 1;
                            break;
                        case 7:
                            CountSegmentValues[value.Length] += 1;
                            break;
                        case 8:
                            CountSegmentValues[value.Length] += 1;
                            break;


                        default:
                            break;
                    }

                }

            }
            Console.WriteLine("ResultBreakPoint");
        }

        public void PartTwo()
        {
            int result = 0;
            List<string> StringValues = new List<string>();
            List<string[]> segmentparses = new List<string[]>();
           // string[] segmentgroup = new string[10] { "", "", "", "", "", "", "", "", "", "" };
            foreach (var item in Input)
            {
                List<string> PatternValueSplit = new List<string>();
                PatternValueSplit.AddRange(item.Split('|'));
                PatternValue.Add(PatternValueSplit[0], PatternValueSplit[1]);




            }

            foreach (var segment in PatternValue.Keys)
            {
                string[] segmentgroup = new string[10] { "", "", "", "", "", "", "", "", "", "" };

                int counter = 0;
                while (/*segmentgroup.Contains("") &&*/ counter <=  25)
                {
                    foreach (var key in segment.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (key.Length == 2)
                        {
                            segmentgroup[1] = key;
                        }
                        if (key.Length == 3)
                        {
                            segmentgroup[7] = key;
                        }
                        if (key.Length == 4)
                        {
                            segmentgroup[4] = key;
                        }
                        if (key.Length == 8)
                        {
                            segmentgroup[8] = key;
                        }
                        if (key.Length == 6)
                        {
                            if (segmentgroup[7].All(c => key.Contains(c)) && segmentgroup[9].Any(c => key.Contains(c) == false))
                            {
                                segmentgroup[0] = key;
                            }
                            if (/*!(key.Contains(segmentgroup[2]) &&*/segmentgroup[4].All(c => key.Contains(c)))
                            {
                                segmentgroup[9] = key;
                            }
                            if (segmentgroup[0].Any(c => key.Contains(c) == false) && segmentgroup[9].Any(c => key.Contains(c) == false))
                            {
                                segmentgroup[6] = key;
                            }
                        }
                        if (key.Length == 5)
                        {
                            if (key.All(c => segmentgroup[6].Contains(c)))
                            {
                                segmentgroup[5] = key;
                            }

                            if (segmentgroup[3].Any(c => key.Contains(c) == false) && segmentgroup[5].Any(c => key.Contains(c) == false))
                            {
                                segmentgroup[2] = key;
                            }

                            if (key.All(c => segmentgroup[9].Contains(c)) && segmentgroup[7].All(c => key.Contains(c)))
                            {
                                segmentgroup[3] = key;
                            }
                        }
                        if (key.Length == 7)
                        {
                            segmentgroup[8] = key;
                        }

                    }
                    counter++;
                }
                segmentparses.Add(segmentgroup);
                PatternValue.TryGetValue(segment, out string value);
               result += returnSegmentValue(segmentgroup, value);
              
     
            }

            Console.WriteLine("ttest");

        }

        public int returnSegmentValue(string[] segmentparse, string segmentkey)
        {
            string result = "";
            foreach (var item in segmentkey.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
              string a = String.Concat(item.OrderBy(c => c));
                for (int i = 0; i < segmentparse.Length; i++)
                {
                    string b = String.Concat(segmentparse[i].OrderBy(c => c));
                    if (a == b)
                    {
                        result += i;
                    }
                }
            }
            Console.WriteLine(result);
            return int.Parse(result);

        }
    }
}
