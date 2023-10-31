using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    class Map
    {
        public int[,] dungeon;

        public Map()
        {
            dungeon = CreateDungeon();
        }

        public int[,] CreateDungeon()
        {
            int[,] newDungeon = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Random rand = new Random();
                    newDungeon[i, j] = rand.Next(2);
                }
            }
            return newDungeon;
        }

        public static int[] CreateStartPoint(int[,] map)
        {
            int[] startPointCoordinates = new int[2];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == 1)
                    {
                        startPointCoordinates[0] = x;
                        startPointCoordinates[1] = y;
                        return startPointCoordinates;
                    }
                }
            }
            return startPointCoordinates;
        }

        public static void DisplayMap(int[,] GlobalMap)
        {
            string map = "";
            string room;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (GlobalMap[i, j] == 2)
                    {
                        room = " [?]";
                        map = map + room;
                    }
                    else if (GlobalMap[i, j] == 1)
                    {
                        room = " [ ]";
                        map = map + room;
                    }
                    else if (GlobalMap[i, j] == 0)
                    {
                        room = "    ";
                        map = map + room;
                    }
                    else if (GlobalMap[i, j] == 3)
                    {
                        room = " [X]";
                        map = map + room;
                    }
                }
                map = map + '\n';
            }

            UI.CenterAsci(map);
        }
        public static List<string> MoveOptions(int[,] dungeon, int[] position)
        {
            List<string> options = new List<string>();
            string option;
            int x = position[0];
            int y = position[1];
            int numRows = dungeon.GetLength(0);
            int numCols = dungeon.GetLength(1);

            if (x > 0 && dungeon[x - 1, y] == 1)
            {
                option = "UP";
                options.Add(option);
            }
            if (x < numRows - 1 && dungeon[x + 1, y] == 1)
            {
                option = "DOWN";
                options.Add(option);
            }
            if (y > 0 && dungeon[x, y - 1] == 1)
            {
                option = "LEFT";
                options.Add(option);
            }
            if (y < numCols - 1 && dungeon[x, y + 1] == 1)
            {
                option = "RIGHT";
                options.Add(option);
            }
            options.Add("EXIT");
            return options;
        }
        public static int[] changePosition(string direction, int[] newPostition)
        {
            if (direction == "UP")
                newPostition[0]++;
            if (direction == "DOWN")
                newPostition[0]++;
            if (direction == "LEFT")
                newPostition[1]--;
            if (direction == "RIGHT")
                newPostition[1]++;
            return newPostition;
        }
    }
}
