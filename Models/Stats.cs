using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public struct Stats
    {
        public string Name { get; set; }
        public int Period { get; set; }
        public DateTime DateNTime { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public int Volume { get; set; }

        public override string ToString()
        {
            return string.Concat(Name + " " + Period + " " + DateNTime + " " + Open + " " + High + " " + Low + " " + Close);
        }
    }
}
