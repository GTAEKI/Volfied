using System;
using static System.Formats.Asn1.AsnWriter;

namespace MemoryOfVolfied
{
	public class Scene
	{
        public void ScorePointScore(string[,] mapBasic, float successRate,int score, int highScore)
        {

            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.WriteLine("°                                                                             °");
            Console.WriteLine("°        MY SCORE               SUCCESS RATE                HIGH SCORE        °");
            Console.WriteLine("°                                                                             °");
            Console.WriteLine("°                                                                             °");
            Console.SetCursorPosition(11, 4);
            Console.Write("{0,6}", score);
            Console.SetCursorPosition(36, 4);
            Console.Write("{0,3:0.#}%", successRate);
            Console.SetCursorPosition(63, 4);
            Console.WriteLine("{0,6}", highScore);
            Console.WriteLine("°                                                                             °");
        }

        public void StartScene()
		{
			Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│  ┌──┐                                                                ┌──┐  │");
            Console.WriteLine("│  └┐ └┐      ┌──┐                                          ┌──┐      ┌┘ ┌┘  │");
            Console.WriteLine("│   └┐ └┐    ┌┘ ┌┘┌────────┐┌─┐      ┌───────┐ ┌─┐ ┌───────┐└┐ └┐    ┌┘ ┌┘   │");
            Console.WriteLine("│    └┐ └┐  ┌┘ ┌┘ │ ┌────┐ ││ │      │ ┌─────┘ │ │ │ ┌─────┘ └┐ └┐  ┌┘ ┌┘    │");
            Console.WriteLine("│ ≡≡≡≡└┐ └┐≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡┌┘ ┌┘≡≡≡≡ │");
            Console.WriteLine("│      └┐ └┘ ┌┘   │ │    │ ││ │      │ ┌─────┘ │ │ │ ┌─────┘   └┐ └┘ ┌┘      │");
            Console.WriteLine("│       └┐  ┌┘    │ └────┘ ││ └─────┐│ │       │ │ │ └─────┐    └┐  ┌┘       │");
            Console.WriteLine("│        └──┘     └────────┘└───────┘└─┘       └─┘ └───────┘     └──┘        │");
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
            Console.WriteLine("│                         >>   Press anykey   <<                             │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("│                                                                            │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────┘");


            Console.ReadKey();
		}

        public void GameClear()
        {
            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.WriteLine("°          ┌───────┐  ┌─┐        ┌───────┐      ┌──┐      ┌───────┐          °");
            Console.WriteLine("°          │ ┌─────┘  │ │        │ ┌─────┘     ┌┘  └┐     │  ┌─┐  │          °");
            Console.WriteLine("°          │ │        │ │        │ └─────┐    ┌┘┌──┐└┐    │  └─┘  │          °");
            Console.WriteLine("°          │ │        │ │        │ ┌─────┘   ┌┘ └──┘ └┐   │  ┌┐  ┐┘          °");
            Console.WriteLine("°          │ └─────┐  │ └─────┐  │ └─────┐  ┌┘  ┌──┐  └┐  │  │└┐ └┐          °");
            Console.WriteLine("°          └───────┘  └───────┘  └───────┘  └───┘  └───┘  └──┘ └──┘          °");
            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");



            //Console.WriteLine("°                                                                            °");
            //Console.WriteLine("°                                                                            °");
            //Console.WriteLine("°                                                                            °");
            //Console.WriteLine("°                                                                            °");
            //Console.WriteLine("°                                                                            °");
            //Console.WriteLine("°                                                                            °");
            //Console.WriteLine("°                                                                            °");
            //Console.WriteLine("°                                                                            °");
            //Console.WriteLine("°                                                                            °");
            //Console.WriteLine("°                                                                            °");
            //Console.WriteLine("°                                                                            °");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("│                                                                            │");
            //Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");


            Console.ReadKey();
        }

        public void GameOverScene()
        {
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
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────┘");


            Console.ReadKey();
        }

        public void ScoreRecordScene()
        {
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
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────┘");


            Console.ReadKey();
        }

        public void RoundScene()
        {
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
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────┘");


            Console.ReadKey();
        }
    }
}

