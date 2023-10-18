using System;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace menu
{
    class Menu
    {

        private int indeks;
        private string[] opcje;
        private string Prompt;
        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            opcje = options;
            indeks = 0;
        }
        public void WypiszOpcje()
        {
            WriteLine(Prompt);
            for (int i = 0; i < opcje.Length; i++)
            {
                string ObecnaOpcja = opcje[i];
                string pre;
                if (i == indeks)
                {
                    pre = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    pre = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine($"{pre}<<{ObecnaOpcja}>>");

            }
            ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                WypiszOpcje();
                ConsoleKeyInfo przyciskinfo = ReadKey(true);
                keyPressed = przyciskinfo.Key;
                if(keyPressed == ConsoleKey.UpArrow)
                {
                    indeks--;
                    if(indeks == -1)
                    {
                        indeks = opcje.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    indeks++;
                    if (indeks == opcje.Length)
                    {
                        indeks = 0; 
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return indeks;
        }
        
    }
}