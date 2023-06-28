using System;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Timers;
using static System.Formats.Asn1.AsnWriter;

namespace MemoryOfVolfied
{
    internal class Program
    {
        static Map firstRoundMap = new Map(); //첫번째 라운드 맵 객체 생성
        static Scene sceneManager = new Scene(); //Scene관리 객체

        static int score = default, remaincount = default, highScore = default;
        static float successRate = default;
        const int MAP_SIZE_Y = 30;
        const int MAP_SIZE_X = 40;
        static string[,] mapBasic = new string[MAP_SIZE_Y+1, MAP_SIZE_X+1];
        static Direction bossDirection = default;

        static bool IsClockwise = true;

        //보스몹 움직이는 방향
        enum Direction
        {
            UPPER_LEFT,
            UPPER_RIGHT,
            BOTTOM_LEFT,
            BOTTOM_RIGHT
        }
        //보스몹 움직이는 방향

        static void Main(string[] args)
        {
            //Console.SetWindowSize(MAP_SIZE_X*2, MAP_SIZE_Y); //window에서 플레이할때 (mac에서 지원 안함)

            ConsoleKeyInfo key = default;
            Console.CursorVisible = false; //window에서 플레이할때 의미있음, mac에서 지원 안함
            bossDirection = Direction.UPPER_LEFT;
            
            int myLocationY = 0, myLocationX = 0;

            BlockBreaker blockBreaker = new BlockBreaker(); // 주인공 캐릭터 생성
            

            sceneManager.StartScene();
            firstRoundMap.CreateMap(ref mapBasic, ref myLocationY, ref myLocationX); // 맵 배열에 초기값 입력

            System.Threading.Timer time = new System.Threading.Timer(MoveMonster, null, 10, 70);

            while (true)
            {
                Console.Clear();
                successRate = firstRoundMap.CalculatePercent(mapBasic);
                score += firstRoundMap.CalculateScore(mapBasic, ref remaincount);
                sceneManager.ScorePointScore(mapBasic,successRate, score, highScore);
                //Console.WriteLine("{0}", firstRoundMap.CalculatePoint(mapBasic));
                firstRoundMap.PrintMap(ref mapBasic); // 콘솔에 반복 출력
                key = Console.ReadKey(true); //키입력
                blockBreaker.Move(key,ref mapBasic, ref myLocationY, ref myLocationX); // 주인공 캐릭터 움직임
                if(successRate > 80)
                {
                    sceneManager.GameClear();
                }
            }//while
        }//Main

        //보스 움직임 구현 (타이머에 맞춰서 실행)
        static void MoveMonster(object place)
        {
            Console.Clear();
            sceneManager.ScorePointScore(mapBasic, successRate, score, highScore);
            firstRoundMap.PrintMap(ref mapBasic);

            if (successRate > 80)
            {
                sceneManager.GameClear();
            }

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
                                        case "♀":                         
                                        case "⊙":
                                            sceneManager.GameOverScene();
                                            return;
                                        default:
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
                                        case "♀":
                                        case "⊙":
                                            sceneManager.GameOverScene();
                                            return;
                                        default:
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
                                        case "♀":
                                        case "⊙":
                                            sceneManager.GameOverScene();
                                            return;
                                        default:
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
                                        case "♀":
                                        case "⊙":
                                            sceneManager.GameOverScene();
                                            return;
                                        default:
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
                                        case "♀":
                                        case "⊙":
                                            sceneManager.GameOverScene();
                                            return;
                                        default:
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
                                        case "♀":
                                        case "⊙":
                                            sceneManager.GameOverScene();
                                            return;
                                        default:
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
                                        case "♀":
                                        case "⊙":
                                            sceneManager.GameOverScene();
                                            return;
                                        default:
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
                                        case "♀":
                                        case "⊙":
                                            sceneManager.GameOverScene();
                                            return;
                                        default:
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