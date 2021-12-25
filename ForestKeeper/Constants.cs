using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestKeeper
{
    public static class Constants
    {
        public static int TreesHorizontally = 19; //number of trees horizontally
        public static int TreesVertically = 5; //number of trees vertically
        public static int gameWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; //actual screen width
        public static int gameHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; //actual screen height
        public static int TreeWidth = 79; //width of a tree
        public static int TreeHeight = 97; //height of a tree
        public static int GameBorderLeft = 100;
        public static int GameBorderRight = 100;
        public static int GameBorderTop = 190;
        public static int GameBorderDown = 100;
        public static int TreeIntervalY = gameHeight / 7; //distance between trees vertically
        public static int TreeIntervalX = gameWidth / 21; //distance between trees horizontally
        public static int NumberOfStartingTrees = 16;
    }
}
