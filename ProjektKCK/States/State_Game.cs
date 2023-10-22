using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK{ 
    class State_Game : State
    {
        private string firstmessage = "You wake up in a room illuminated only by few torches...";
        public State_Game(Stack<State> states) : base(states)
        {
            
        }
        override public void Update()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            UI.GameIntro();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            UI.CenterAsci(firstmessage);
            int[,] test = new int[5, 5];
            for (int k = 0; k < 10; k++)
            {
                Console.WriteLine();
                test = Map.CreatMap(test);
            }
            int numer = Convert.ToInt32(Console.ReadLine());
            
            if (numer < 0)
            {
                this.chekcer = true;
            }
        }
    }
}
