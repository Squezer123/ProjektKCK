using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    class Game
    {
        private bool checker;

       public bool Checker
        {
            get { return this.checker; }
            set { this.checker = value; }
        }        

        private Stack<State> states;
        private void initVar()
        {
            this.checker = false;
        }

        private void InitStates() 
        {
            this.states = new Stack<State>();
            this.states.Push(new State_Menu(this.states));
        }

  
        public Game() 
        {
            this.initVar();
            this.InitStates();
        }

        public void Run()
        {
            Thread.Sleep(2000);
            Console.Clear();
            while (this.states.Count() > 0)
            {
                    this.states.Peek().Update();

                    if(this.states.Peek().checkerReturn())
                        this.states.Pop();
            }

            Console.WriteLine("Ending game...");
        }
    }
}
