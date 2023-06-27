using System;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Timers;

namespace MemoryOfVolfied
{
    internal class Program
    {
        static Map firstRoundMap = new Map(); //첫번째 라운드 맵 객체 생성
        
        const int MAP_SIZE_Y = 20;
        const int MAP_SIZE_X = 40;
        static string[,] mapBasic = new string[MAP_SIZE_Y+1, MAP_SIZE_X+1];
        static int bossLocationY = 0, bossLocationX = 0;
        //static Random random = default;
        static Direction bossDirection = default;


        static bool IsClockwise = true;

        enum Direction
        {
            UPPER_LEFT,
            UPPER_RIGHT,
            BOTTOM_LEFT,
            BOTTOM_RIGHT
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo key = default;
            bossDirection = Direction.UPPER_LEFT;
            
            int myLocationY = 0, myLocationX = 0;

            BlockBreaker blockBreaker = new BlockBreaker(); // 주인공 캐릭터 생성
            
            firstRoundMap.CreateMap(ref mapBasic, ref myLocationY, ref myLocationX); // 맵 배열에 초기값 입력

            System.Threading.Timer time = new System.Threading.Timer(MoveMonster, null, 10, 50);

            while (true)
            {
                Console.Clear();
                //Console.SetCursorPosition(0, 0);
                firstRoundMap.PrintMap(ref mapBasic); // 콘솔에 반복 출력
                key = Console.ReadKey(true); //키입력
                blockBreaker.Move(key,ref mapBasic, ref myLocationY, ref myLocationX); // 주인공 캐릭터 움직임                
            }//while
        }//Main

        static void MoveMonster(object place)
        {            
            Console.SetCursorPosition(0,0);
            firstRoundMap.PrintMap(ref mapBasic);

            for (int y = 0; y < MAP_SIZE_Y + 1; y++)
            {
                for (int x = 0; x < MAP_SIZE_X + 1; x++)
                {
                    if (mapBasic[y,x]== "Ω")
                    {
                        switch (bossDirection)
                        {
                            case Direction.UPPER_LEFT:
                                if (IsClockwise == true)//보스가 시계방향으로 돌고있는가
                                {
                                    if (mapBasic[y,x-1] == "▣") // 바로 왼쪽에 벽이 있다면 반시계로 변경
                                    {
                                        IsClockwise = false;
                                        bossDirection = Direction.UPPER_RIGHT;
                                        return;
                                    }

                                    switch (mapBasic[y - 1, x - 1])
                                    {
                                        case "▣":
                                            bossDirection = Direction.BOTTOM_LEFT;
                                            return;
                                        case " ":
                                            mapBasic[y, x] = " ";                                            
                                            mapBasic[y-1, x-1] = "Ω";
                                            return;
                                        case "⊙":
                                            return;
                                    }                            
                                }
                                else if(IsClockwise == false) //반시계 방향으로 도는중
                                {
                                    if (mapBasic[y-1, x] == "▣") // 바로 위쪽에 벽이 있다면 시계방향으로 변경
                                    {
                                        IsClockwise = true;
                                        bossDirection = Direction.BOTTOM_LEFT;
                                        return;
                                    }

                                    switch (mapBasic[y - 1, x - 1])
                                    {
                                        case "▣":
                                            bossDirection = Direction.UPPER_RIGHT;
                                            return;
                                        case " ":
                                            mapBasic[y, x] = " ";
                                            mapBasic[y - 1, x - 1] = "Ω";
                                            return;
                                        case "⊙":
                                            return;
                                    }
                                }
                                return;
                            case Direction.BOTTOM_LEFT:
                                if (IsClockwise == true)//보스가 시계방향으로 돌고있는가
                                {
                                    if (mapBasic[y+1, x] == "▣") // 바로 아래쪽에 벽이 있다면 반시계로 변경
                                    {
                                        IsClockwise = false;
                                        bossDirection = Direction.UPPER_LEFT;
                                        return;
                                    }

                                    switch (mapBasic[y + 1, x - 1])
                                    {
                                        case "▣":
                                            bossDirection = Direction.BOTTOM_RIGHT;
                                            return;
                                        case " ":
                                            mapBasic[y, x] = " ";
                                            mapBasic[y + 1, x - 1] = "Ω";
                                            return;
                                        case "⊙":
                                            return;
                                    }
                                }
                                else if (IsClockwise == false)//보스가 반시계방향이면
                                {
                                    if (mapBasic[y, x-1] == "▣") // 바로 아래쪽에 벽이 있다면 반시계로 변경
                                    {
                                        IsClockwise = true;
                                        bossDirection = Direction.BOTTOM_RIGHT;
                                        return;
                                    }

                                    switch (mapBasic[y + 1, x - 1])
                                    {
                                        case "▣":
                                            bossDirection = Direction.UPPER_LEFT;
                                            return;
                                        case " ":
                                            mapBasic[y, x] = " ";
                                            mapBasic[y + 1, x - 1] = "Ω";
                                            return;
                                        case "⊙":
                                            return;
                                    }
                                }
                                return;
                            case Direction.BOTTOM_RIGHT:
                                if (IsClockwise == true)//보스가 시계방향으로 돌고있는가
                                {
                                    if (mapBasic[y, x+1] == "▣") // 바로 오른쪽에 벽이 있다면 반시계로 변경
                                    {
                                        IsClockwise = false;
                                        bossDirection = Direction.BOTTOM_LEFT;
                                        return;
                                    }

                                    switch (mapBasic[y + 1, x + 1])
                                    {
                                        case "▣":
                                            bossDirection = Direction.UPPER_RIGHT;
                                            return;
                                        case " ":
                                            mapBasic[y, x] = " ";
                                            mapBasic[y + 1, x + 1] = "Ω";
                                            return;
                                        case "⊙":
                                            return;
                                    }
                                }
                                else if (IsClockwise == false)//보스가 반시계로 돌고있는가
                                {
                                    if (mapBasic[y+1,x] == "▣") // 바로 아래쪽에 벽이 있다면 시계로 변경
                                    {
                                        IsClockwise = true;
                                        bossDirection = Direction.UPPER_RIGHT;
                                        return;
                                    }

                                    switch (mapBasic[y + 1, x + 1])
                                    {
                                        case "▣":
                                            bossDirection = Direction.BOTTOM_LEFT;
                                            return;
                                        case " ":
                                            mapBasic[y, x] = " ";
                                            mapBasic[y + 1, x + 1] = "Ω";
                                            return;
                                        case "⊙":
                                            return;
                                    }
                                }
                                return;                                
                            case Direction.UPPER_RIGHT:
                                if (IsClockwise == true)//보스가 시계방향으로 돌고있는가
                                {
                                    if (mapBasic[y-1, x] == "▣") // 바로 위쪽에 벽이 있다면 반시계로 변경
                                    {
                                        IsClockwise = false;
                                        bossDirection = Direction.BOTTOM_RIGHT;
                                        return;
                                    }

                                    switch (mapBasic[y - 1, x + 1])
                                    {
                                        case "▣":
                                            bossDirection = Direction.UPPER_LEFT;
                                            return;
                                        case " ":
                                            mapBasic[y, x] = " ";
                                            mapBasic[y - 1, x + 1] = "Ω";
                                            return;
                                        case "⊙":
                                            return;
                                    }
                                }
                                else if (IsClockwise == false)//보스가 반시계방향으로 돌고있는가
                                {
                                    if (mapBasic[y, x+1] == "▣") // 바로 오른쪽에 벽이 있다면 반시계로 변경
                                    {
                                        IsClockwise = true;
                                        bossDirection = Direction.UPPER_LEFT;
                                        return;
                                    }

                                    switch (mapBasic[y - 1, x + 1])
                                    {
                                        case "▣":
                                            bossDirection = Direction.BOTTOM_RIGHT;
                                            return;
                                        case " ":
                                            mapBasic[y, x] = " ";
                                            mapBasic[y - 1, x + 1] = "Ω";
                                            return;
                                        case "⊙":
                                            return;
                                    }
                                }
                                return;
                        }  
                    }
                }
            }//for y
        }// MoveMonster
    }//Program
}//nameSpace