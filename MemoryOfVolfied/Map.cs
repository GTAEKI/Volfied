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
        Random random = new Random();

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
                    if (mapBasic[y,x] == "°")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0} ", mapBasic[y, x]);
                        Console.ResetColor();
                    }
                    else if (mapBasic[y, x] == "⊙")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        
                        Console.Write("{0} ", mapBasic[y, x]);
                        Console.ResetColor();
                    }
                    else if (mapBasic[y,x]== "▣")
                    {
                        // 여우그림 검정색 칠{
                        if ((y == 1 && (x == 10 || x == 11 || x == 28 || x == 29))
                            || (y == 2 && (x == 9 || x == 12 || x == 27 || x == 30))
                            || (y == 3 && (x == 9 || x == 13 || x == 15 || x == 16 || x == 18 || x == 19 || (x >= 23 && x <= 26) || x == 30))
                            || (y == 4 && (x == 9 || x == 14 || x == 17 || x == 20 || x == 22 || x == 25 || x == 30)
                            || (y == 5 && (x == 8 || x == 21 || x == 24 || x == 31))
                            || (y == 6 && (x == 8 || x == 31))
                            || (y == 7 && (x == 8 || x == 31))
                            || (y == 8 && (x == 8 || x == 31))
                            || (y == 9 && (x == 8 || x == 31))
                            || (y == 10 && (x == 8 || x == 31))
                            || (y == 11 && (x == 8 || x == 31 || (x >= 13 && x <= 16) || (x >= 23 && x <= 26)))
                            || (y == 12 && (x == 8 || x == 31 || x == 17 || x == 22))
                            || (y == 13 && (x == 9 || x == 30))
                            || (y == 14 && (x == 9 || x == 30))
                            || (y == 15 && (x == 9 || x == 30 || x == 19 || x == 20))
                            || (y == 16 && (x == 7 || x == 8 || x == 31 || x == 32))
                            || (y == 17 && (x == 7 || x == 32 || x == 13 || x == 26))
                            || (y == 18 && (x == 14 || x == 25 || x == 8 || x == 31))
                            || (y == 19 && (x == 8 || (x >= 15 && x <= 24) || x == 31))
                            || (y == 20 && (x == 9 || x == 30))
                            || (y == 21 && (x == 10 || x == 29))
                            || (y == 22 && (x == 11 || x == 28))
                            || (y == 23 && ((x >= 12 && x <= 16) || (x >= 23 && x <= 27)))
                            || (y == 24 && (x == 14 || x == 25))
                            || (y == 25 && (x == 13 || x == 26))
                            || (y == 26 && (x == 12 || x == 27))
                            || (y == 27 && (x == 11 || x == 28))
                            || (y == 28 && (x == 10 || x == 29))
                            ))
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("{0} ", mapBasic[y, x]);
                            Console.ResetColor();
                        }
                        //} 여우그림 검정색 칠

                        // 여우그림 노란색 칠{
                        else if ((y == 2 && (x == 10 || x == 11 || x == 28 || x == 29))
                            || (y == 3 && (x == 10 || x == 11 || x == 12 || x == 27 || x == 28 || x == 29))
                            || (y == 4 && (x == 10 || x == 13 || x == 15 || x == 16 || x == 18 || x == 19 || x ==23 || x ==24 || x ==26 || x ==29))
                            || (y == 5 && (x == 9 || x == 10||(x>=13&&x<=20) || x ==22 || x ==23 || x ==25 || x ==26 || x ==29 || x ==30))
                            || (y == 6 && (x == 9 || x == 10 || (x >= 13 && x <= 26)||x == 29 || x == 30))
                            || (y == 7 && (x == 9 ||(x >= 13 && x <= 26) || x == 30))
                            || (y == 8 && (x == 9 ||(x >= 11 && x <= 28) || x == 30))
                            || (y == 9 && (x >= 9 && x <= 30))
                            || (y == 10 && (x >= 9 && x <= 30))
                            || (y == 11 && ((x >= 9 && x <= 12)|| (x >= 17 && x <= 22)|| (x >= 27 && x <= 30)))
                            || (y == 12 && ((x >= 9 && x <= 16)|| (x >= 18 && x <= 21)|| (x >= 23 && x <= 30)))
                            || (y == 13 && (x >= 10 && x <= 29))
                            || (y == 14 && (x >= 10 && x <= 29))
                            || (y == 15 && ((x >= 10 && x <= 18)|| (x >= 21 && x <= 29)))
                            || (y == 23 && ((x >= 17 && x <= 18)|| (x >= 21 && x <= 22)))
                            || (y == 24 && ((x >= 15 && x <= 17)|| (x >= 22 && x <= 24)))
                            || (y == 25 && ((x >= 14 && x <= 16)|| (x >= 23 && x <= 25)))
                            || (y == 26 && ((x >= 13 && x <= 16)|| (x >= 23 && x <= 26)))
                            || (y == 27 && ((x >= 12 && x <= 16)|| (x >= 23 && x <= 27)))
                            || (y == 28 && ((x >= 11 && x <= 16)|| (x >= 23 && x <= 28)))
                            )
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write("{0} ", mapBasic[y, x]);
                            Console.ResetColor();
                        }
                        // }여우그림 노란색 칠

                        //흰색칠
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.White;

                            Console.Write("{0} ", mapBasic[y, x]);
                            Console.ResetColor();

                        }
                        
                    }
                    else if (mapBasic[y,x] == "♀")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0} ", mapBasic[y, x]);
                        Console.ResetColor();
                    }
                    else if (mapBasic[y,x] == "Ω")
                    {
                        switch (random.Next(4))
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            default:
                                break;
                        }
                        
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

        //콘솔창에 배열에있는 맵을 프린트하여 보여주는 함수
        public void BossPrintMap(ref string[,] mapBasic)
        {
            for (int y = 0; y < MAP_SIZE_Y; y++)
            {
                //Console.SetCursorPosition(0, y);
                for (int x = 0; x < MAP_SIZE_X; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (mapBasic[y,x]== "Ω")
                    {
                        
                        Console.Write("{0} ", mapBasic[y, x]);

                    }
                }
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

