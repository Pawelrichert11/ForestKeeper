using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForestKeeper
{
    class Tree
    {
        public int state; //0 - standing 1 - infected 2 - trunk 3 - seedling
        public int x, y, realX, realY;
        public static int Trees;
        public static int AliveTrees;
        public Tree()
        {
            state = 0;
            x = realX = 0;
            y = realY = 0;
            Trees += 1;
            AliveTrees += 1;
        }
        public Tree(int x, int y)
        {
            this.x = x;
            this.y = y;
            realX = x * Constants.TreeIntervalX + Constants.GameBorderLeft;
            realY = y * Constants.TreeIntervalY + Constants.GameBorderTop;
            state = 0;
        }
        public async Task Infect()
        {
            state = 1;
            await Task.Delay(1000);
            if (state == 1)
            {
                state = 2;
                AliveTrees -= 1;
            }
        }
        public async Task Grow()
        {
            await Task.Delay(3000);
            state = 0;
        }
        public bool Heal()
        {
            if (state == 1) {
                state = 0;
                return true;
            }
            else return false;
        }
        public bool CheckClick(int a, int b)
        {
            if( (a>realX) &&
                (a<realX+Constants.TreeWidth) &&
                (b>realY) &&
                (b<realY+Constants.TreeHeight) )
            {
                return Heal();
            }
            return false;
        }
    }
}
