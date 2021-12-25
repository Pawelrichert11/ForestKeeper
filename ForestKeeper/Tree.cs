using System;
using System.Collections.Generic;
using System.Text;

namespace ForestKeeper
{
    class Tree
    {
        public int state; //0 - standing 1 - infected 2 - trunk
        public int x, y, realX, realY;
        public Tree()
        {
            state = 0;
            x = realX = 0;
            y = realY = 0;
        }
        public Tree(int x, int y)
        {
            this.x = x;
            this.y = y;
            realX = x * Constants.TreeIntervalX + Constants.GameBorderLeft;
            realY = y * Constants.TreeIntervalY + Constants.GameBorderTop;
            state = 0;
        }
        public bool CheckClick(int a, int b)
        {
            if( (a>realX) &&
                (a<realX+Constants.TreeWidth) &&
                (b>realY) &&
                (b<realY+Constants.TreeHeight) )
            {
                this.state = 1;
                return true;
            }
            return false;
        }
    }
}
