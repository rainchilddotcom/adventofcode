using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace _12
{
    public class CaveDrawer
    {
        private readonly Cave _cave;
        private readonly Canvas _canvas;

        public CaveDrawer(Cave cave, Canvas canvas)
        {
            _cave = cave;
            _canvas = canvas;
        }

        Dictionary<Room, DrawableRoom> drawn;
        Queue<Room> drawQueue;

        public void Draw()
        {
            drawn = new Dictionary<Room, DrawableRoom>();
            drawQueue = new Queue<Room>();

            var start = _cave.Rooms
                .Where(x => x.Id == "start")
                .Single();

            drawQueue.Enqueue(start);

            //while (drawQueue.Count > 0)
            //{
            //    var room = drawQueue.Dequeue();
            //    DrawRoom(myCanvas, room);
            //}
        }

        public void DrawNext()
        {
            if (drawQueue.Count > 0)
            {
                var room = drawQueue.Dequeue();
                DrawRoom(room);
            }
        }

        int drawx = 0;

        private void DrawRoom(Room room)
        {
            if (drawn.ContainsKey(room))
                return;

            var neighbours = drawn
                .Where(x => x.Key.Exits.Contains(room))
                .Select(x => x.Value)
                .ToList();

            var drawableRoom = new DrawableRoom(room, _canvas);
            drawableRoom.UpdatePosition(++drawx, 1);

            /*
            if (neighbours.Count != 0)
            {
                int minX = neighbours.Min(x => x.X);
                int minY = neighbours.Min(y => y.Y);
                int maxX = neighbours.Max(x => x.X);
                int maxY = neighbours.Max(y => y.Y);

                if (neighbours.Count == 1)
                {
                    // move below
                    drawableRoom.UpdatePosition(minX, minY + 1);
                }
                else
                {
                    // move to the right of the lowest
                    drawableRoom.UpdatePosition(maxX + 1, maxY);
                }

                // drawableRoom.UpdatePosition(drawn[neighbours[0]].X + 1, drawn[neighbours[0]].Y + 1);
            }
            */

            drawn[room] = drawableRoom;

            foreach (var exit in room.Exits)
            {
                if (!drawQueue.Contains(exit))
                    drawQueue.Enqueue(exit);
            }
        }
    }
}
