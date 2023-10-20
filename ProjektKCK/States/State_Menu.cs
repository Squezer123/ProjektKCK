using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    class State_Menu : State
    {
        public State_Menu(Stack<State> states) : base(states) 
        {
            Console.WriteLine("Hello Main Menu");

            this.states.Push(new State_Game(this.states));
        }
    }
}
