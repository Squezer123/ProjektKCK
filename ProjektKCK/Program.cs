using System;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using menu;

namespace ProjektPO
{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            while (true)
            {
                string prompt = "Giereczka";
                
                string[] options = { "Graj", "Ustawienia (Moze jakies beda)", "Wyjdz"};
                Menu mainmenu = new Menu(prompt, options);
                int indeks = mainmenu.Run();
                WriteLine(" ");
                int wroc = 0;
                switch (indeks)
                {
                    case 0:
                        
                        break;
                    case 1:
                        
                        break;
                    case 2:
                        System.Environment.Exit(0);
                        break;
                }
            }
            
        }
    }
}




