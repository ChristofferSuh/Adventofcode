using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day_Six
{
    public class Fish
        {
            public int InternalTimer { get; set; }
            public long FishGroup { get; set; }

            public Fish(int days)
            {
                InternalTimer = days;
            }

            public Fish DaySubtraction()
            {
                InternalTimer -= 1;
                if (InternalTimer == -1)
                {
                    InternalTimer = 6;

                    return new Fish(8);
                }
                else return null;

            }
        }
}


