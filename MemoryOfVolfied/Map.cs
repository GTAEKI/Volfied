using System;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Timers;

namespace MemoryOfVolfied
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


        //콘솔창에 배열에있는 맵을 프린트하여 보여주는 함수
        public void PrintMap(ref string[,] mapBasic)
        {     
            for (int y = 0; y < MAP_SIZE_Y; y++)
            {
                //Console.SetCursorPosition(0, y);
                for (int x = 0; x < MAP_SIZE_X; x++)
                {
                        Console.Write("{0} ", mapBasic[y, x]);
                }
                Console.WriteLine();
            }//for y
        }//printMap
        //콘솔창에 배열에 있는 맵을 프린트하여 보여주는 함수

        // 땅 점령률을 계산하는 함수
        public float CalculatePercent(string[,] mapBasic)
        {
            float count = 0;
            float percent = 0;
            float area = (MAP_SIZE_Y - 4) * (MAP_SIZE_X - 4);

            for (int y = 2; y < MAP_SIZE_Y-2; y++)
            {
                for(int x = 2; x< MAP_SIZE_X-2; x++)
                {
                    if (mapBasic[y,x]== "▣"|| mapBasic[y, x] == "♀")
                    {
                        count += 1;
                    }
                }
            }

            percent = (count / area) * 100;

            return percent;
        }
        // 땅 점령률을 계산하는 함수

        // 점수 계산하는 함수
        public int CalculateScore(string[,] mapBasic,ref int remainCount)
        {
            int count = 0;
            int score_ = 0;
            int area = (MAP_SIZE_Y - 4) * (MAP_SIZE_X - 4);


            for (int y = 2; y < MAP_SIZE_Y - 2; y++)
            {
                for (int x = 2; x < MAP_SIZE_X - 2; x++)
                {
                    if (mapBasic[y, x] == "▣"|| mapBasic[y, x] == "♀")
                    {
                        count += 1;
                    }
                }
            }

            count -= remainCount;

            //점수 계산 공식
            if(count < area*1/100)
            {
                score_ = count * 2;
            }
            else if(count < area * 5 / 100)
            {
                score_ = count * 150;
            }
            else if(count < area * 8 / 100)
            {
                score_ = count * 500;
            }
            else if (count < area * 15 / 100)
            {
                score_ = count * 700;
            }
            else if (count < area * 30 / 100)
            {
                score_ = count * 1530;
            }
            else if (count < area * 50 / 100)
            {
                score_ = count * 3200;
            }
            else
            {
                score_ = count * 5000;
            }
            //점수 계산 공식

            remainCount += count;

            return score_;
        }
        // 점수 계산하는 함수
	}
}

