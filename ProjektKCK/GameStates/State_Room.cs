using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    class State_Room : State_Game
    {
       
        public State_Room(Stack<State> states) : base(states)
        {

        }

        public static void Options()
        {
            Console.WriteLine("test");
        }

        override public void Update()
        {
            
            
            Options();
            Thread.Sleep(2000);
            this.chekcer = true;
        }
    }
}
