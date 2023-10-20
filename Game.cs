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
        const int totalOpponents = 5;
        private List<Car> opponents = new List<Car>();

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
                SpawnOpponent();
                updateCarPosition();
                car.Draw();
                DrawOpponents();
                road.Forward();
                UpdateScore();
            }while (continuar);
        }

        private void SpawnOpponent()
        {
            if (road.CurrentPosition % 20 == 0 && opponents.Count < totalOpponents)
            {
                var opponent = new Car(true);
                opponents.Add(opponent);
            }
        }

        private void DrawOpponents()
        {
            foreach (var opponent in opponents)
            {
                opponent.Draw();
                if (road.CurrentPosition % 10 == 0)
                {
                    opponent.MoveDown();
                }
            }
        }

        private void UpdateScore()
        {
            Console.SetCursorPosition(0, 22);
            float currentPosition = road.CurrentPosition / 100;
            Console.Write($"Km(s):{currentPosition.ToString("n3")}");
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
