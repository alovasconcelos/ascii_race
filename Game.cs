using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ascii_race
{
    internal class Game
    {
        private int esquerdaTela;
        private int topoTela;
        private bool continuar;
        private Car car;
        private Road road;

        public Game()
        {
            Start();
        }

        private void Start()
        {
            Console.Clear();
            Console.CursorVisible = false;
            topoTela = Console.CursorTop;
            esquerdaTela = Console.CursorLeft;
            continuar = true;
            car = new Car();
            road = new Road();
            road.Draw();
            // Game loop
            do
            {
                // Equivale a dizer que o conteúdo será executado 
                // 60 vezes por segundo (aproximadamente)
                Thread.Sleep(17);
                updateCarPosition();
                car.Draw();
                road.Forward();
                UpdateScore();
            }while (continuar);
        }

        private void UpdateScore()
        {
            Console.SetCursorPosition(0, 22);
            Console.Write($"Km(s):{road.CurrentPosition.ToString("n3")}");
        }

        private void updateCarPosition()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    car.MoveLeft();
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    car.MoveRight();
                }
            }
        }


    }
}
