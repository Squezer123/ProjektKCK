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
        private int start = 0;
        private int indeks;
        private int[] currentPosition = new int[2];
        private int direction;
        public static int height;
        List<string> options = new List<string>();
        public string asciOpt = @" ▄▄▄       ▄████▄  ▄▄▄█████▓ ██▓ ██▒   █▓ ██▓▄▄▄█████▓ ██▓▓█████   ██████ 
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
        public string directions = @"▓█████▄  ██▓ ██▀███  ▓█████  ▄████▄  ▄▄▄█████▓ ██▓ ▒█████   ███▄    █   ██████ 
▒██▀ ██▌▓██▒▓██ ▒ ██▒▓█   ▀ ▒██▀ ▀█  ▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █ ▒██    ▒ 
░██   █▌▒██▒▓██ ░▄█ ▒▒███   ▒▓█    ▄ ▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒░ ▓██▄   
░▓█▄   ▌░██░▒██▀▀█▄  ▒▓█  ▄ ▒▓▓▄ ▄██▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒  ▒   ██▒
░▒████▓ ░██░░██▓ ▒██▒░▒████▒▒ ▓███▀ ░  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░▒██████▒▒
 ▒▒▓  ▒ ░▓  ░ ▒▓ ░▒▓░░░ ▒░ ░░ ░▒ ▒  ░  ▒ ░░   ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░
 ░ ▒  ▒  ▒ ░  ░▒ ░ ▒░ ░ ░  ░  ░  ▒       ░     ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░░ ░▒  ░ ░
 ░ ░  ░  ▒ ░  ░░   ░    ░   ░          ░       ▒ ░░ ░ ░ ▒     ░   ░ ░ ░  ░  ░  
   ░     ░     ░        ░  ░░ ░                ░      ░ ░           ░       ░  
 ░                          ░                                                  
";
        protected int[,] GlobalMap = new int[4, 4]
        {
            {0,0,1,1},
            {0,1,1,0 },
            {1,1,0,0 },
            {0,1,1,0 }
        };

        public void MovingOption(int line, int line2)
        {
            int consoleWidth;
            int position;
            int item_witdh = options.First().Length;
            consoleWidth = Console.WindowWidth;
            position = (consoleWidth - item_witdh - 7) / 2;
            Console.SetCursorPosition(position, line);
            Console.Write("<<");
            position = (consoleWidth + item_witdh + 2) / 2;
            Console.SetCursorPosition(position, line);
            Console.Write(">>");
            consoleWidth = Console.WindowWidth;
            position = (consoleWidth - item_witdh - 7) / 2;
            Console.SetCursorPosition(position, line2);
            Console.Write("  ");
            position = (consoleWidth + item_witdh + 2) / 2;
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
            Console.Clear();
            if (start == 0)
            {
                currentPosition = Map.CreateStartPoint(GlobalMap);
                GlobalMap[currentPosition[0], currentPosition[1]] = 3;
            }
            start = 1;
            options.Clear();
            options.Add("Move");
            options.Add("Search");
            options.Add("Map");
            options.Add("Exit");
            Console.ForegroundColor = ConsoleColor.Red;
            height = UI.CenterAsci(asciOpt);
            Console.ForegroundColor = ConsoleColor.White;
            UI.DisplayMenu(options);
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
                    
                    Console.Clear();
                    options.Clear();
                    options = Map.MoveOptions(GlobalMap, currentPosition);
                    Console.ForegroundColor = ConsoleColor.Red;
                    height = UI.CenterAsci(asciOpt);
                    UI.DisplayMenu(options);
                    int max_index = options.Count();
                    ChangeOption(0);
                    string currentOption = options[0];
                    do
                    {
                        ConsoleKeyInfo przyciskinfo = ReadKey(true);
                        keyPressed = przyciskinfo.Key;
                        if (keyPressed == ConsoleKey.UpArrow)
                        {
                            if (indeks > 0)
                            {
                                indeks--;
                                currentOption = options[indeks];
                            }
                            ChangeOption(indeks);

                        }
                        else if (keyPressed == ConsoleKey.DownArrow)
                        {
                            if (indeks < options.Count()-1)
                            {
                                indeks++;
                                currentOption = options[indeks];
                            }
                                
                            ChangeOption(indeks);
                        }
                    } while (keyPressed != ConsoleKey.Enter);
                    GlobalMap[currentPosition[0], currentPosition[1]] = 1;
                    currentPosition = Map.changePosition(currentOption, currentPosition);
                    GlobalMap[currentPosition[0], currentPosition[1]] = 3;
                    indeks = 0;

                    break;
                case 1:
                    indeks = 0;
                    

                    break;
                case 2:
                    Console.Clear();
                    indeks = 0;
                    Map.DisplayMap(GlobalMap);
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
