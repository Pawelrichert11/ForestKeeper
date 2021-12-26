using System;
using System.Collections.Generic;
using System.Text;

namespace ForestKeeper
{
    class Engine
    {
        public int[,] treesLocation; //gives us information, where the trees are
        public List<Tree> trees;
        private readonly Random _random;
        public Engine()
        {
            ///<summary> this piece of code generates random starting trees
            treesLocation = new int[Constants.TreesHorizontally,Constants.TreesVertically];
            trees = new List<Tree>();
            _random = new Random();
            int i = 0;
            Tuple<int, int> g;
            while(i<Constants.NumberOfStartingTrees)
            {
                g = GenerateRandom();
                if(treesLocation[g.Item1,g.Item2] != 1)
                {
                    treesLocation[g.Item1, g.Item2] = 1;
                    trees.Add(new Tree(g.Item1, g.Item2));
                    i++;
                }
            }
            ///</summary>
        }
        private Tuple<int,int> GenerateRandom() //picks a random tree from an array
        {
            return new Tuple<int,int>(_random.Next(Constants.TreesHorizontally), _random.Next(Constants.TreesVertically));
        }
        public int PickATree() //picks a random tree from a list
        {
            return _random.Next(trees.Count);
        }
        public int RandomInt(int n) //returns a random int
        {
            return _random.Next(n);
        }
        public bool InfectATree()
        {
            int i = PickATree();
            int a = i;
            while(trees[a].state!=0)
            {
                a = (a + 1) % trees.Count;
                if (a == i) return false;
            }
            trees[a].Infect();
            return true;
        }
    }
}
