using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    class UI
    {
        public static String Title(String title) 
        {
            title = String.Format("==== {0} ====\n\n", title);
            return title; 
        }

        public static String MenuTitle(String option)
        {
            option = String.Format(" === {0}\n", option);

            return option;
        }

        public static String MenuOption(int nr, String option)
        {
            option = String.Format(" - ({0}) {1} :\n", nr, option);

            return option;
        }

        public static int CalcPosition(string txt)
        {
            int totalWidth = Console.WindowWidth;
            int leftPadding = (totalWidth - txt.Length) / 2;
            return leftPadding;
        }
    }
}
