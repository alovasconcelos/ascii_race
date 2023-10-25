namespace ascii_race
{
    internal class Splash
    {
        private string[] text =
        {
            " _______  _______  _______ __________________ ",
            @"(  ___  )(  ____ \(  ____ \\__   __/\__   __/",
            @"| (   ) || (    \/| (    \/   ) (      ) (   ",
            "| (___) || (_____ | |         | |      | |    ",
            "|  ___  |(_____  )| |         | |      | |    ",
            @"| (   ) |      ) || |         | |      | |   ",
            @"| )   ( |/\____) || (____/\___) (______) (___",
            @"|/     \|\_______)(_______/\_______/\_______/",
            " _______  _______  _______  _______",
            @"(  ____ )(  ___  )(  ____ \(  ____ \",
            @"| (    )|| (   ) || (    \/| (    \/",
            "| (____)|| (___) || |      | (__",
            "|     __)|  ___  || |      |  __)",
            @"| (\ (   | (   ) || |      | (",
            @"| ) \ \__| )   ( || (____/\| (____/\",
            @"|/   \__/|/     \|(_______/(_______/"

        };
                       
        public void Show()
        {
            Console.Clear();
            Console.CursorVisible = false;
            for (int row =  0; row < text.Length; row++)
            {
                Console.SetCursorPosition(0, 6 + row);
                for (int col = 0; col < text[row].Length; col++)
                {
                    Thread.Sleep(1);
                    Console.Write(text[row][col]);
                } 
            }
            Thread.Sleep(1000);
        }

    }
}
