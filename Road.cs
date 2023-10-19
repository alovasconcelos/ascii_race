using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ascii_race
{
    internal class Road
    {
        public float CurrentPosition { get; set; } = 0f;

        public Road() {
        }

        public void Draw()
        {
            for (int i = 0; i < 22;  i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|                              |");
            }

        }
        public void Forward()
        {
            CurrentPosition += 0.005f;
        }
    }
}
