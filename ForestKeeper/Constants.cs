using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestKeeper
{
    public static class Constants
    {
        public static int TreesHorizontally = 19; //number of trees horizontally
        public static int TreesVertically = 6; //number of trees vertically
        public static int gameWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; //actual screen width
        public static int gameHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; //actual screen height
        public static int insideFenceX = 1720;
        public static int insideFenceY = 730;
        public static int TreeWidth = 79; //width of a tree
        public static int TreeHeight = 97; //height of a tree
        public static int SeedlingWidth = 40; //width of a tree
        public static int SeedlingHeight = 60; //height of a tree
        public static int GameBorderLeft = 100;
        public static int GameBorderTop = 190;
        public static int TreeIntervalY = insideFenceY/TreesVertically; //distance between trees vertically
        public static int TreeIntervalX = insideFenceX/TreesHorizontally; //distance between trees horizontally
        public static int NumberOfStartingTrees = 13;

        public static float InfectionSpeed = 1.5f;

        public static Tuple<int, int> ClickPos = new Tuple<int, int>(170, 35);
        public static Tuple<int, int> PointPos = new Tuple<int, int>(650, 35);
        public static Tuple<int, int> TimePos = new Tuple<int, int>(1620, 35);

        public static Tuple<int, int> NumberSize = new Tuple<int, int>(45, 90);


    }
}
