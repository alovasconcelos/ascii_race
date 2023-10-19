using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ascii_race
{
    internal class Cena
    {
        private int colunaOriginal;
        private int linhaOriginal;

        private bool continuar;


        string[] carro = { "■▄■", "▀▀▀" };

        private int colunaCarro { get; set; }
        const int linha1Carro = 20;
        const int linha2Carro = 21;

        public Cena()
        {
            Iniciar();
        }

        private void Iniciar()
        {
            Console.Clear();
            Console.CursorVisible = false;
            linhaOriginal = Console.CursorTop;
            colunaOriginal = Console.CursorLeft;
            colunaCarro = 10;
            continuar = true;
            do
            {
                Thread.Sleep(17);
                AtualizaPosicaoCarro();
            }while (continuar);
        }

        private void DesenhaCarro()
        {
            Desenha_X_Y(carro[0], colunaCarro, linha1Carro);
            Desenha_X_Y(carro[1], colunaCarro, linha2Carro);
        }

        private void ApagaCarro()
        {
            Desenha_X_Y("   ", colunaCarro, linha1Carro);
            Desenha_X_Y("   ", colunaCarro, linha2Carro);
        }

        private void AtualizaPosicaoCarro()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    ApagaCarro();
                    colunaCarro = colunaCarro - (colunaCarro > 2 ? 1 : 0);
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    ApagaCarro();
                    colunaCarro = colunaCarro + (colunaCarro < 20 ? 1 : 0);
                }
            }

            DesenhaCarro();
        }

        protected void Desenha_X_Y(string texto, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(colunaOriginal + x, linhaOriginal + y);
                Console.Write(texto);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

    }
}
