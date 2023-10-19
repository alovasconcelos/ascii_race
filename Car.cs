using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ascii_race
{
    internal class Car
    {
        private string[] body = { "■▄■", "▀▀▀" };
        private int carCol = 15;
        const int carRow = 20;

        public Car()
        {
        }

        public void Draw()
        {
            for (int i = 0; i < body.Length; i++)
            {
                Console.SetCursorPosition(carCol, carRow + i);
                Console.Write(body[i]);                
            }
        }

        public void Erase()
        {
            for (int i = 0; i < body.Length; i++)
            {
                Console.SetCursorPosition(carCol, carRow + i);
                Console.Write("   ");
            }
        }

        public void MoveLeft()
        {
            if (carCol > 2)
            {
                Erase();
                carCol--;
            }
        }

        public void MoveRight()
        {
            if (carCol < 27)
            {
                Erase();
                carCol++;
            }
        }
       
    }
}
