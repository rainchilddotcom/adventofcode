using _0;
using System.Reflection.Emit;

namespace _14
{
    public class Cave
        : DynamicMap<PointAlpha>
    {
        public Cave()
            : base((x, y) => new PointAlpha(x, y, " "))
        {
        }

        public bool FoundAbyss { get; private set; }
        public int AbyssLevel { get; private set; }
        public int TotalSand { get { return this.AsEnumerable().Where(x => x.Z == "o").Count(); } }
        public List<Point2D> Spawners { get; } = new List<Point2D>();

        public void AddSpawner(int x, int y)
        {
            this[x, y].Z = "+";
            Spawners.Add(new Point2D(x, y));
            AbyssLevel = this.Height + 2;
        }

        public void AddFloor()
        {
            var floorHeight = this.Height + 1;
            var floorLeft = this.Spawners.Min(x => x.X) - floorHeight - 1;
            var floorRight = this.Spawners.Max(x => x.X) + floorHeight + 2;
            for (int x = floorLeft; x < floorRight; x++)
                this[x, floorHeight].Z = "#";
        }

        public List<PointAlpha> SpawnSand()
        {
            var spawned = new List<PointAlpha>();
            foreach (var spawner in Spawners)
            {
                if (this[spawner.X, spawner.Y].Z != "o" && this[spawner.X, spawner.Y].Z != "~")
                {
                    this[spawner.X, spawner.Y].Z = "s";
                    spawned.Add(this[spawner.X, spawner.Y]);
                }
            }
            return spawned;
        }

        public int SettleSand(List<PointAlpha> fallingBlocks)
        {
            var moved = 0;
            foreach (var block in fallingBlocks)
            {
                bool settled = false;
                while (!settled)
                {
                    if (!TryMove(block, 0) && !TryMove(block, -1) && !TryMove(block, 1))
                    {
                        this[block.X, block.Y].Z = FoundAbyss ? " " : "o";
                        settled = true;
                    }
                    else
                    {
                        moved++;
                    }
                }
            }
            return moved;
        }

        private bool TryMove(PointAlpha block, int offsetX)
        {
            if (block.Y > AbyssLevel)
            {
                this[block.X, block.Y].Z = " ";
                FoundAbyss = true;
                return false;
            }

            var targetBlock = this[block.X + offsetX, block.Y + 1];
            if (targetBlock.Z == " ")
            {
                this.Swap(block, targetBlock);
                targetBlock.Z = FoundAbyss ? "~" : " ";
                block.Z = "s";
                return true;
            }

            return false;
        }

        public void FillCavern()
        {
            while (true)
            {
                var sand = SpawnSand();
                if (sand.Count == 0)
                    return;
                SettleSand(sand);
            }
        }

        public override string RenderMap()
        {
            foreach (var spawner in Spawners)
            {
                if (this[spawner.X, spawner.Y].Z != "o")
                {
                    this[spawner.X, spawner.Y].Z = "+";
                }
            }

            return base.RenderMap();
        }
    }
}
