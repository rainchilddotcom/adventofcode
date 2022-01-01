using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13
{
    public class Paper
    {
        public Paper(string[] input)
        {
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("fold along"))
                {
                    Folds.Enqueue(line);
                }
                else
                {
                    var split = line.Split(',');
                    int x = Convert.ToInt32(split[0]);
                    int y = Convert.ToInt32(split[1]);
                    int layer = 0;

                    Dots.Add(new Dot(x, y, layer));
                }
            }

            MaxX = Dots.Max(dot => dot.X);
            MaxY = Dots.Max(dot => dot.Y);
        }

        public Queue<string> Folds { get; } = new Queue<string>();
        public List<Dot> Dots { get; } = new List<Dot>();
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        public void Fold()
        {
            var fold = Folds.Dequeue().Split('=');
            var offset = Convert.ToInt32(fold[1]);

            if (fold[0].EndsWith("x"))
            {
                // vertical fold
                var impactedDots = Dots.Where(dot => dot.X > offset).ToList();
                foreach (var impactedDot in impactedDots)
                {
                    var newX = offset - (impactedDot.X - offset);

                    var existingDot = Dots.Where(dot => dot.X == newX && dot.Y == impactedDot.Y).SingleOrDefault();
                    if (existingDot != null)
                    {
                        existingDot.Layer++;
                        Dots.Remove(impactedDot);
                    }
                    else
                    {
                        impactedDot.X = newX;
                    }
                }

                MaxX = offset - 1;
            }
            else
            {
                // horizontal fold
                var impactedDots = Dots.Where(dot => dot.Y > offset).ToList();
                foreach (var impactedDot in impactedDots)
                {
                    var newY = offset - (impactedDot.Y - offset);

                    var existingDot = Dots.Where(dot => dot.Y == newY && dot.X == impactedDot.X).SingleOrDefault();
                    if (existingDot != null)
                    {
                        existingDot.Layer++;
                        Dots.Remove(impactedDot);
                    }
                    else
                    {
                        impactedDot.Y = newY;
                    }
                }

                MaxY = offset - 1;
            }
        }

        public override string ToString()
        {
            var paperString = new StringBuilder();

            for (int y = 0; y <= MaxY; y++)
            {
                if (y > 0)
                {
                    paperString.AppendLine();
                }

                for (int x = 0; x <= MaxX; x++)
                {
                    if (Dots.Any(dot => dot.X == x && dot.Y == y))
                    {
                        paperString.Append('#');
                    }
                    else
                    {
                        paperString.Append('.');
                    }
                }
            }

            return paperString.ToString();
        }
    }
}
