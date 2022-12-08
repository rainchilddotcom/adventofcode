using _0;

namespace _8
{
    public class TreeHeightMap
        : Map<Tree>
    {
        public TreeHeightMap(string[] input)
            : base(input)
        {
            ScanTrees();
            CalculateScenicValues();
        }

        private void ScanTrees()
        {
            for (int y = 0; y < Height; y++)
            {
                int tallestN = -1;
                int tallestS = -1;
                int tallestE = -1;
                int tallestW = -1;

                for (int x = 0; x < Width; x++)
                {
                    var westTree = this[x, y];
                    if (tallestW < westTree.Z)
                    {
                        tallestW = westTree.Z;
                        westTree.VisibleFrom |= Direction.West;
                    }

                    var eastTree = this[Width - x - 1, y];
                    if (tallestE < eastTree.Z)
                    {
                        tallestE = eastTree.Z;
                        eastTree.VisibleFrom |= Direction.East;
                    }

                    var northTree = this[y, x];
                    if (tallestN < northTree.Z)
                    {
                        tallestN = northTree.Z;
                        northTree.VisibleFrom |= Direction.North;
                    }

                    var southTree = this[y, Height - 1 - x];
                    if (tallestS < southTree.Z)
                    {
                        tallestS = southTree.Z;
                        southTree.VisibleFrom |= Direction.South;
                    }
                }
            }
        }

        private void CalculateScenicValues()
        {
            foreach (var tree in this.AsEnumerable())
            {
                if (tree.X == 0 || tree.X == Width - 1 || tree.Y == 0 || tree.Y == Height - 1)
                    continue; // trees on the edges get a zero score

                var northTree = this[tree.X, tree.Y - 1];
                while (northTree.Y > 0 && northTree.Z < tree.Z)
                    northTree = this[northTree.X, northTree.Y - 1];

                var southTree = this[tree.X, tree.Y + 1];
                while (southTree.Y < Height - 1 && southTree.Z < tree.Z)
                    southTree = this[southTree.X, southTree.Y + 1];

                var eastTree = this[tree.X + 1, tree.Y];
                while (eastTree.X < Width - 1 && eastTree.Z < tree.Z)
                    eastTree = this[eastTree.X + 1, eastTree.Y];

                var westTree = this[tree.X - 1, tree.Y];
                while (westTree.X > 0 && westTree.Z < tree.Z)
                    westTree = this[westTree.X - 1, westTree.Y];

                tree.ScenicScore =
                    Math.Abs(tree.Y - northTree.Y) *
                    Math.Abs(tree.Y - southTree.Y) *
                    Math.Abs(tree.X - eastTree.X) *
                    Math.Abs(tree.X - westTree.X);
            }
        }

        protected override Tree ConstructValue(int x, int y, string input)
        {
            return new Tree(x, y, Convert.ToInt32(input));
        }

        public int TotalVisibleTrees
        {
            get
            {
                return this.AsEnumerable().Where(x => x.Visible).Count();
            }
        }

    }
}
