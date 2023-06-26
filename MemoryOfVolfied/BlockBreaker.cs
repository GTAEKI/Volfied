using System;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Timers;

namespace MemoryOfVofied
{
    public class BlockBreaker
    {
        const int MAP_SIZE_Y = 30;
        const int MAP_SIZE_X = 40;


        public void Move(ConsoleKeyInfo key, ref string[,] mapBasic, ref int myLocationX,ref int myLocationY) // 구성 생각 필요
        {
            Random random = new Random();
            

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
                        //if (mapBasic[myLocationY, myLocationX + 1] == " " && mapBasic[myLocationY, myLocationX - 1] == " ")
                        //{
                        //    mapBasic[myLocationY - 1, myLocationX] = "♀";
                        //    mapBasic[myLocationY, myLocationX] = "⊙";
                        //    myLocationY -= 1;
                        //    ResetMap(ref mapBasic);
                        //    break;
                        //}

                        //else if(mapBasic[myLocationY, myLocationX + 1] == "▣"||mapBasic[myLocationY, myLocationX - 1] == "▣"|| mapBasic[myLocationY, myLocationX + 1] == "⊙" || mapBasic[myLocationY, myLocationX - 1] == "⊙")
                        //{//문제있는 라인
                        //    mapBasic[myLocationY - 1, myLocationX] = "♀";
                        //    mapBasic[myLocationY, myLocationX] = "⊙";
                        //    myLocationY -= 1;
                        //    break;
                        //}
                        ResetMap(ref mapBasic);

                        swap(ref mapBasic[myLocationY, myLocationX], ref mapBasic[myLocationY - 1, myLocationX]);
                        myLocationY -= 1;
                        break;

                    case "⊙":
                        if (mapBasic[myLocationY, myLocationX+1] == "▣" && mapBasic[myLocationY, myLocationX-1] == "▣")
                        {
                            mapBasic[myLocationY-1, myLocationX] = "♀";
                            mapBasic[myLocationY, myLocationX] = "▣";
                            myLocationY -= 1;
                            break;
                        }
                        
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
                        mapBasic[myLocationY, myLocationX-1] = "♀";
                        mapBasic[myLocationY, myLocationX] = "⊙";
                        myLocationX -= 1;
                        break;

                    case "▣":
                        //if (mapBasic[myLocationY-1, myLocationX] == " " && mapBasic[myLocationY+1, myLocationX] == " ")
                        //{
                        //    mapBasic[myLocationY, myLocationX-1] = "♀";
                        //    mapBasic[myLocationY, myLocationX] = "⊙";
                        //    myLocationX -= 1;
                        //    ResetMap(ref mapBasic);
                        //    break;
                        //}

                        //else if (mapBasic[myLocationY - 1, myLocationX] == "▣" || mapBasic[myLocationY + 1, myLocationX] == "▣"|| mapBasic[myLocationY - 1, myLocationX] == "⊙" || mapBasic[myLocationY + 1, myLocationX] == "⊙")
                        //{//문제있는 라인
                        //    mapBasic[myLocationY, myLocationX - 1] = "♀";
                        //    mapBasic[myLocationY, myLocationX] = "⊙";
                        //    myLocationX -= 1;
                        //    break;
                        //}
                        ResetMap(ref mapBasic);

                        swap(ref mapBasic[myLocationY, myLocationX], ref mapBasic[myLocationY, myLocationX-1]);
                        myLocationX -= 1;
                        break;
                    case "⊙":
                        if (mapBasic[myLocationY-1, myLocationX] == "▣" && mapBasic[myLocationY+1, myLocationX] == "▣")
                        {
                            mapBasic[myLocationY, myLocationX - 1] = "♀";
                            mapBasic[myLocationY, myLocationX] = "▣";
                            myLocationX -= 1;
                            break;
                        }
                        
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
                        mapBasic[myLocationY + 1, myLocationX] = "♀";
                        mapBasic[myLocationY, myLocationX] = "⊙";
                        myLocationY += 1;
                        break;

                    case "▣":
                        //if (mapBasic[myLocationY, myLocationX + 1] == " " && mapBasic[myLocationY, myLocationX - 1] == " ")
                        //{
                        //    mapBasic[myLocationY + 1, myLocationX] = "♀";
                        //    mapBasic[myLocationY, myLocationX] = "⊙";
                        //    myLocationY += 1;
                        //    ResetMap(ref mapBasic);
                        //    break;
                        //}

                        //else if (mapBasic[myLocationY, myLocationX + 1] == "▣" || mapBasic[myLocationY, myLocationX - 1] == "▣"|| mapBasic[myLocationY, myLocationX + 1] == "⊙" || mapBasic[myLocationY, myLocationX - 1] == "⊙")
                        //{//문제있는 라인
                        //    mapBasic[myLocationY + 1, myLocationX] = "♀";
                        //    mapBasic[myLocationY, myLocationX] = "⊙";
                        //    myLocationY += 1;
                        //    break;
                        //}
                        ResetMap(ref mapBasic);

                        swap(ref mapBasic[myLocationY, myLocationX], ref mapBasic[myLocationY + 1, myLocationX]);
                        myLocationY += 1;
                        break;
                    case "⊙":
                        if (mapBasic[myLocationY, myLocationX + 1] == "▣" && mapBasic[myLocationY, myLocationX - 1] == "▣")
                        {
                            mapBasic[myLocationY + 1, myLocationX] = "♀";
                            mapBasic[myLocationY, myLocationX] = "▣";
                            myLocationY += 1;
                            break;
                        }
                      
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
                        mapBasic[myLocationY, myLocationX + 1] = "♀";
                        mapBasic[myLocationY, myLocationX] = "⊙";
                        myLocationX += 1;
                        break;

                    case "▣":
                        

                        //if (mapBasic[myLocationY+1, myLocationX] == " " && mapBasic[myLocationY-1, myLocationY] == " ")
                        //{
                        //    mapBasic[myLocationY, myLocationX+1] = "♀";
                        //    mapBasic[myLocationY, myLocationX] = "⊙";
                        //    myLocationX += 1;
                        //    ResetMap(ref mapBasic);
                        //    break;
                        //}

                        //else if (mapBasic[myLocationY + 1, myLocationX] == "▣" || mapBasic[myLocationY - 1, myLocationY] == "▣"|| mapBasic[myLocationY + 1, myLocationX] == "⊙" || mapBasic[myLocationY - 1, myLocationY] == "⊙")
                        //{//문제있는 라인
                        //    mapBasic[myLocationY, myLocationX + 1] = "♀";
                        //    mapBasic[myLocationY, myLocationX] = "⊙";
                        //    myLocationX += 1;
                        //    break;
                        //}
                        ResetMap(ref mapBasic);

                        swap(ref mapBasic[myLocationY, myLocationX], ref mapBasic[myLocationY, myLocationX + 1]);
                        myLocationX += 1;
                        break;

                    case "⊙":
                        if (mapBasic[myLocationY+1, myLocationX] == "▣" && mapBasic[myLocationY-1, myLocationX] == "▣")
                        {
                            mapBasic[myLocationY, myLocationX+1] = "♀";
                            mapBasic[myLocationY, myLocationX] = "▣";
                            myLocationX += 1;
                            break;
                        }
                        
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

        public void ResetMap(ref string[,] mapBasic) // 다시 기존 벽으로 돌아갔을때 땅 따먹기
        {
            int bossLocationY = 0, bossLocationX = 0;
            int firstX = 0, secondX = 0;

            for (int y = 1; y < MAP_SIZE_Y; y++) // 보스몬스터 위치로 땅 따먹은 부분 체크용
            {
                for (int x = 1; x < MAP_SIZE_X; x++)
                {
                    if (mapBasic[y, x] == "Ω")
                    {
                        bossLocationY = y;
                        bossLocationX = x;
                    }
                }//for x
            }//for y


           for(int x = 1; x < MAP_SIZE_X; x++)
            {
                if (mapBasic[bossLocationY,x] == "⊙"&& mapBasic[bossLocationY, x+1] == "⊙")
                {
                    
                    for(int x2 = x; x2<MAP_SIZE_X; x2++)
                    {
                        if(mapBasic[bossLocationY, x] == "⊙" && mapBasic[bossLocationY, x + 1] == " ")
                        {
                            
                        }
                    }
                }
                //다음 순서 
                //else if (mapBasic[bossLocationY, x] == "⊙" && mapBasic[bossLocationY, x + 1] == "⊙")
                //{

                //    for (int x2 = x; x2 < MAP_SIZE_X; x2++)
                //    {
                //        if (mapBasic[bossLocationY, x] == "⊙" && mapBasic[bossLocationY, x + 1] == " ")
                //        {

                //        }
                //    }
                //}
            }
        }//ResetMap();


        //이전 버전
        //public void ResetMap(ref string[,] mapBasic) // 다시 기존 벽으로 돌아갔을때 땅 따먹기
        //{
        //    int bossLocationY = 0, bossLocationX = 0;

        //    for (int y = 1; y < MAP_SIZE_Y; y++) // 보스몬스터 위치로 땅 따먹은 부분 체크용
        //    {
        //        for (int x = 1; x < MAP_SIZE_X; x++)
        //        {
        //            if (mapBasic[y, x] == "Ω")
        //            {
        //                bossLocationY = y;
        //                bossLocationX = x;
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
    }
}

