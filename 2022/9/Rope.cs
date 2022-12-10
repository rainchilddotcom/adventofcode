using _0;

namespace _9
{
    public class Rope
    {
        public Rope(Point2D head, Point2D tail, int length)
        {
            Body.Add(head);
            for (int i = 0; i < length -2; i++)
            {
                Body.Add(new Point2D(head.X, head.Y));
            }
            Body.Add(tail);
        }

        public List<Point2D> Body { get; init; } = new List<Point2D>();
        public Point2D Head { get { return Body.First(); } }
        public Point2D Tail { get { return Body.Last(); } }
        public int Length { get { return Body.Count; } }


        public event Action<Point2D> OnHeadVisit;
        public event Action<Point2D> OnTailVisit;

        public void MoveHead(string instruction)
        {
            string direction = instruction.Substring(0, 1);
            var magnitude = Convert.ToUInt32(instruction.Substring(2));

            for (int i = 0; i < magnitude; i++)
            {
                switch (direction)
                {
                    case "U":
                        Head.Y -= 1;
                        break;

                    case "D":
                        Head.Y += 1;
                        break;

                    case "L":
                        Head.X -= 1;
                        break;

                    case "R":
                        Head.X += 1;
                        break;

                    default:
                        throw new ArgumentException($"Unknown direction {direction}");
                }

                Point2D following = Head;
                foreach (var segment in Body)
                {
                    if (segment == Head)
                        continue;

                    var moved = UpdateSegment(segment, following);
                    following = segment;

                    if (segment == Tail)
                        Visit(true, moved);
                }
            }
        }

        private bool UpdateSegment(Point2D segment, Point2D following)
        {
            // segments must follow if more than 1 away
            int distanceX = following.X - segment.X;
            int distanceY = following.Y - segment.Y;

            bool hasMoved = false;

            if (Math.Abs(distanceX) > 1)
            {
                segment.X += Math.Sign(distanceX);
                hasMoved = true;
            }

            if (Math.Abs(distanceY) > 1)
            {
                segment.Y += Math.Sign(distanceY);
                hasMoved = true;
            }

            if (hasMoved)
            {
                if (distanceX != 0 && distanceY != 0)
                {
                    // diagonal movement - tail should straighten out into correct column
                    if (Math.Abs(distanceX) > Math.Abs(distanceY))
                    {
                        segment.Y = following.Y;
                    }
                    else if (Math.Abs(distanceX) < Math.Abs(distanceY))
                    {
                        segment.X = following.X;
                    }
                }
            }

            return hasMoved;
        }

        public void Visit(bool head, bool tail)
        {
            if (head)
                OnHeadVisit?.Invoke(Head);
            if (tail)
                OnTailVisit?.Invoke(Tail);
        }
    }
}
