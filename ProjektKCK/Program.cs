using System;
using static System.Console;
using ProjektKCK;
using System.Runtime.InteropServices;

namespace ProjektKCK
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
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.CursorVisible = false;
            
            string asciiArt = @"   ▄████████  ▄██████▄     ▄████████    ▄██████▄   ▄██████▄      ███         ███        ▄████████ ███▄▄▄▄   
  ███    ███ ███    ███   ███    ███   ███    ███ ███    ███ ▀█████████▄ ▀█████████▄   ███    ███ ███▀▀▀██▄ 
  ███    █▀  ███    ███   ███    ███   ███    █▀  ███    ███    ▀███▀▀██    ▀███▀▀██   ███    █▀  ███   ███ 
 ▄███▄▄▄     ███    ███  ▄███▄▄▄▄██▀  ▄███        ███    ███     ███   ▀     ███   ▀  ▄███▄▄▄     ███   ███ 
▀▀███▀▀▀     ███    ███ ▀▀███▀▀▀▀▀   ▀▀███ ████▄  ███    ███     ███         ███     ▀▀███▀▀▀     ███   ███ 
  ███        ███    ███ ▀███████████   ███    ███ ███    ███     ███         ███       ███    █▄  ███   ███ 
  ███        ███    ███   ███    ███   ███    ███ ███    ███     ███         ███       ███    ███ ███   ███ 
  ███         ▀██████▀    ███    ███   ████████▀   ▀██████▀     ▄████▀      ▄████▀     ██████████  ▀█   █▀  
                          ███    ███                                                                        
";
            UI.CenterAsci(asciiArt);
            
            Console.ForegroundColor = ConsoleColor.White;
            Game game = new Game();
            game.Run();

        }
    }
}




