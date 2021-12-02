using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode2
{
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
