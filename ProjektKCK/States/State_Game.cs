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
        protected int[,] GlobalMap = new int[4, 4];
        private void InitStates()
        {
            this.gameStates = new Stack<State>();
        }
        
        

        override public void Update()
        {
            this.InitStates();

            for (int k = 0; k < 4; k++)
            {
                for (int l = 0; l < 4; l++)
                {
                    GlobalMap[k, l] = 2;
                }
                Console.WriteLine();
            }

            Map.CreateStartPoint(GlobalMap);

            this.gameStates.Push(new State_Room(this.gameStates));

                while (this.gameStates.Count() > 0)
                {
                    this.gameStates.Peek().Update();
                    if (this.gameStates.Peek().checkerReturn())
                    {
                        this.gameStates.Pop();
                    }
                }
            this.chekcer = true;
        }
 
    }
}
