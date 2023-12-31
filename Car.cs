﻿using System;
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
                Start();
            }
        }

        public void Start()
        {
            Erase();
            Random random = new Random();
            carCol = random.Next(2, 29); // Gera um número entre 2 (incluído) e 29 (excluído)
            carRow = 0;
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

        public bool MoveDown()
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
            else
            {
                Start();
                return false;
            }
            return true;
        }
      
        public List<Tuple<int, int>> CarMatrix()
        {
            List<Tuple<int, int>> matrix = new List<Tuple<int, int>>();
            for (int x = carCol; x < carCol + 3; x++)
            {
                for (int y = carRow;  y < carRow + 2; y++)
                {
                    var tuple = Tuple.Create(x, y); 
                    matrix.Add(tuple);
                }
            }
            return matrix;
        }
    }
}
