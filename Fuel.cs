using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ascii_race
{
    internal class Fuel
    {
        private const int MAX = 1000;
        private const int BAR_SIZE = 10;
        private int progress = MAX;

        public bool CheckFuel()
        {
            progress--;
            return progress > 0;
        }

        public string Bar()
        {
            var prop = progress * BAR_SIZE / MAX;
            var full = new StringBuilder(prop)
                .Insert(0, "▓", prop)
                .ToString();
            var empty = new StringBuilder(BAR_SIZE - prop)
                .Insert(0, "░", BAR_SIZE - prop)
                .ToString();
            return full + empty;
        }
    }
}
