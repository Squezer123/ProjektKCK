using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    class UI
    {
        public static String Title(String title) 
        {
            title = String.Format("==== {0} ====\n\n", title);
            return title; 
        }

        public static String MenuTitle(String option)
        {
            return option;
        }

        public static int CenterAsci(String asciiArt) {
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
            return centerY;
        }

        public static String MenuOption(String option)
        {
            option = String.Format("({0})\n", option);

            return option;
        }

        public static void GameIntro()
        {
            string face = @"  █████▒▄▄▄       ▄████▄  ▓█████    ▄▄▄█████▓ ██░ ██ ▓█████ 
▓██   ▒▒████▄    ▒██▀ ▀█  ▓█   ▀    ▓  ██▒ ▓▒▓██░ ██▒▓█   ▀ 
▒████ ░▒██  ▀█▄  ▒▓█    ▄ ▒███      ▒ ▓██░ ▒░▒██▀▀██░▒███   
░▓█▒  ░░██▄▄▄▄██ ▒▓▓▄ ▄██▒▒▓█  ▄    ░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄ 
░▒█░    ▓█   ▓██▒▒ ▓███▀ ░░▒████▒     ▒██▒ ░ ░▓█▒░██▓░▒████▒
 ▒ ░    ▒▒   ▓▒█░░ ░▒ ▒  ░░░ ▒░ ░     ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░
 ░       ▒   ▒▒ ░  ░  ▒    ░ ░  ░       ░     ▒ ░▒░ ░ ░ ░  ░
 ░ ░     ░   ▒   ░           ░        ░       ░  ░░ ░   ░   
             ░  ░░ ░         ░  ░             ░  ░  ░   ░  ░
                 ░                                          
";
            string con = @" ▄████████  ▄██████▄  ███▄▄▄▄      ▄████████    ▄████████ ████████▄   ███    █▄     ▄████████ ███▄▄▄▄    ▄████████    ▄████████    ▄████████ 
███    ███ ███    ███ ███▀▀▀██▄   ███    ███   ███    ███ ███    ███  ███    ███   ███    ███ ███▀▀▀██▄ ███    ███   ███    ███   ███    ███ 
███    █▀  ███    ███ ███   ███   ███    █▀    ███    █▀  ███    ███  ███    ███   ███    █▀  ███   ███ ███    █▀    ███    █▀    ███    █▀  
███        ███    ███ ███   ███   ███         ▄███▄▄▄     ███    ███  ███    ███  ▄███▄▄▄     ███   ███ ███         ▄███▄▄▄       ███        
███        ███    ███ ███   ███ ▀███████████ ▀▀███▀▀▀     ███    ███  ███    ███ ▀▀███▀▀▀     ███   ███ ███        ▀▀███▀▀▀     ▀███████████ 
███    █▄  ███    ███ ███   ███          ███   ███    █▄  ███    ███  ███    ███   ███    █▄  ███   ███ ███    █▄    ███    █▄           ███ 
███    ███ ███    ███ ███   ███    ▄█    ███   ███    ███ ███  ▀ ███  ███    ███   ███    ███ ███   ███ ███    ███   ███    ███    ▄█    ███ 
████████▀   ▀██████▀   ▀█   █▀   ▄████████▀    ██████████  ▀██████▀▄█ ████████▀    ██████████  ▀█   █▀  ████████▀    ██████████  ▄████████▀  
                                                                                                                                             
";
            string pentagram = @"            ..---n---..
         .--""""' / \   '""""--.
      .""        |   |        "".
    .""          |   |          "".
   /           /     \           \
  /           |       |           \
 .------------+-------+------------.
.'`--.       /         \       .--' .
:     "".    |           |    .""     ;
|       ""-. |           | .-""       |
|          )-.         .-(          |
""         |   "".     .""   |         ""
 \       /      ""-.-""      \       /
 "".     |      .-' '-.      |     .""
  \     |    .""       "".    |     /
   \   /  .-""           ""-.  \   /
    "".|.-""                 ""-.|.""
      "".                     .""
        ""--..           ..--""
            '""""-------""""'";
            CenterAsci(face);
            Thread.Sleep(1000);
            Console.Clear();
            CenterAsci(con);
            Thread.Sleep(1500);
            Console.Clear();
            CenterAsci(pentagram);
            Thread.Sleep(50);
            Console.Clear();
        }

        public static int CalcPosition(string txt)
        {
            int totalWidth = Console.WindowWidth;
            int leftPadding = (totalWidth - txt.Length) / 2;
            return leftPadding;
        }
    }
}
