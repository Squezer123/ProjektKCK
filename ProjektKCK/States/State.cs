using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    class State
    {
        public Stack<State> states;
        public bool chekcer = false;
        public State(Stack<State> states) 
        {
            this.states = states;
             
        }
        
        public bool checkerReturn()
        {
            return this.chekcer;
        }

        virtual public void Update()
        {
            
        }
    }
}
