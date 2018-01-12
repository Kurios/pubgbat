using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerRole1
{
    public class FlagString
    {
        public string String { get; set; }
        public uint Flag { get; set; }

        public static uint ALL = 0xFFFF_FFFF;
        public static uint WEAPONS = 0x0FFF_FFFF;

        public FlagString(string s, uint flag)
        {
            String = s;
            Flag = flag;
        }
    }
}
