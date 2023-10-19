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
        private int carRow = 20;
        private bool opponent;

        public Car(bool opponent = false)
        {
            this.opponent = opponent;
            if (opponent)
            {
                Random random = new Random();
                carCol = random.Next(2, 29); // Gera um número entre 2 (incluído) e 29 (excluído)
                carRow = 0;
            }
        }

        public void Draw()
        {
            if (opponent)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            for (int i = 0; i < body.Length; i++)
            {
                Console.SetCursorPosition(carCol, carRow + i);
                Console.Write(body[i]);                
            }
            Console.ForegroundColor = ConsoleColor.White;
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

        public void MoveDown()
        {
            if (carRow < 20)
            {
                Random random = new Random();

                var r = random.Next(0, 100);
                if (r > 10 && r < 20)
                {
                    MoveLeft();
                }
                else if (r > 40 && r < 50)
                {
                    MoveRight();
                }
                Erase();
                carRow++;
            }
        }
       
    }
}
