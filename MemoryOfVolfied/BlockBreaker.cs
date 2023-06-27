using System;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Timers;

namespace MemoryOfVolfied
{
    public class BlockBreaker
    {
        const int MAP_SIZE_Y = 20;
        const int MAP_SIZE_X = 40;

        enum BossPlace
        {
            IS_INSIDE,
            IS_OUTSIDE,
            IS_LEFT,
            IS_RIGHT
        }


        public void Move(ConsoleKeyInfo key, ref string[,] mapBasic, ref int myLocationX,ref int myLocationY) // 구성 생각 필요
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
                        else if (mapBasic[myLocationY - 2, myLocationX] == "⊙" || mapBasic[myLocationY -1, myLocationX + 1] == "⊙" || mapBasic[myLocationY - 1, myLocationX - 1] == "⊙")
                        {
                            break;
                        }
                        mapBasic[myLocationY - 1, myLocationX] = "♀";
                        mapBasic[myLocationY, myLocationX] = "⊙";
                        myLocationY -= 1;
                            break;

                    case "▣":
                        //0.1.1 에서 살림
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
                        //0.1.1 에서 살림

                        //else if(mapBasic[myLocationY, myLocationX + 1] == "▣"||mapBasic[myLocationY, myLocationX - 1] == "▣"|| mapBasic[myLocationY, myLocationX + 1] == "⊙" || mapBasic[myLocationY, myLocationX - 1] == "⊙")
                        //{//문제있는 라인
                        //    mapBasic[myLocationY - 1, myLocationX] = "♀";
                        //    mapBasic[myLocationY, myLocationX] = "⊙";
                        //    myLocationY -= 1;
                        //    break;
                        //}


                        //v0.1.2
                        //ResetMap(ref mapBasic);
                        //v0.1.2

                       

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




                    case "Ω": // 게임오버 추후 처리 필요
                        Console.WriteLine("보스와 만나서 사망");
                        Thread.Sleep(3000);
                        break;

                    default:
                        Console.WriteLine("움직일 수 없습니다.");
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
                        else if (mapBasic[myLocationY, myLocationX-2] == "⊙" || mapBasic[myLocationY - 1, myLocationX - 1] == "⊙" || mapBasic[myLocationY + 1, myLocationX - 1] == "⊙")
                        {
                            break;
                        }
                        mapBasic[myLocationY, myLocationX-1] = "♀";
                        mapBasic[myLocationY, myLocationX] = "⊙";
                        myLocationX -= 1;
                        break;

                    case "▣":
                        // 0.1.1 에서 살림
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
                        //0.1.1 에서 살림

                        //else if (mapBasic[myLocationY - 1, myLocationX] == "▣" || mapBasic[myLocationY + 1, myLocationX] == "▣"|| mapBasic[myLocationY - 1, myLocationX] == "⊙" || mapBasic[myLocationY + 1, myLocationX] == "⊙")
                        //{//문제있는 라인
                        //    mapBasic[myLocationY, myLocationX - 1] = "♀";
                        //    mapBasic[myLocationY, myLocationX] = "⊙";
                        //    myLocationX -= 1;
                        //    break;
                        //}

                        //v0.1.2
                        //ResetMap(ref mapBasic);
                        //v0.1.2

                        

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


                    case "Ω": //처리필요
                        Console.WriteLine("보스와 만나서 사망");
                        Thread.Sleep(3000);
                        break;
                    default:
                        Console.WriteLine("움직일 수 없습니다.");
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
                        else if (mapBasic[myLocationY+2, myLocationX] == "⊙" || mapBasic[myLocationY + 1, myLocationX + 1] == "⊙" || mapBasic[myLocationY + 1, myLocationX - 1] == "⊙")
                        {
                            break;
                        }
                        mapBasic[myLocationY + 1, myLocationX] = "♀";
                        mapBasic[myLocationY, myLocationX] = "⊙";
                        myLocationY += 1;
                        break;

                    case "▣":
                        //0.1.1 에서 살림
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
                        //0.1.1 에서 살림

                        //else if (mapBasic[myLocationY, myLocationX + 1] == "▣" || mapBasic[myLocationY, myLocationX - 1] == "▣"|| mapBasic[myLocationY, myLocationX + 1] == "⊙" || mapBasic[myLocationY, myLocationX - 1] == "⊙")
                        //{//문제있는 라인
                        //    mapBasic[myLocationY + 1, myLocationX] = "♀";
                        //    mapBasic[myLocationY, myLocationX] = "⊙";
                        //    myLocationY += 1;
                        //    break;
                        //}

                        //v0.1.2
                        //ResetMap(ref mapBasic);
                        //v0.1.2

                        

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

                    case "Ω": //처리필요
                        Console.WriteLine("보스와 만나서 사망");
                        Thread.Sleep(3000);
                        break;
                    default:
                        Console.WriteLine("움직일 수 없습니다.");
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
                        else if (mapBasic[myLocationY,myLocationX+2] == "⊙" || mapBasic[myLocationY+1, myLocationX + 1] == "⊙" || mapBasic[myLocationY - 1, myLocationX + 1] == "⊙")
                        {
                            break;
                        }
                        mapBasic[myLocationY, myLocationX + 1] = "♀";
                        mapBasic[myLocationY, myLocationX] = "⊙";
                        myLocationX += 1;
                        break;

                    case "▣":

                        //0.1.1 에서 살림
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
                        //0.1.1 에서 살림
                      
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

                    case "Ω": //처리필요
                        Console.WriteLine("보스와 만나서 사망");
                        Thread.Sleep(3000);
                        break;
                    default:
                        Console.WriteLine("움직일 수 없습니다.");
                        break;
                }
            }
        }

        private void swap(ref string ptr, ref string ptr2)
        {
            string temp = "0";
            temp = ptr;
            ptr = ptr2;
            ptr2 = temp;
        }



        private void FloodFill( string[,] canvas, int startY, int startX, string targetColor)
        {
            string originalColor = " ";

            // 시작 위치가 타겟 컬러와 동일하거나 시작 위치가 캔버스 범위를 벗어나면 중지
            if (originalColor == targetColor || startX < 0 || startX >= MAP_SIZE_X || startY < 0 || startY >= MAP_SIZE_Y)
                return;

            Fill( canvas, startX, startY, targetColor, originalColor);
        }

        private void Fill( string[,] canvas, int x, int y, string targetColor, string originalColor)
        {
            // 현재 위치가 캔버스 범위를 벗어나거나 현재 위치의 색이 originalColor가 아니면 중지
            if (x < 0 || x >= MAP_SIZE_X || y < 0 || y >= MAP_SIZE_Y || canvas[y, x] != originalColor)
                return;

            // 현재 위치의 색을 targetColor로 변경
            canvas[y, x] = targetColor;

            // 상하좌우로 재귀적으로 호출
            Fill( canvas, x + 1, y, targetColor, originalColor); // 오른쪽
            Fill( canvas, x - 1, y, targetColor, originalColor); // 왼쪽
            Fill( canvas, x, y + 1, targetColor, originalColor); // 위쪽
            Fill( canvas, x, y - 1, targetColor, originalColor); // 아래쪽
        }

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
        }







        //v0.1.2
        public void ResetMap(ref string[,] mapBasic) // 다시 기존 벽으로 돌아갔을때 땅 따먹기
        {
            int bossY = 0, bossX = 0;
            int compareX = 0;
            int saveX = 0;
            int firstX = 0, secondX = 0;
            int firstY = 0, secondY = 0;
            bool isSameLineY = default, isSameLineX = default;

            BossPlace bossPlace = default;

            // 보스몬스터 위치 저장{
            for (int y = 1; y < MAP_SIZE_Y; y++) 
            {
                for (int x = 1; x < MAP_SIZE_X; x++)
                {
                    if (mapBasic[y, x] == "Ω")
                    {
                        bossY = y;
                        bossX = x;
                    }
                }//for x
            }//for y
             // }보스몬스터 위치 저장



            //v0.1.2
            //isSameLineY = IsSameLineY(ref mapBasic,bossY, ref compareX);
            //if (isSameLineY == true)
            //{
            //    if (bossX > compareX)
            //    {
            //        for(int y = 0; MAP_SIZE_Y > y; y++)
            //        {
            //            for(int x = MAP_SIZE_X; x > 0; x--)
            //            {
            //                if (mapBasic[y,x] == "⊙")
            //                {
            //                    mapBasic[y, x] = "▣";
            //                    while (true)
            //                    {                                    
            //                        if (mapBasic[y,x-1] == "⊙")
            //                        {
            //                            mapBasic[y, x - 1] = "▣";
            //                            if (mapBasic[y, x-2]==" ")
            //                            {  // 공백일때 y축 기준으로 쭉 내렸을때                                         {
            //                                //while (true)
            //                                //{ y-=1;
            //                                //    mapBasic[y,x-2]=
            //                                //}
            //                                break;
            //                            }
            //                            else if(mapBasic[y, x - 2] == "▣" || mapBasic[y, x - 2] == "♀")
            //                            {
            //                                break;
            //                            }
            //                        }
            //                        else if (mapBasic[y,x-1] == " ")
            //                        {
            //                            mapBasic[y, x-1] = "▣";
            //                        }
            //                        else if (mapBasic[y,x-1]== "▣")
            //                        {
            //                            break;
            //                        }
            //                        x -= 1;                                    
            //                    }
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}//isSameLineY true
            //v0.1.2


            //v0.1.1
            //if (isSameLineY == true)
            //{
            //    if (bossX > compareX)
            //    {
            //        for (int x = 1; MAP_SIZE_X > x; x++)
            //        {
            //            for (int y = 2; y < MAP_SIZE_Y - 1; y++)
            //            {
            //                if (mapBasic[y, x] == "⊙")
            //                {
            //                    if (mapBasic[y, x] == "♀")
            //                    {
            //                        continue;
            //                    }
            //                    mapBasic[y, x] = "▣";
            //                }
            //            }
            //        }
            //    }
            //}//isSameLineY true
            //v0.1.1



            //v0.1.0
            //// 보스몬스터 위치에 다른 수행
            //switch (bossPlace)
            //{
            //    case BossPlace.IS_INSIDE:
            //        Console.SetCursorPosition(5, 5);
            //        Console.WriteLine("IS INSIDE");
            //        break;
            //    case BossPlace.IS_OUTSIDE:
            //        Console.SetCursorPosition(5, 5);
            //        Console.WriteLine("IS OUTSIDE");
            //        break;
            //    case BossPlace.IS_LEFT:
            //        Console.SetCursorPosition(5, 5);
            //        Console.WriteLine("IS LEFT");
            //        break;
            //    case BossPlace.IS_RIGHT:
            //        Console.SetCursorPosition(5, 5);
            //        Console.WriteLine("IS RIGHT");
            //        break;
            //    default:
            //        break;
            //}//switch
            //// 보스몬스터 위치에 다른 수행
            //v0.1.0

        }//ResetMap();
        //v0.1.2

        //v0.1.1, v0.1.2
        //bool IsSameLineY(ref string[,] mapBasic,int bossY,ref int compareX) // y값 기준 같은 라인에 동그라미가 있다면 true, 아니면 false
        //{

        //    for (int x = 2; x < MAP_SIZE_X - 1; x++)
        //    {
        //        if (mapBasic[bossY, x] == "⊙")
        //        {
        //            compareX = x;
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //v0.1.1, v0.1.2




        //0.1.0
        //이전 버전
        //public void ResetMap(ref string[,] mapBasic) // 다시 기존 벽으로 돌아갔을때 땅 따먹기
        //{
        //    int bossY = 0, bossX = 0;

        //    for (int y = 1; y < MAP_SIZE_Y; y++) // 보스몬스터 위치로 땅 따먹은 부분 체크용
        //    {
        //        for (int x = 1; x < MAP_SIZE_X; x++)
        //        {
        //            if (mapBasic[y, x] == "Ω")
        //            {
        //                bossY = y;
        //                bossX = x;
        //            }
        //        }//for x
        //    }//for y


        //    for (int y = 1; y < MAP_SIZE_Y; y++)
        //    {
        //        for (int x = 1; x < MAP_SIZE_X; x++)
        //        {
        //            if (mapBasic[y, x] == "⊙")
        //            {
        //                mapBasic[y, x] = "▣";

        //                //"⊙"를 y기준으로 순차적으로 돌려서 처음 만나면 x값을 저장
        //                //"▣"를 처음 만나는 순간 x값을 저장
        //                //그 x값과 x값 사이를 전부 "▣"로 변경
        //                //
        //                //"⊙" " " " ""⊙"인 경우는
        //                // 다음 "⊙" 를 만날때 x값을 저장
        //                //
        //                //
        //            }
        //        }//for x
        //    }//for y
        //}//ResetMap();
        //0.1.0
    }
}

