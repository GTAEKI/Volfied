using System;
using System.Diagnostics;
using System.Security.Cryptography;
using static System.Formats.Asn1.AsnWriter;

namespace MemoryOfVolfied
{
	public class Scene
	{
        public void ScorePointScore(string[,] mapBasic, float successRate, int score, int highScore)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.WriteLine("°                                                                             °");
            Console.Write("°        ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("MY SCORE");
            Console.Write("               SUCCESS RATE");
            Console.Write("               HIGH SCORE");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("         °");

            Console.WriteLine("°                                                                             °");

            Console.Write("°        ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0,7}", score);
            Console.Write("                     {0,3:0.#}%", successRate);
            Console.Write("                   {0,7}   ", highScore);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("        °");

            Console.WriteLine("°                                                                             °");
            Console.WriteLine("°                                                                             °");

            Console.WriteLine("°                                                                             °");
            Console.ResetColor();

        }

        public void StartScene()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────┘");
            Console.ResetColor();

            Console.SetCursorPosition(2, 10);
            Console.WriteLine(" ┌──┐                                                                ┌──┐ ");
            Console.SetCursorPosition(2, 11);
            Console.WriteLine(" └┐ └┐      ┌──┐                                          ┌──┐      ┌┘ ┌┘ ");
            Console.SetCursorPosition(2, 12);
            Console.WriteLine("  └┐ └┐    ┌┘ ┌┘┌────────┐┌─┐      ┌───────┐ ┌─┐ ┌───────┐└┐ └┐    ┌┘ ┌┘  ");
            Console.SetCursorPosition(2, 13);
            Console.WriteLine("   └┐ └┐  ┌┘ ┌┘ │ ┌────┐ ││ │      │ ┌─────┘ │ │ │ ┌─────┘ └┐ └┐  ┌┘ ┌┘   ");
            Console.SetCursorPosition(2, 14);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("≡≡≡≡     ≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡     ≡≡≡≡");
            Console.ResetColor();
            Console.SetCursorPosition(6, 14);
            Console.WriteLine("└┐ └┐");
            Console.SetCursorPosition(67, 14);
            Console.WriteLine("┌┘ ┌┘");
            Console.SetCursorPosition(2, 15);
            Console.WriteLine("     └┐ └┘ ┌┘   │ │    │ ││ │      │ ┌─────┘ │ │ │ ┌─────┘   └┐ └┘ ┌┘     ");
            Console.SetCursorPosition(2, 16);
            Console.WriteLine("      └┐  ┌┘    │ └────┘ ││ └─────┐│ │       │ │ │ └─────┐    └┐  ┌┘      ");
            Console.SetCursorPosition(2, 17);
            Console.WriteLine("       └──┘     └────────┘└───────┘└─┘       └─┘ └───────┘     └──┘       ");
            Console.SetCursorPosition(30, 27);
            Console.WriteLine(">> Press anykey <<");
            Console.ResetColor();

            Console.ReadKey();
		}

        public void GameClear()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.SetCursorPosition(10, 1);
            Console.WriteLine("┌───────┐  ┌─┐        ┌───────┐      ┌──┐      ┌───────┐");
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("│ ┌─────┘  │ │        │ ┌─────┘     ┌┘  └┐     │  ┌─┐  │");
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("│ │        │ │        │ └─────┐    ┌┘┌──┐└┐    │  └─┘  │");
            Console.SetCursorPosition(10, 4);
            Console.WriteLine("│ │        │ │        │ ┌─────┘   ┌┘ └──┘ └┐   │  ┌┐  ┐┘");
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("│ └─────┐  │ └─────┐  │ └─────┐  ┌┘  ┌──┐  └┐  │  │└┐ └┐");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("└───────┘  └───────┘  └───────┘  └───┘  └───┘  └──┘ └──┘");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.ResetColor();
        }

        public void GameOverScene()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.SetCursorPosition(16, 1);
            Console.WriteLine("┌─┐         ┌───────┐   ┌───────┐   ┌───────┐");
            Console.SetCursorPosition(16, 2);
            Console.WriteLine("│ │         │  ┌─┐  │   │ ┌─────┘   │ ┌─────┘");
            Console.SetCursorPosition(16, 3);
            Console.WriteLine("│ │         │  │ │  │   │ └─────┐   │ └─────┐");
            Console.SetCursorPosition(16, 4);
            Console.WriteLine("│ │         │  │ │  │   └─────┐ │   │ ┌─────┘");
            Console.SetCursorPosition(16, 5);
            Console.WriteLine("│ └─────┐   │  └─┘  │   ┌─────┘ │   │ └─────┐");
            Console.SetCursorPosition(16, 6);
            Console.WriteLine("└───────┘   └───────┘   └───────┘   └───────┘");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.ResetColor();
        }

        public void ScoreRecordScene(ref string name, ref int score, ref List<int> scoreRecord, ref Dictionary<int, string> infoRecord)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");                                
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°                                                                            °");
            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.ResetColor();


            scoreRecord.Sort();
            scoreRecord.Reverse();
           

            Console.SetCursorPosition(33, 18);
            Console.Write("SCORE");
            Console.SetCursorPosition(45, 18);
            Console.Write("NAME");
            Console.SetCursorPosition(23, 20);
            Console.Write("1st");
            Console.SetCursorPosition(23, 22);
            Console.Write("2st");
            Console.SetCursorPosition(23, 24);
            Console.Write("3st");
            Console.SetCursorPosition(23, 26);
            Console.Write("4st");
            Console.SetCursorPosition(23, 28);
            Console.Write("5st");
            Console.SetCursorPosition(23, 30);
            Console.Write("6st");

            for(int i = 0; i < scoreRecord.Count; i++)
            {
                Console.SetCursorPosition(32, (i*2)+20);
                Console.Write("{0}", scoreRecord[i]);
                Console.SetCursorPosition(45, (i*2)+20);
                Console.Write("{0}", infoRecord[scoreRecord[i]]);

            }


            scoreRecord.Add(score);
            Console.SetCursorPosition(28, 12);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ENTER YOUR INITIALS !!");
            Console.SetCursorPosition(23, 14);
            Console.WriteLine("SCORE : {0}",score);
            Console.SetCursorPosition(43, 14);
            Console.WriteLine("NAME : ");
            Console.SetCursorPosition(50, 14);
            name = Console.ReadLine();
            Console.ResetColor();
            infoRecord[score] = name;

            scoreRecord.Sort();
            scoreRecord.Reverse();

            for (int i = 0; i < scoreRecord.Count; i++)
            {
                Console.SetCursorPosition(32, (i * 2) + 20);
                Console.Write("                                      ");

            }

            for (int i = 0; i < scoreRecord.Count; i++)
            {
                Console.SetCursorPosition(32, (i * 2) + 20);
                Console.Write("{0}", scoreRecord[i]);
                Console.SetCursorPosition(45, (i * 2) + 20);
                Console.Write("{0}", infoRecord[scoreRecord[i]]);

            }

            score = 0;
            Console.ReadKey();


        }

        //public void RoundScene()
        //{
        //    Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────┐");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("│                                                                            │");
        //    Console.WriteLine("└────────────────────────────────────────────────────────────────────────────┘");


        //    Console.ReadKey();
        //}
    }
}



