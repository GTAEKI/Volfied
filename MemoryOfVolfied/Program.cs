using System;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Timers;
using static System.Formats.Asn1.AsnWriter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.IO;

namespace MemoryOfVolfied
{
    internal class Program
    {
        static Map firstRoundMap = new Map(); //첫번째 라운드 맵 객체 생성
        static Scene sceneManager = new Scene(); //Scene관리 객체
        static List<int> scoreRecord = new List<int>(); // Score 리스트에 저장(정렬을 위해서 사용)
        static Dictionary<int, string> infoRecord = new Dictionary<int,string>(); // key값 을 score로 저장후, 닉네임을 value
        static System.Threading.Timer timer; //타이머 선언
        static bool lose = false; // lose 변수 (아래쪽

        static string name = default;
        static int score = default, remaincount = default, highScore = default;
        static float successRate = default;
        const int MAP_SIZE_Y = 30;
        const int MAP_SIZE_X = 40;
        static string[,] mapBasic = new string[MAP_SIZE_Y+1, MAP_SIZE_X+1];
        static Direction bossDirection = default;

        static bool IsClockwise = true;

        static string json = System.IO.File.ReadAllText(@"/Users/baekyungtaek/Programer/c_shap/Volfied/path.txt");
        static List<data> _data = JsonConvert.DeserializeObject<List<data>>(json);

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
            if(_data != null)
            {
                foreach (var item in _data)
                {
                    // 데이터 접근 예시
                    scoreRecord = item.score_;
                    infoRecord = item.infoRecord_;
                }
            }

            sceneManager.StartScene();
            //Console.SetWindowSize(MAP_SIZE_X*2, MAP_SIZE_Y); //window에서 플레이할때 (mac에서 지원 안함)

            while (true)// game restart
            {
                ConsoleKeyInfo key = default;
                Console.CursorVisible = false; //window에서 플레이할때 의미있음, mac에서 지원 안함
                bossDirection = Direction.UPPER_LEFT; // 첫 시작은 왼쪽 위로 날아가며 시작
            
                int myLocationY = 0, myLocationX = 0;
                remaincount = 0;

                BlockBreaker blockBreaker = new BlockBreaker(); // 주인공 캐릭터 생성
            
                firstRoundMap.CreateMap(ref mapBasic, ref myLocationY, ref myLocationX); // 맵 배열에 초기값 입력

                timer = new System.Threading.Timer(MoveMonster, null, 10, 100); // 몬스터 움직임 및 맵 출력 함수 타이머로 실행
                                                                                // 타이머 속도 조절로 게임 난이도도 조절 가능
                while (true) //내 움직임을 위한 무한 루프 승리 또는 패배시 탈출
                {
                    successRate = firstRoundMap.CalculatePercent(mapBasic);
                    score += firstRoundMap.CalculateScore(mapBasic, ref remaincount);

                    //승리조건
                    if (successRate > 80) 
                    {
                        StopTimer();
                        sceneManager.GameClear();
                        // 게임 승리시 리스트에 점수 추가
                        sceneManager.ScoreRecordScene(ref name,ref score, ref scoreRecord, ref infoRecord, ref _data);

                        break;
                    }//승리조건

                    //패배조건
                    else if (lose == true) 
                    {
                        StopTimer();
                        sceneManager.GameOverScene();
                        // 게임 패배시 리스트에 점수 추가
                        sceneManager.ScoreRecordScene(ref name, ref score, ref scoreRecord, ref infoRecord, ref _data);
                        lose = false;

                        break;
                    }//패배조건

                    if (scoreRecord.Count >= 1 && scoreRecord[0] > score)
                    {
                        highScore = scoreRecord[0]; //하이스코어 입력
                    }
                    else {
                    highScore = score; //하이스코어 입력
                    }

                    key = Console.ReadKey(true); // 키입력
                    blockBreaker.Move(key,ref mapBasic, ref myLocationY, ref myLocationX, ref lose); // 주인공 캐릭터 움직임
                }//while
            }
        }//Main

        // 타이머 정지 함수
        static void StopTimer() 
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
        // 타이머 정지 함수

        //보스 움직임 구현 (타이머 실행)
        static void MoveMonster(object place)
        {
            Console.Clear();
            sceneManager.ScorePointScore(mapBasic, successRate, score, highScore);
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
                                        case "♀":                         
                                        case "⊙":
                                            lose = true;
                                            //sceneManager.GameOverScene();
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
                                            lose = true;
                                            //sceneManager.GameOverScene();
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
                                            lose = true;
                                            //sceneManager.GameOverScene();
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
                                            lose = true;
                                            //sceneManager.GameOverScene();
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
                                            lose = true;
                                            //sceneManager.GameOverScene();
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
                                            lose = true;
                                            //sceneManager.GameOverScene();
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
                                            lose = true;
                                            //sceneManager.GameOverScene();
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
                                            lose = true;
                                            //sceneManager.GameOverScene();
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
        //보스 움직임 구현 (타이머 실행)
    }//Program
}//nameSpace