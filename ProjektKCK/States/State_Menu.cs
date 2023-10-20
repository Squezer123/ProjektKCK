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

        }

        override public void Update()
        {
            string menuTitle = UI.MenuTitle("Main Menu");
            string menuOption1 = UI.MenuOption(0, "Create Character");
            string menuOption2 = UI.MenuOption(-1, "Exit");
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append(' ', UI.CalcPosition(menuTitle));
            sb.Append(menuTitle);
            sb.AppendLine();
            sb.Append(' ', UI.CalcPosition(menuOption1));
            sb.Append(menuOption1);
            sb.AppendLine();
            sb.Append(' ', UI.CalcPosition(menuOption2));
            sb.Append(menuOption2);
            Console.WriteLine(sb);
            int numer = Convert.ToInt32(Console.ReadLine());

            if (numer == 0) {
                this.states.Push(new State_Game(this.states)); ;
            }
            if (numer == 1)
            {
                this.chekcer = true;
            }
        }
    }
}
