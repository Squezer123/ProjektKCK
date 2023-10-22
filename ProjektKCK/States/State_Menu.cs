using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ProjektKCK
{
    class State_Menu : State
    {
        private int indeks;
        private int menuChecker = 0;
        private string menuOption1 = UI.MenuOption("Play");
        private string menuOption2 = UI.MenuOption("Exit");
        public string asci = @"█▀▄▀█ ▄███▄      ▄     ▄   
█ █ █ █▀   ▀      █     █  
█ ▄ █ ██▄▄    ██   █ █   █ 
█   █ █▄   ▄▀ █ █  █ █   █ 
   █  ▀███▀   █  █ █ █▄ ▄█ 
  ▀           █   ██  ▀▀▀  
                           
";
        public StringBuilder sb = new StringBuilder();
        public int height;
        public State_Menu(Stack<State> states) : base(states)
        {

        }

        public void CreateMenu()
        {
            if (menuChecker == 0) {
                sb.Append(' ', UI.CalcPosition(menuOption1));
                sb.Append(menuOption1);
                sb.AppendLine();
                sb.Append(' ', UI.CalcPosition(menuOption2));
                sb.Append(menuOption2);
            }
            height = UI.CenterAsci(asci);
            Console.WriteLine(sb);
            menuChecker = 1;
        }

        public void MovingOption(int line, int line2)
        {
            int consoleWidth;
            int position;
            consoleWidth = Console.WindowWidth;
            position = (consoleWidth - menuOption1.Length - 7) / 2;
            Console.SetCursorPosition(position, line);
            Console.Write("<<");
            position = (consoleWidth + menuOption1.Length + 2) / 2;
            Console.SetCursorPosition(position, line);
            Console.Write(">>");
            consoleWidth = Console.WindowWidth;
            position = (consoleWidth - menuOption1.Length - 7) / 2;
            Console.SetCursorPosition(position, line2);
            Console.Write("  ");
            position = (consoleWidth + menuOption1.Length + 2) / 2;
            Console.SetCursorPosition(position, line2);
            Console.Write("  ");

        }


        public void ChangeOption(int option)
        {
            switch (option)
            {
                case 0:
                    MovingOption(height + 2, height);
                    MovingOption(height, height+2);
                    break;
                case 1:
                    MovingOption(height, height + 2);
                    MovingOption(height + 2, height);
                    break;
            }
        }


        override public void Update()
        {
            
            Console.Clear();
            CreateMenu();
            ChangeOption(0);
            ConsoleKey keyPressed;
            do
            {
                ConsoleKeyInfo przyciskinfo = ReadKey(true);
                keyPressed = przyciskinfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    indeks = 0;
                    ChangeOption(indeks);

                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    indeks = 1;
                    ChangeOption(indeks);
                }
            } while (keyPressed != ConsoleKey.Enter);


            if (indeks == 0) {
                string firstmessage = "You wake up in a room illuminated only by few torches...";
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                UI.GameIntro();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                UI.CenterAsci(firstmessage);
                Thread.Sleep(2000);
                this.states.Push(new State_Game(this.states));
            }
            if (indeks == 1)
            {
                this.chekcer = true;
            }
        }
    }
}
