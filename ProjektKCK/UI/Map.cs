using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    class Map
    {
        public static int[,] CreatMap(int[,] map)
        {
            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int kontrolkaFirst = 0;
                    int[] pom = new int[5];
                    Random rand = new Random();
                    int randomNumber = rand.Next(2);
                    if(i == 0)
                    {
                        if(randomNumber == 1)
                        {
                            kontrolkaFirst = 1;
                        }
                        else if(randomNumber == 0 && kontrolkaFirst==0 && j==5)
                        {
                            randomNumber = 1;
                        }
                    }
                    if (pom[j] == 1 && pom[j-1] != 1 && pom[j+1] != 1)
                    {
                        map[i, j] = 1;
                        pom[j] = 1;
                    } else
                    {
                        map[i, j] = randomNumber;
                        pom[j] = randomNumber;
                    }
                    
                    
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
            return map;
        }
    }
}
