using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
namespace ProjektKCK
{
    class Event
    {
        public static int[] generateExitRoom(int[,] map)
        {
            int[,] dung = map;
            
            Random random = new Random();
            int[] room = new int[2];
            room[0] = random.Next(4);
            room[1] = random.Next(4);
            int x = room[0];
            int y = room[1];
            if (dung[x,y] != 0)
            {
                int[] coordinates = new int[2];
                dung[x,y] = 20;
                coordinates[0] = x; 
                coordinates[1] = y;
                return coordinates;
                

            }
            else
            {
                return generateExitRoom(map);
            } 
        }
        public static Inventory note3Event(Inventory inv)
        {
            string answer;
         Note note3 = new Note("Revelation", "Et non mirum: ipse enim Satanas transfigurat se in angelum lucis.");
         Note key = new Note("KEY", "There cannot be light without darkness...");
            string asci1 = @"    ███        ▄█    █▄     ▄██████▄     ▄████████    ▄████████       ▄█     █▄     ▄█    █▄     ▄██████▄          ▄████████    ▄████████    ▄████████    ▄█   ▄█▄ 
▀█████████▄   ███    ███   ███    ███   ███    ███   ███    ███      ███     ███   ███    ███   ███    ███        ███    ███   ███    ███   ███    ███   ███ ▄███▀ 
   ▀███▀▀██   ███    ███   ███    ███   ███    █▀    ███    █▀       ███     ███   ███    ███   ███    ███        ███    █▀    ███    █▀    ███    █▀    ███ ██▀   
    ███   ▀  ▄███▄▄▄▄███▄▄ ███    ███   ███         ▄███▄▄▄          ███     ███  ▄███▄▄▄▄███▄▄ ███    ███        ███         ▄███▄▄▄      ▄███▄▄▄      ▄█████▀    
    ███     ▀▀███▀▀▀▀███▀  ███    ███ ▀███████████ ▀▀███▀▀▀          ███     ███ ▀▀███▀▀▀▀███▀  ███    ███      ▀███████████ ▀▀███▀▀▀     ▀▀███▀▀▀     ▀▀█████▄    
    ███       ███    ███   ███    ███          ███   ███    █▄       ███     ███   ███    ███   ███    ███               ███   ███    █▄    ███    █▄    ███ ██▄   
    ███       ███    ███   ███    ███    ▄█    ███   ███    ███      ███ ▄█▄ ███   ███    ███   ███    ███         ▄█    ███   ███    ███   ███    ███   ███ ▀███▄ 
   ▄████▀     ███    █▀     ▀██████▀   ▄████████▀    ██████████       ▀███▀███▀    ███    █▀     ▀██████▀        ▄████████▀    ██████████   ██████████   ███   ▀█▀ 
                                                                                                                                                         ▀         
";
            string asci2 = @"▄▄▄█████▓ ██░ ██ ▓█████    ▄▄▄█████▓ ██▀███   █    ██ ▄▄▄█████▓ ██░ ██ 
▓  ██▒ ▓▒▓██░ ██▒▓█   ▀    ▓  ██▒ ▓▒▓██ ▒ ██▒ ██  ▓██▒▓  ██▒ ▓▒▓██░ ██▒
▒ ▓██░ ▒░▒██▀▀██░▒███      ▒ ▓██░ ▒░▓██ ░▄█ ▒▓██  ▒██░▒ ▓██░ ▒░▒██▀▀██░
░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄    ░ ▓██▓ ░ ▒██▀▀█▄  ▓▓█  ░██░░ ▓██▓ ░ ░▓█ ░██ 
  ▒██▒ ░ ░▓█▒░██▓░▒████▒     ▒██▒ ░ ░██▓ ▒██▒▒▒█████▓   ▒██▒ ░ ░▓█▒░██▓
  ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░     ▒ ░░   ░ ▒▓ ░▒▓░░▒▓▒ ▒ ▒   ▒ ░░    ▒ ░░▒░▒
    ░     ▒ ░▒░ ░ ░ ░  ░       ░      ░▒ ░ ▒░░░▒░ ░ ░     ░     ▒ ░▒░ ░
  ░       ░  ░░ ░   ░        ░        ░░   ░  ░░░ ░ ░   ░       ░  ░░ ░
          ░  ░  ░   ░  ░               ░        ░               ░  ░  ░
                                                                       
";
            ConsoleKey keyPressed;
            Console.Clear();
            asci1 += "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
            UI.CenterAsci(asci1);
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            UI.CenterAsci(asci2);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.Clear();
            asci1 = @"   ▄████████    ▄█    █▄       ▄████████  ▄█        ▄█               ▄█   ▄█▄ ███▄▄▄▄    ▄██████▄   ▄█     █▄  
  ███    ███   ███    ███     ███    ███ ███       ███              ███ ▄███▀ ███▀▀▀██▄ ███    ███ ███     ███ 
  ███    █▀    ███    ███     ███    ███ ███       ███              ███ ██▀   ███   ███ ███    ███ ███     ███ 
  ███         ▄███▄▄▄▄███▄▄   ███    ███ ███       ███             ▄█████▀    ███   ███ ███    ███ ███     ███ 
▀███████████ ▀▀███▀▀▀▀███▀  ▀███████████ ███       ███            ▀▀█████▄    ███   ███ ███    ███ ███     ███ 
         ███   ███    ███     ███    ███ ███       ███              ███ ██▄   ███   ███ ███    ███ ███     ███ 
   ▄█    ███   ███    ███     ███    ███ ███     ▄ ███     ▄        ███ ▀███▄ ███   ███ ███    ███ ███ ▄█▄ ███ 
 ▄████████▀    ███    █▀      ███    █▀  █████▄▄██ █████▄▄██        ███   ▀█▀  ▀█   █▀   ▀██████▀   ▀███▀███▀  
                                         ▀         ▀                ▀                                          
";
            asci1 += "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
            asci2 = @" ▄████▄   ▒█████   ███▄    █   ██████ ▓█████   █████   █    ██ ▓█████  ███▄    █  ▄████▄  ▓█████   ██████ 
▒██▀ ▀█  ▒██▒  ██▒ ██ ▀█   █ ▒██    ▒ ▓█   ▀ ▒██▓  ██▒ ██  ▓██▒▓█   ▀  ██ ▀█   █ ▒██▀ ▀█  ▓█   ▀ ▒██    ▒ 
▒▓█    ▄ ▒██░  ██▒▓██  ▀█ ██▒░ ▓██▄   ▒███   ▒██▒  ██░▓██  ▒██░▒███   ▓██  ▀█ ██▒▒▓█    ▄ ▒███   ░ ▓██▄   
▒▓▓▄ ▄██▒▒██   ██░▓██▒    ██▒  ▒   ██▒▒▓█  ▄ ░██  █▀ ░▓▓█  ░██░▒▓█  ▄ ▓██▒    ██▒▒▓▓▄ ▄██▒▒▓█  ▄   ▒   ██▒
▒ ▓███▀ ░░ ████▓▒░▒██░   ▓██░▒██████▒▒░▒████▒░▒███▒█▄ ▒▒█████▓ ░▒████▒▒██░   ▓██░▒ ▓███▀ ░░▒████▒▒██████▒▒
░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░░░ ▒░ ░░░ ▒▒░ ▒ ░▒▓▒ ▒ ▒ ░░ ▒░ ░░ ▒░   ▒ ▒ ░ ░▒ ▒  ░░░ ▒░ ░▒ ▒▓▒ ▒ ░
  ░  ▒     ░ ▒ ▒░ ░ ░░   ░ ▒░░ ░▒  ░ ░ ░ ░  ░ ░ ▒░  ░ ░░▒░ ░ ░  ░ ░  ░░ ░░   ░ ▒░  ░  ▒    ░ ░  ░░ ░▒  ░ ░
░        ░ ░ ░ ▒     ░   ░ ░ ░  ░  ░     ░      ░   ░  ░░░ ░ ░    ░      ░   ░ ░ ░           ░   ░  ░  ░  
░ ░          ░ ░           ░       ░     ░  ░    ░       ░        ░  ░         ░ ░ ░         ░  ░      ░  
░                                                                                ░                        
";
            UI.CenterAsci(asci1);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            UI.CenterAsci(asci2);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.Clear();
            UI.CenterAsci("Remember, you can answer once");
            SetCursorPosition(UI.CalcPosition("KNOWLAGE"), 33);
            answer = Console.ReadLine();

            if (answer == "KNOWLAGE")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Thread.Sleep(1000);
                UI.CenterAsci("VERY WELL");
                Console.ForegroundColor = ConsoleColor.White;
                inv.AddNote(note3);
                inv.AddNote(key);
                return inv;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                asci1 = @"  █████▒▒█████   ▒█████   ██▓    
▓██   ▒▒██▒  ██▒▒██▒  ██▒▓██▒    
▒████ ░▒██░  ██▒▒██░  ██▒▒██░    
░▓█▒  ░▒██   ██░▒██   ██░▒██░    
░▒█░   ░ ████▓▒░░ ████▓▒░░██████▒
 ▒ ░   ░ ▒░▒░▒░ ░ ▒░▒░▒░ ░ ▒░▓  ░
 ░       ░ ▒ ▒░   ░ ▒ ▒░ ░ ░ ▒  ░
 ░ ░   ░ ░ ░ ▒  ░ ░ ░ ▒    ░ ░   
           ░ ░      ░ ░      ░  ░
                                 
";
                inv.AddNote(key);
                UI.CenterAsci(asci1);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                return inv;
            }
            

        }
        public static int[] generateNoteRoom(int[,] map)
        {
            int[,] dung = map;

            Random random = new Random();
            int[] room = new int[2];
            room[0] = random.Next(4);
            room[1] = random.Next(4);
            int x = room[0];
            int y = room[1];
            if (dung[x, y] == 2)
            {
                int[] coordinates = new int[2];
                dung[x, y] = 5;
                coordinates[0] = x;
                coordinates[1] = y;
                return coordinates;


            }
            else
            {
                return generateExitRoom(map);
            }
        }
        public static void Deathapperance()
        {
            Thread.Sleep(1500);
            string exept = @"  ▄████████ ▀████     ████▀  ▄████████    ▄████████    ▄███████▄     ███             ▄█    █▄     ▄█    ▄▄▄▄███▄▄▄▄   
  ███    ███   ███     ███▀  ███    ███   ███    ███   ███    ███ ▀█████████▄        ███    ███   ███  ▄██▀▀▀███▀▀▀██▄ 
  ███    █▀     ██    ███    ███    █▀    ███    █▀    ███    ███    ▀███▀▀██        ███    ███   ███  ███   ███   ███ 
 ▄███▄▄▄        ▀███▄███▀    ███         ▄███▄▄▄       ███    ███     ███   ▀       ▄███▄▄▄▄███▄▄ ███  ███   ███   ███ 
▀▀███▀▀▀        ████▀██▄     ███        ▀▀███▀▀▀     ▀█████████▀      ███          ▀▀███▀▀▀▀███▀  ███  ███   ███   ███ 
  ███    █▄     ███  ▀███    ███    █▄    ███    █▄    ███            ███            ███    ███   ███  ███   ███   ███ 
  ███    ███  ▄███     ███▄  ███    ███   ███    ███   ███            ███            ███    ███   ███  ███   ███   ███ 
  ██████████ ████       ███▄ ████████▀    ██████████  ▄████▀         ▄████▀          ███    █▀    █▀    ▀█   ███   █▀  
                                                                                                                       
";
            string death = @"              ;::::;
           ;::::; :;
         ;:::::'   :;
        ;:::::;     ;.
       ,:::::'       ;           OOO\
       ::::::;       ;          OOOOO\
       ;:::::;       ;         OOOOOOOO
      ,;::::::;     ;'         / OOOOOOO
    ;:::::::::`. ,,,;.        /  / DOOOOOO
  .';:::::::::::::::::;,     /  /     DOOOO
 ,::::::;::::::;;;;::::;,   /  /        DOOO
;`::::::`'::::::;;;::::: ,#/  /          DOOO
:`:::::::`;::::::;;::: ;::#  /            DOOO
::`:::::::`;:::::::: ;::::# /              DOO
`:`:::::::`;:::::: ;::::::#/               DOO
 :::`:::::::`;; ;:::::::::##                OO
 ::::`:::::::`;::::::::;:::#                OO
 `:::::`::::::::::::;'`:;::#                O
  `:::::`::::::::;' /  / `:#
   ::::::`:::::;'  /  /   `#";
           
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                UI.CenterAsci(exept);
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                UI.CenterAsci(death);
                Thread.Sleep(300);
                Console.Clear();
           
        }
        public static Inventory note1Event(Inventory inv)
        {
            Console.Clear();
            UI.CenterAsci("Do not trust everything you see...");
            Thread.Sleep(1000);
            Note note1 = new Note("Warning", "DO NOT TRUST HIM");

            inv.AddNote(note1);
            return inv;
        }
        public static Inventory note2Event(Inventory inv)
        {
            Console.Clear();
            UI.CenterAsci("There is always a key to open a door...");
            Thread.Sleep(1000);
            Note note1 = new Note("Chance", "Once you find it, you may have a chance to escape...");
            if(inv.HasNote("Chance")==false)
            inv.AddNote(note1);
            return inv;
        }
    }
}
