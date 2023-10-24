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
        private int[] currentPosition = new int[2];
        private int direction;
        public static int height;
        protected int[,] GlobalMap = new int[4, 4]
        {
            {0,0,1,2},
            {0,2,2,0 },
            {2,2,0,0 },
            {0,2,2,0 }
        };
        public static string option1, option2, option3, option4;
        
        
        public static void Options(string option1, string option2, string option3, string option4)
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
            sbO.Append(' ', UI.CalcPosition(option1));
                sbO.Append(option1);
                sbO.AppendLine();
                sbO.Append(' ', UI.CalcPosition(option2));
                sbO.Append(option2);
                sbO.AppendLine();
                sbO.Append(' ', UI.CalcPosition(option3));
                sbO.Append(option3);
                sbO.AppendLine();
                sbO.Append(' ', UI.CalcPosition(option4));
                sbO.Append(option4);
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
                    MovingOption(height + 3, height + 3);
                    MovingOption(height+1, height + 2);
                    MovingOption(height + 2, height+1);
                    break;
                case 3:
                    MovingOption(height + 2, height + 3);
                    MovingOption(height + 3, height + 2);
                    break;
            }
        }

        override public void Update()
        {
            currentPosition = Map.CreateStartPoint(GlobalDungeon);
            option1 = "MOVE";
            option2 = "SEARCH";
            option3 = "MAP";
            option4 = "EXIT";
            
            Options(option1, option2, option3, option4);
            ChangeOption(0);
            ConsoleKey keyPressed;
            do
            {
                ConsoleKeyInfo przyciskinfo = ReadKey(true);
                keyPressed = przyciskinfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    if(indeks >0)
                    indeks--;
                    ChangeOption(indeks);

                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    if(indeks<3)
                    indeks++;
                    ChangeOption(indeks);
                }
            } while (keyPressed != ConsoleKey.Enter);

            switch (indeks)
            {
                case 0:
                    indeks = 0;
                    break;
                case 1:
                    indeks = 0;
                    break;
                case 2:
                    Console.Clear();
                    indeks = 0;
                    string map = "";
                    string room;
                    
                    for(int i = 0;i<4;i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (GlobalMap[i,j] == 2)
                            {
                                room = " [?]";
                                map = map + room;
                            }
                            else if (GlobalMap[i,j] == 1)
                            {
                                room = " [ ]";
                                map = map + room;
                            }
                            else if (GlobalMap[i, j] == 0)
                            {
                                room = "    ";
                                map = map + room;
                            }
                        }
                        map = map + '\n';
                    }

                    UI.CenterAsci(map);
                    do
                    {
                        ConsoleKeyInfo przyciskinfo = ReadKey(true);
                        keyPressed = przyciskinfo.Key;
                        
                    } while (keyPressed != ConsoleKey.Enter);
                    break;
                case 3:
                    this.states.Pop();
                    this.states.Pop();
                    break;
            }
        }
    }
}
