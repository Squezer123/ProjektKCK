using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;


namespace ProjektKCK
{

    class State_Room : State_Game
    {
       
        public State_Room(Stack<State> states) : base(states)
        {

        }
        private int indeks;
        public static int height;
        public static string option1;
        public static string option2;
        public static string option3;
        public static void Options()
        {
            Console.Clear();
            StringBuilder sbO = new StringBuilder();
            string asciOpt = @" ▄▄▄       ▄████▄  ▄▄▄█████▓ ██▓ ██▒   █▓ ██▓▄▄▄█████▓ ██▓▓█████   ██████ 
▒████▄    ▒██▀ ▀█  ▓  ██▒ ▓▒▓██▒▓██░   █▒▓██▒▓  ██▒ ▓▒▓██▒▓█   ▀ ▒██    ▒ 
▒██  ▀█▄  ▒▓█    ▄ ▒ ▓██░ ▒░▒██▒ ▓██  █▒░▒██▒▒ ▓██░ ▒░▒██▒▒███   ░ ▓██▄   
░██▄▄▄▄██ ▒▓▓▄ ▄██▒░ ▓██▓ ░ ░██░  ▒██ █░░░██░░ ▓██▓ ░ ░██░▒▓█  ▄   ▒   ██▒
 ▓█   ▓██▒▒ ▓███▀ ░  ▒██▒ ░ ░██░   ▒▀█░  ░██░  ▒██▒ ░ ░██░░▒████▒▒██████▒▒
 ▒▒   ▓▒█░░ ░▒ ▒  ░  ▒ ░░   ░▓     ░  ░  ░▓    ▒ ░░   ░▓  ░░ ▒░ ░▒ ▒▓▒ ▒ ░
  ▒   ▒▒ ░  ░  ▒       ░     ▒ ░   ░ ░░   ▒ ░    ░     ▒ ░ ░ ░  ░░ ░▒  ░ ░
  ░   ▒   ░          ░       ▒ ░     ░░   ▒ ░  ░       ▒ ░   ░   ░  ░  ░  
      ░  ░░ ░                ░        ░   ░            ░     ░  ░      ░  
          ░                          ░                                    
";
            option1 = "MOVE";
            option2 = "SEARCH";
            option3 = "MAP";
            option3 = "EXIT";
            sbO.Append(' ', UI.CalcPosition(option1));
                sbO.Append(option1);
                sbO.AppendLine();
                sbO.Append(' ', UI.CalcPosition(option2));
                sbO.Append(option2);
                sbO.AppendLine();
                sbO.Append(' ', UI.CalcPosition(option3));
                sbO.Append(option3);
                sbO.AppendLine();
            Console.ForegroundColor = ConsoleColor.Red;
            height = UI.CenterAsci(asciOpt);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(sbO);
            
        }
        public void MovingOption(int line, int line2)
        {
            int consoleWidth;
            int position;
            consoleWidth = Console.WindowWidth;
            position = (consoleWidth - option1.Length - 7) / 2;
            Console.SetCursorPosition(position, line);
            Console.Write("<<");
            position = (consoleWidth + option1.Length + 2) / 2;
            Console.SetCursorPosition(position, line);
            Console.Write(">>");
            consoleWidth = Console.WindowWidth;
            position = (consoleWidth - option1.Length - 7) / 2;
            Console.SetCursorPosition(position, line2);
            Console.Write("  ");
            position = (consoleWidth + option1.Length + 2) / 2;
            Console.SetCursorPosition(position, line2);
            Console.Write("  ");

        }


        public void ChangeOption(int option)
        {
            
            switch (option)
            {
                case 0:
                    MovingOption(height + 1, height);
                    MovingOption(height, height + 1);
                    break;
                case 1:
                    MovingOption(height, height + 1);
                    MovingOption(height + 1, height);
                    MovingOption(height + 2, height + 2);
                    break;
                case 2:
                    MovingOption(height+1, height + 2);
                    MovingOption(height + 2, height+1);
                    break;
            }
        }

        override public void Update()
        {
            Options();
            ChangeOption(0);
            ConsoleKey keyPressed;
            do
            {
                ConsoleKeyInfo przyciskinfo = ReadKey(true);
                keyPressed = przyciskinfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    if(indeks >=0)
                    indeks--;
                    ChangeOption(indeks);

                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    if(indeks<2)
                    indeks++;
                    ChangeOption(indeks);
                }
            } while (keyPressed != ConsoleKey.Enter);

            switch (indeks)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    this.states.Pop();
                    this.states.Pop();
                    break;
            }
        }
    }
}
