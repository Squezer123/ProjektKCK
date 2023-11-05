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
        private int[] note3Position = new int[2];
        private int[] note2Position = new int[2];
        private int[] note1Position = new int[2];
        private int[] keyPosition = new int[2];
        private bool deathevent = false;
        public bool event3 = false;
        public bool event2 = false;
        public bool event1 = false;
        public Inventory playerInventory = new Inventory();
        
        public static int height;
        List<string> options = new List<string>();
        public static string escape = @"▄▄▄█████▓ ██░ ██ ▓█████  ██▀███  ▓█████     ██▓  ██████     ███▄    █  ▒█████     ▓█████   ██████  ▄████▄   ▄▄▄       ██▓███  ▓█████ 
▓  ██▒ ▓▒▓██░ ██▒▓█   ▀ ▓██ ▒ ██▒▓█   ▀    ▓██▒▒██    ▒     ██ ▀█   █ ▒██▒  ██▒   ▓█   ▀ ▒██    ▒ ▒██▀ ▀█  ▒████▄    ▓██░  ██▒▓█   ▀ 
▒ ▓██░ ▒░▒██▀▀██░▒███   ▓██ ░▄█ ▒▒███      ▒██▒░ ▓██▄      ▓██  ▀█ ██▒▒██░  ██▒   ▒███   ░ ▓██▄   ▒▓█    ▄ ▒██  ▀█▄  ▓██░ ██▓▒▒███   
░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄ ▒██▀▀█▄  ▒▓█  ▄    ░██░  ▒   ██▒   ▓██▒  ▐▌██▒▒██   ██░   ▒▓█  ▄   ▒   ██▒▒▓▓▄ ▄██▒░██▄▄▄▄██ ▒██▄█▓▒ ▒▒▓█  ▄ 
  ▒██▒ ░ ░▓█▒░██▓░▒████▒░██▓ ▒██▒░▒████▒   ░██░▒██████▒▒   ▒██░   ▓██░░ ████▓▒░   ░▒████▒▒██████▒▒▒ ▓███▀ ░ ▓█   ▓██▒▒██▒ ░  ░░▒████▒
  ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░░ ▒▓ ░▒▓░░░ ▒░ ░   ░▓  ▒ ▒▓▒ ▒ ░   ░ ▒░   ▒ ▒ ░ ▒░▒░▒░    ░░ ▒░ ░▒ ▒▓▒ ▒ ░░ ░▒ ▒  ░ ▒▒   ▓▒█░▒▓▒░ ░  ░░░ ▒░ ░
    ░     ▒ ░▒░ ░ ░ ░  ░  ░▒ ░ ▒░ ░ ░  ░    ▒ ░░ ░▒  ░ ░   ░ ░░   ░ ▒░  ░ ▒ ▒░     ░ ░  ░░ ░▒  ░ ░  ░  ▒     ▒   ▒▒ ░░▒ ░      ░ ░  ░
  ░       ░  ░░ ░   ░     ░░   ░    ░       ▒ ░░  ░  ░        ░   ░ ░ ░ ░ ░ ▒        ░   ░  ░  ░  ░          ░   ▒   ░░          ░   
          ░  ░  ░   ░  ░   ░        ░  ░    ░        ░              ░     ░ ░        ░  ░      ░  ░ ░            ░  ░            ░  ░
                                                                                                  ░                                  
";
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
        public int[,] GlobalMap = new int[4, 4]
        {
            {0,0,1,2},
            {0,2,2,0 },
            {2,2,0,0 },
            {0,2,2,0 }
        };

        public int[] exitRoom = new int[2]; 


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
                    MovingOption(height + 4, height + 4);
                    MovingOption(height + 2, height + 3);
                    MovingOption(height + 3, height + 2);
                    break;
                case 4:
                    MovingOption(height + 3, height + 4);
                    MovingOption(height + 4, height + 3);
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
                exitRoom = Event.generateExitRoom(GlobalMap);
                GlobalMap[exitRoom[0], exitRoom[1]] = 20;
                note1Position = Event.generateNoteRoom(GlobalMap);
                note2Position = Event.generateNoteRoom(GlobalMap);
                note3Position = Event.generateNoteRoom(GlobalMap);
                keyPosition = Event.generateNoteRoom(GlobalMap);

            }
            start = 1;
            
            
            options.Clear();
            options.Add("Move");
            options.Add("Search");
            options.Add("Map");
            options.Add("Notes");
            options.Add("Exit");
            Console.ForegroundColor = ConsoleColor.DarkRed;
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
                    if(indeks<4)
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
                    if (GlobalMap[currentPosition[0], currentPosition[1]] == GlobalMap[exitRoom[0], exitRoom[1]])
                        GlobalMap[currentPosition[0], currentPosition[1]] = 10;
                    currentPosition = Map.changePosition(currentOption, currentPosition);
                    
                    GlobalMap[currentPosition[0], currentPosition[1]] = 3;
                    indeks = 0;

                    break;
                case 1:
                    if (currentPosition.SequenceEqual(exitRoom))
                    {
                        string key = "KEY";
                        if (playerInventory.HasNote(key)) { 
                            Console.Clear();
                            UI.CenterAsci("You escpaed, you may live your life in peace...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                            int amount = playerInventory.HowManyNotes();
                             string counter = " " + amount + "/" + "3";
                            UI.CenterAsci(counter);
                            Thread.Sleep(1000);
                            Console.Clear();
                           
                            Thread.Sleep(1000);
                            if (amount == 4)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                UI.CenterAsci(escape);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Thread.Sleep(2000);
                            this.states.Pop();
                            this.states.Pop();
                        }
                        else
                        {
                            Console.Clear();
                            UI.CenterAsci("You need a key to leave this place");
                            Thread.Sleep(1000);
                        }
                       
                    }
                    else if (currentPosition.SequenceEqual(note3Position))
                    {
                        if(event3 == false)
                        {
                            Thread.Sleep(100);
                            playerInventory = Event.note3Event(playerInventory);
                            event3 = true;
                        }
                        else
                        {
                            Console.Clear();
                            UI.CenterAsci("You no longer see it...");
                            Thread.Sleep(1500);
                        }
                        
                    }
                    else if (currentPosition.SequenceEqual(note1Position))
                    {
                        if (event1 == false)
                        {
                            playerInventory = Event.note1Event(playerInventory);
                            event1 = true;
                            GlobalMap[note1Position[0], note1Position[1]] = 1;
                        }
                    }
                    else if (currentPosition.SequenceEqual(note2Position))
                    {
                        if (event2 == false)
                        {
                            playerInventory = Event.note2Event(playerInventory);
                            event2 = true;
                            GlobalMap[note2Position[0], note2Position[1]] = 1;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        indeks = 0;
                        UI.CenterAsci("There is nothing here...");
                        Thread.Sleep(1500);
                        Random rand = new Random();
                        if(deathevent == false && rand.Next(100) % 3 == 0)
                        {
                            Event.Deathapperance();
                            deathevent = true;
                        }
                        Console.Clear();   
                        
                    }
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
                    Console.Clear();
                    indeks = 0;
                    playerInventory.DisplayNotes();
                    do
                    {
                        ConsoleKeyInfo przyciskinfo = ReadKey(true);
                        keyPressed = przyciskinfo.Key;

                    } while (keyPressed != ConsoleKey.Enter);
                    break;

                case 4:
                    this.states.Pop();
                    this.states.Pop();
                    break;
            }
        }
    }
}
