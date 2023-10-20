using System.Diagnostics;
using System.Media;

namespace ascii_race
{
    internal class Game
    {
        private int esquerdaTela;
        private int topoTela;
        private bool continuar;
        private Car car;
        private Road road;
        private int totalOpponents = 5;
        private int speed = 5;
        private List<Car> opponents = new List<Car>();
        private int collisions;
        private int overtakedOpponents;
        private SoundPlayer backGroundSound = new SoundPlayer(Properties.Resources._8_bit_racing_car);
        private SoundPlayer crashSound = new SoundPlayer(Properties.Resources.crash);
        private Stopwatch stopwatch = new Stopwatch();


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
            collisions = 0;
            overtakedOpponents= 0;

            PlayBackGroundSound();

            stopwatch.Start();

            // Game loop
            do
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt32(stopwatch.Elapsed.TotalSeconds));
                
                // Equivale a dizer que o conteúdo será executado 
                // 60 vezes por segundo (aproximadamente)
                Thread.Sleep(20 - speed);
                SpawnOpponent();
                updateCarPosition();
                car.Draw();
                CheckCollision();
                DrawOpponents();
                road.Forward();
                UpdateScore();
            }while (continuar);
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Até mais...");
        }
        private void SpawnOpponent()
        {
            if (road.CurrentPosition % 100 == 0 && opponents.Count < totalOpponents)
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
                    if (!opponent.MoveDown())
                    {
                        overtakedOpponents++;
                    }
                }
            }
        }

        private void UpdateScore()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt32(stopwatch.Elapsed.TotalSeconds));
            Console.SetCursorPosition(20, 0);
            Console.Write(timeSpan.ToString("c"));
            Console.SetCursorPosition(0, 22);
            float currentPosition = (float)road.CurrentPosition / 100;
            Console.Write($"Km(s):{currentPosition.ToString("n3")}  Collisions: {collisions.ToString()}");
            Console.SetCursorPosition(0, 23);
            Console.Write($"Ultrapassagens:{overtakedOpponents.ToString()}");
            Console.SetCursorPosition(0, 24);
            Console.Write($"Speed:{(speed * 10).ToString("000")}");
        }

        private void updateCarPosition()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    continuar = false;
                }
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    car.MoveLeft();
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    car.MoveRight();
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    SpeedUp();
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    SpeedDown();
                }
            }
        }

        private void SpeedUp()
        {
            if (speed < 20)
            {
                speed++;
            }
        }

        private void SpeedDown()
        {
            if (speed > 5)
            {
                speed--;
            }
        }
        static bool DetectCollision(List<Tuple<int, int>> matrix1, List<Tuple<int, int>> matrix2)
        {
            foreach (var coordinate in matrix1)
            {
                if (matrix2.Contains(coordinate))
                {
                    return true;
                }
            }
            return false;
        }
        private void CheckCollision()
        {
            foreach(var opponent in opponents)
            {
                if (DetectCollision(opponent.CarMatrix(), car.CarMatrix())) {
                    Crash();
                    collisions++;
                    opponent.Start();
                }
            }
        }

        private void Crash()
        {
            PlayCrashSound();
            speed = 5;
        }

        private void PlayBackGroundSound()
        {
            backGroundSound.PlayLooping();
        }

        private void PlayCrashSound()
        {
            backGroundSound.Stop();
            crashSound.Play();
            Thread.Sleep(1000);
            PlayBackGroundSound();
        }
    }
}
