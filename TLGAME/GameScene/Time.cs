using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLGAME
{
    class Time
    {
        Stopwatch watch = new Stopwatch();
        ushort milliseconds = 0;
        double delta = 0;
        public Time()
        {

        }
        public double Delta { get => delta; }
        public void DeltaTime()
        {
            milliseconds = (ushort)watch.ElapsedMilliseconds;
            watch.Restart();
            delta = milliseconds / 14;
        }
    }
}
