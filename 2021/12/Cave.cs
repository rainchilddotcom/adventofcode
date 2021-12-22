using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12
{
    public class Cave
    {
        public List<Room> Rooms { get; } = new List<Room>();

        public void ParseRooms(string[] input)
        {
            foreach (var passageDefinition in input)
            {
                var split = passageDefinition.Split('-');

                var fromRoom = AddOrGetExistingRoom(split[0]);
                var toRoom = AddOrGetExistingRoom(split[1]);

                fromRoom.LinkTo(toRoom);
                toRoom.LinkTo(fromRoom);
            }
        }

        public List<Path> CalculatePaths(string startRoomId, string endRoomId)
        {
            var start = Rooms
                .Where(x => x.Id == startRoomId)
                .Single();

            var end = Rooms
                .Where(x => x.Id == endRoomId)
                .Single();

            var roomExplorer = new RoomExplorer(start, end);
            return roomExplorer.Paths;
        }

        private Room AddOrGetExistingRoom(string id)
        {
            var room = Rooms
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (room == null)
            {
                room = new Room(id);
                Rooms.Add(room);
            }

            return room;
        }

        public List<Path> CalculateLeisurelyStroll(string startRoomId, string endRoomId)
        {
            var start = Rooms
                .Where(x => x.Id == startRoomId)
                .Single();

            var end = Rooms
                .Where(x => x.Id == endRoomId)
                .Single();

            var roomExplorer = new LeisurelyRoomExplorer(start, end);

            return roomExplorer.Paths;
        }
    }
}
