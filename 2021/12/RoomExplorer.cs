using System;
using System.Collections.Generic;
using System.Linq;

namespace _12
{
    public class RoomExplorer
    {
        private readonly Room _end;

        public RoomExplorer(Room start, Room end)
        {
            _end = end;

            Explore(new List<Room>(), start);
            SortPaths();
        }

        public List<Path> Paths { get; private set; } = new List<Path>();

        public void SortPaths()
        {
            Paths = Paths
                .OrderBy(path => path.ToString())
                .ToList();
        }

        public void Explore(List<Room> steps, Room room)
        {
            steps.Add(room);

            if (room == _end)
            {
                // jerb done
                Paths.Add(new Path(steps));
                return; 
            }

            var validExits = room.Exits.Where(destination => ValidExit(steps, destination)).ToList();
            foreach (var next in validExits)
            {
                Explore(new List<Room>(steps), next);
            }
        }

        public virtual bool ValidExit(List<Room> steps, Room destination)
        {
            if (destination.Large)
                return true;
            else
                return !steps.Contains(destination);
        }
    }
}
