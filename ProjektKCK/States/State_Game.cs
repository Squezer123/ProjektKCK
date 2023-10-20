using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK{ 
    class State_Game : State
    {
        public State_Game(Stack<State> states) : base(states)
        {
            Console.WriteLine("Dziala game state");
        }
    }
}
