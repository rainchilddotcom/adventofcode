using System;
using System.Collections.Generic;

namespace _12
{
    public class Room
    {
        public Room(string id)
        {
            Id = id;
        }

        public string Id { get; }
        public List<Room> Exits { get; } = new List<Room>();
        public bool Large { get { return char.IsUpper(Id[0]); } }

        public override string ToString()
        {
            return Id;
        }

        internal void LinkTo(Room toRoom)
        {
            if (!Exits.Contains(toRoom))
                Exits.Add(toRoom);
        }
    }
}