using System;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Timers;

namespace MemoryOfVofied
{
	public class Map
	{

        const int MAP_SIZE_Y = 30;
        const int MAP_SIZE_X = 40;

        // 초기 맵 배열에 벽과 보스, 내 캐릭터를 입력하는 함수
        public virtual void CreateMap(ref string[,] mapBasic, ref int myLocationX, ref int myLocationY)
		{
            Random rand = new Random();
            int randomY = rand.Next(2, MAP_SIZE_Y-2);
            int randomX = rand.Next(2, MAP_SIZE_X-2);

            for (int y = 0; y < MAP_SIZE_Y+1; y++)
            {
                for (int x = 0; x < MAP_SIZE_X+1; x++)
                {
                    if (x == 0 || x == MAP_SIZE_X - 1 || y == 0 || y == MAP_SIZE_Y - 1)
                    {
                        mapBasic[y, x] = "°";
                    }
                    else if (x == 1 || x == MAP_SIZE_X-2 || y == 1 || y == MAP_SIZE_Y-2)
                    {
                        if(y==1 && x == MAP_SIZE_X/2)
                        {
                            mapBasic[y, x] = "♀";
                            myLocationX = x;
                            myLocationY = y;
                        }
                        else
                        {
                            mapBasic[y, x] = "▣";
                        }
                    }
                    else if(y == randomY && x == randomX)
                    {
                        mapBasic[y, x] = "Ω";
                    }
                    else
                    {
                        mapBasic[y, x] = " ";
                    }
                }
            }//for y
        }//createMap
        // 초기 맵 배열에 벽과 보스, 내 캐릭터를 입력하는 함수

        //적군을 랜덤으로 생성하는 함수
        public void MakeEnemy(ref string[,] mapBasic)
        {
            Random rand = new Random();
            int count = 0;

            while (count < 50)
            {
                int randomY = rand.Next(0, MAP_SIZE_Y);
                int randomX = rand.Next(0, MAP_SIZE_X);

                bool isDuplicate = false;

                if (mapBasic[randomY, randomX] == "▣" || mapBasic[randomY, randomX] == "♀")
                {
                    isDuplicate = true;

                }

                if (!isDuplicate)
                {
                    mapBasic[randomY, randomX] = "Ω";
                    count += 1;
                }
            }//while
        }//MakeEnemy
        //적군을 랜덤으로 생성하는 함수

        //콘솔창에 배열에있는 맵을 프린트하여 보여주는 함수
        public void PrintMap(ref string[,] mapBasic)
        {
            for (int y = 0; y < MAP_SIZE_Y; y++)
            {
                for (int x = 0; x < MAP_SIZE_X; x++)
                {
                    if (mapBasic[y,x] == "ж")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", mapBasic[y, x]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("{0} ", mapBasic[y, x]);
                    }
                }
                Console.WriteLine();
            }//for y
        }//printMap
        //콘솔창에 배열에 있는 맵을 프린트하여 보여주는 함수

           
	}
}

