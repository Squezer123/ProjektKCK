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
                for( int j = 0; j < 4; j++)
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


    }
}
