using System;
using System.Collections.Generic;
using System.Text;

namespace ForestKeeper
{
    public static class SpriteManager
    {
        public static int[] Time(int seconds)
        {
            Tuple<int, int> a = spriteXY(seconds%60 % 10);
            Tuple<int, int> b = spriteXY(seconds%60 / 10 % 10);
            Tuple<int, int> c = spriteXY(seconds/60  % 10);
            Tuple<int, int> d = spriteXY(seconds/60 / 10 % 10);
            return new int[] { d.Item1, d.Item2, c.Item1, c.Item2, b.Item1, b.Item2, a.Item1, a.Item2 };
        }
        public static int[] Number(int num)
        {
            Tuple<int, int> a = spriteXY(num % 10);
            Tuple<int, int> b = spriteXY(num / 10 % 10);
            Tuple<int, int> c = spriteXY(num / 100 % 10);
            Tuple<int, int> d = spriteXY(num / 1000 % 10);
            return new int[] { d.Item1, d.Item2, c.Item1, c.Item2, b.Item1, b.Item2, a.Item1, a.Item2 };
        }
        private static Tuple<int,int> spriteXY(int a)
        {
            if(a<5)
            {
                return new Tuple<int,int>(a % 5 * 102,0);
            }
            else
            {
                return new Tuple<int, int>(a % 5 * 102, 142);
            }
        }
    }
}
