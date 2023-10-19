using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ascii_race
{
    internal class Road
    {
        public int CurrentPosition { get; set; } = 0;

        public Road() {
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 22;  i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("!                              !");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void Forward()
        {
            CurrentPosition++;
        }
    }
}
