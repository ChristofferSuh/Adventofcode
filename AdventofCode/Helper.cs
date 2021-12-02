using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode
{
   public class Helper
    {
        public string filepath { get; set; }
        public Helper(string filepathin)
        {
            filepath = filepathin;
        }

        public string[] FileToArray()
        {
            string[] stringvalues = System.IO.File.ReadAllLines(filepath);
            return stringvalues;

        }
    }
}
