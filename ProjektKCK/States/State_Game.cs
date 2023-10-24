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
            Map dungeon = new Map();
            GlobalDungeon = dungeon.dungeon;

        }
        protected int[,] GlobalDungeon { get; set; }
        public bool stateVar;
           
        

        override public void Update()
        {
            string firstmessage = "You wake up in a room illuminated only by few torches...";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            UI.GameIntro();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            UI.CenterAsci(firstmessage);
            Thread.Sleep(2000);
            Console.Clear();
            this.states.Push(new State_Room(this.states));

            this.chekcer = true;
        }
 
    }
}
