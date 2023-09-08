﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_and_Sorcery
{
    public class PossibleRooms
    {
        public List<Room> PossibleRoomList { get; }

        public PossibleRooms()
        {
            PossibleRoomList = new List<Room>
            {
                new Room("Throne Room", "A luxurious throne room."),
                new Room("Armory", "An array of weapons and armor line the shelves."),
                new Room("Bobcat Room", "The decor of this room is distinctly bobcat themed, using many of the cats' pelts."),
                // Add more rooms as needed...
            };



        }
    }
}

