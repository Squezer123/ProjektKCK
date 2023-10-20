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
            
        }
        override public void Update()
        {
            Console.WriteLine("test");
            int numer = Convert.ToInt32(Console.ReadLine());


            if (numer < 0)
            {
                this.chekcer = true;
            }
        }
    }
}
