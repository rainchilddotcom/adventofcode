using System.Collections.Generic;
using System.Linq;

namespace _12
{
    public class LeisurelyRoomExplorer
        : RoomExplorer
    {
        public LeisurelyRoomExplorer(Room start, Room end)
            : base(start, end)
        {
        }

        public override bool ValidExit(List<Room> steps, Room destination)
        {
            if (destination.Large)
                return true;

            if (destination.Id == "start")
                return false;

            if (!steps.Contains(destination))
                return true;

            return steps
                .Where(room => !room.Large)
                .GroupBy(room => room.Id)
                .Where(group => group.Count() > 1)
                .SingleOrDefault() == null;
        }
    }
}