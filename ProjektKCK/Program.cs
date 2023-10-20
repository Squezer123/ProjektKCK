using System;
using static System.Console;
using menu;
using ProjektKCK;
using System.Runtime.InteropServices;

namespace ProjektPO
{

    public class Program
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();


        public const int SW_SHOWMAXIMIZED = 3;
        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight;
            IntPtr consoleHandle = GetConsoleWindow();
            if (consoleHandle != IntPtr.Zero)
            {
                ShowWindow(consoleHandle, SW_SHOWMAXIMIZED);
            }
            Console.CursorVisible = false;
            string asciiArt = @" __      __.__  __              __ 
/  \    /  \__|/  |______      |__|
\   \/\/   /  \   __\__  \     |  |
 \        /|  ||  |  / __ \_   |  |
  \__/\  / |__||__| (____  /\__|  |
       \/                \/\______|";

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            string[] lines = asciiArt.Split('\n');
            int artWidth = lines[0].Length;
            int artHeight = lines.Length;

            int centerX = (windowWidth - artWidth) / 2;
            int centerY = (windowHeight - artHeight) / 2;

            foreach (string line in lines)
            {
                Console.SetCursorPosition(centerX, centerY);
                Console.WriteLine(line);
                centerY++;
            }
            Game game = new Game();
            game.Run();
            
        }
    }
}




 