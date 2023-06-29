using System;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Timers;

namespace MemoryOfVolfied
{
    public class BlockBreaker
    {
        const int MAP_SIZE_Y = 30;
        const int MAP_SIZE_X = 40;

        // 내 캐릭터 움직이는 함수
        public void Move(ConsoleKeyInfo key, ref string[,] mapBasic, ref int myLocationX,ref int myLocationY, ref bool lose)
        {
            Random random = new Random();
            int bossX = 0, bossY = 0;
            

            if (key.KeyChar == 'W' || key.KeyChar == 'w')
            {
                switch (mapBasic[myLocationY - 1, myLocationX])
                {
                    case " ":
                        if (mapBasic[myLocationY, myLocationX + 1] == "▣" && mapBasic[myLocationY, myLocationX - 1] == "▣")
                        {
                            mapBasic[myLocationY - 1, myLocationX] = "♀";
                            mapBasic[myLocationY, myLocationX] = "▣";
                            myLocationY -= 1;
                            break;
                        }

                        mapBasic[myLocationY - 1, myLocationX] = "♀";
                        mapBasic[myLocationY, myLocationX] = "⊙";
                        myLocationY -= 1;
                            break;

                    case "▣":                     
                        if (mapBasic[myLocationY, myLocationX + 1] == " " && mapBasic[myLocationY, myLocationX - 1] == " ")
                        {
                            mapBasic[myLocationY - 1, myLocationX] = "♀";
                            mapBasic[myLocationY, myLocationX] = "⊙";
                            myLocationY -= 1;
                            CheckPoint(mapBasic, ref bossY, ref bossX);
                            mapBasic[bossY, bossX] = " ";
                            FloodFill(mapBasic, bossY, bossX, "▶");
                            mapBasic[bossY, bossX] = "Ω";
                            ChangeWall(ref mapBasic, " ", "⊙");
                            ChangeWall(ref mapBasic, "▶", " ");
                            ChangeWall(ref mapBasic, "⊙", "▣");
                            break;
                        }
                       
                        swap(ref mapBasic[myLocationY, myLocationX], ref mapBasic[myLocationY - 1, myLocationX]);
                        myLocationY -= 1;
                        CheckPoint(mapBasic, ref bossY, ref bossX);
                        mapBasic[bossY, bossX] = " ";
                        FloodFill(mapBasic, bossY, bossX, "▶");
                        mapBasic[bossY, bossX] = "Ω";
                        ChangeWall(ref mapBasic, " ", "⊙");
                        ChangeWall(ref mapBasic, "▶", " ");
                        ChangeWall(ref mapBasic, "⊙", "▣");
                        break;

                    case "Ω":
                        lose = true;
                        break;

                    default:
                        //Console.WriteLine("움직일 수 없습니다.");
                        break;
                }
            }
            else if (key.KeyChar == 'A' || key.KeyChar == 'a')
            {

                switch (mapBasic[myLocationY, myLocationX-1])
                {
                    case " ":
                        if (mapBasic[myLocationY-1, myLocationX] == "▣" && mapBasic[myLocationY+1, myLocationX] == "▣")
                        {
                            mapBasic[myLocationY, myLocationX-1] = "♀";
                            mapBasic[myLocationY, myLocationX] = "▣";
                            myLocationX -= 1;
                            break;
                        }
                        mapBasic[myLocationY, myLocationX-1] = "♀";
                        mapBasic[myLocationY, myLocationX] = "⊙";
                        myLocationX -= 1;
                        break;

                    case "▣":
                        if (mapBasic[myLocationY - 1, myLocationX] == " " && mapBasic[myLocationY + 1, myLocationX] == " ")
                        {
                            mapBasic[myLocationY, myLocationX - 1] = "♀";
                            mapBasic[myLocationY, myLocationX] = "⊙";
                            myLocationX -= 1;
                            CheckPoint(mapBasic, ref bossY, ref bossX);
                            mapBasic[bossY, bossX] = " ";
                            FloodFill(mapBasic, bossY, bossX, "▶");
                            mapBasic[bossY, bossX] = "Ω";
                            ChangeWall(ref mapBasic, " ", "⊙");
                            ChangeWall(ref mapBasic, "▶", " ");
                            ChangeWall(ref mapBasic, "⊙", "▣");
                            break;
                        }

                        swap(ref mapBasic[myLocationY, myLocationX], ref mapBasic[myLocationY, myLocationX-1]);
                        myLocationX -= 1;
                        CheckPoint(mapBasic, ref bossY, ref bossX);
                        mapBasic[bossY, bossX] = " ";
                        FloodFill(mapBasic, bossY, bossX, "▶");
                        mapBasic[bossY, bossX] = "Ω";
                        ChangeWall(ref mapBasic, " ", "⊙");
                        ChangeWall(ref mapBasic, "▶", " ");
                        ChangeWall(ref mapBasic, "⊙", "▣");
                        break;


                    case "Ω":
                        lose = true;
                        break;

                    default:
                        //Console.WriteLine("움직일 수 없습니다.");
                        break;
                }
            }
            else if (key.KeyChar == 'S' || key.KeyChar == 's')
            {
                switch (mapBasic[myLocationY + 1, myLocationX])
                {
                    case " ":
                        if (mapBasic[myLocationY, myLocationX + 1] == "▣" && mapBasic[myLocationY, myLocationX - 1] == "▣")
                        {
                            mapBasic[myLocationY + 1, myLocationX] = "♀";
                            mapBasic[myLocationY, myLocationX] = "▣";
                            myLocationY += 1;
                            break;
                        }
                        mapBasic[myLocationY + 1, myLocationX] = "♀";
                        mapBasic[myLocationY, myLocationX] = "⊙";
                        myLocationY += 1;
                        break;

                    case "▣":
                        if (mapBasic[myLocationY, myLocationX + 1] == " " && mapBasic[myLocationY, myLocationX - 1] == " ")
                        {
                            mapBasic[myLocationY + 1, myLocationX] = "♀";
                            mapBasic[myLocationY, myLocationX] = "⊙";
                            myLocationY += 1;
                            CheckPoint(mapBasic, ref bossY, ref bossX);
                            mapBasic[bossY, bossX] = " ";
                            FloodFill(mapBasic, bossY, bossX, "▶");
                            mapBasic[bossY, bossX] = "Ω";
                            ChangeWall(ref mapBasic, " ", "⊙");
                            ChangeWall(ref mapBasic, "▶", " ");
                            ChangeWall(ref mapBasic, "⊙", "▣");
                            break;
                        }

                        swap(ref mapBasic[myLocationY, myLocationX], ref mapBasic[myLocationY + 1, myLocationX]);
                        myLocationY += 1;
                        CheckPoint(mapBasic, ref bossY, ref bossX);
                        mapBasic[bossY, bossX] = " ";
                        FloodFill(mapBasic, bossY, bossX, "▶");
                        mapBasic[bossY, bossX] = "Ω";
                        ChangeWall(ref mapBasic, " ", "⊙");
                        ChangeWall(ref mapBasic, "▶", " ");
                        ChangeWall(ref mapBasic, "⊙", "▣");
                        break;

                    case "Ω":
                        lose = true;
                        break;

                    default:
                        //Console.WriteLine("움직일 수 없습니다.");
                        break;
                }

            }
            else if (key.KeyChar == 'D' || key.KeyChar == 'd')
            {
                switch (mapBasic[myLocationY, myLocationX + 1])
                {
                    case " ":

                        if (mapBasic[myLocationY+1, myLocationX] == "▣" && mapBasic[myLocationY-1, myLocationX] == "▣")
                        {
                            mapBasic[myLocationY, myLocationX + 1] = "♀";
                            mapBasic[myLocationY, myLocationX] = "▣";
                            myLocationX += 1;
                            break;
                        }
                        mapBasic[myLocationY, myLocationX + 1] = "♀";
                        mapBasic[myLocationY, myLocationX] = "⊙";
                        myLocationX += 1;
                        break;

                    case "▣":
                        if (mapBasic[myLocationY + 1, myLocationX] == " " && mapBasic[myLocationY - 1, myLocationY] == " ")
                        {
                            mapBasic[myLocationY, myLocationX + 1] = "♀";
                            mapBasic[myLocationY, myLocationX] = "⊙";
                            myLocationX += 1;
                            CheckPoint(mapBasic, ref bossY, ref bossX);
                            mapBasic[bossY, bossX] = " ";
                            FloodFill(mapBasic, bossY, bossX, "▶");
                            mapBasic[bossY, bossX] = "Ω";
                            ChangeWall(ref mapBasic, " ", "⊙");
                            ChangeWall(ref mapBasic, "▶", " ");
                            ChangeWall(ref mapBasic, "⊙", "▣");
                            break;
                        }
                      
                        swap(ref mapBasic[myLocationY, myLocationX], ref mapBasic[myLocationY, myLocationX + 1]);
                        myLocationX += 1;
                        CheckPoint(mapBasic, ref bossY, ref bossX);
                        mapBasic[bossY, bossX] = " ";
                        FloodFill(mapBasic, bossY, bossX, "▶");
                        mapBasic[bossY, bossX] = "Ω";
                        ChangeWall(ref mapBasic, " ", "⊙");
                        ChangeWall(ref mapBasic, "▶", " ");
                        ChangeWall(ref mapBasic, "⊙", "▣");
                        break;

                    case "Ω":
                        lose = true;
                        break;

                    default:
                        //Console.WriteLine("움직일 수 없습니다.");
                        break;
                }
            }
        }
        // 내 캐릭터 움직이는 함수

        // 스왑 함수
        private void swap(ref string ptr, ref string ptr2)
        {
            string temp = "0";
            temp = ptr;
            ptr = ptr2;
            ptr2 = temp;
        }
        // 스왑 함수

        // Flood Fill 알고리즘 {
        private void FloodFill(string[,] mapBasic, int bossY, int bossX, string targetMark)
        {
            string originalMark = " ";

            // 시작 위치가 타겟 마크와 동일하거나 시작 위치가 맵 배열 범위를 벗어나면 중지
            if (originalMark == targetMark || bossX < 0 || bossX >= MAP_SIZE_X || bossY < 0 || bossY >= MAP_SIZE_Y)
                return;

            Fill( mapBasic, bossX, bossY, targetMark, originalMark);
        }
        private void Fill(string[,] mapBasic, int x, int y, string targetMark, string originalMark)
        {
            // 현재 위치가 배열범위를 벗어나거나 현재 위치의 모양이 originalMark가 아니면 중지
            if (x < 0 || x >= MAP_SIZE_X || y < 0 || y >= MAP_SIZE_Y || mapBasic[y, x] != originalMark)
                return;

            // 현재 위치의 모양을 targetMark로 변경
            mapBasic[y, x] = targetMark;

            // 상하좌우로 재귀적으로 호출
            Fill( mapBasic, x + 1, y, targetMark, originalMark); // 오른쪽
            Fill( mapBasic, x - 1, y, targetMark, originalMark); // 왼쪽
            Fill( mapBasic, x, y + 1, targetMark, originalMark); // 위쪽
            Fill( mapBasic, x, y - 1, targetMark, originalMark); // 아래쪽
        }
        // } Flood Fill 알고리즘


        // 벽을 교체해주는 함수, find에 들어온 기호를 replace기호로 변경{
        private void ChangeWall(ref string[,] mapBasic, string find, string replace)
        {
            for (int y = 1; y < MAP_SIZE_Y; y++)
            {
                for (int x = 1; x < MAP_SIZE_X; x++)
                {
                    if (mapBasic[y, x] == find)
                    {
                        mapBasic[y, x] = replace;
                    }
                }//for x
            }//for y
        }//ChangeWall
        // } 벽을 교체해주는 함수, find에 들어온 기호를 replace기호로 변경

        // 적 보스 포인(x,y)위치값을 저장해주는 함수{
        private void CheckPoint(string[,] mapBasic, ref int bossY, ref int bossX)
        {
            // 보스몬스터 위치 저장{
            for (int y = 0; y < MAP_SIZE_Y; y++)
            {
                for (int x = 0; x < MAP_SIZE_X; x++)
                {
                    if (mapBasic[y, x] == "Ω")
                    {
                        bossY = y;
                        bossX = x;
                        return;
                    }
                }//for x
            }//for y
             // }보스몬스터 위치 저장         
        }//CheckPoint
        // } 적 보스 포인(x,y)위치값을 저장해주는 함수

    }
}

