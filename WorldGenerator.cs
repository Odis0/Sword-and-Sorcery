using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_and_Sorcery
{
    public class WorldGenerator
    {
        public List<Room> GenerateRooms(GameWorld gameWorld, PossibleRooms possibleRooms)
        {
            Random random = new Random();
            List<Room> rooms = new List<Room>();

            int width = gameWorld.worldArray.GetLength(0); // Get the width from the gameWorld
            int height = gameWorld.worldArray.GetLength(1); // Get the height from the gameWorld


            //First, we fill the array with "empty" rooms.
            Room emptyRoom = new Room("Empty Room", "The void gapes.");
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    // Create a new Room with name, description, and coordinates
                    Room room = new Room(emptyRoom.name, emptyRoom.description, i, j);

                    // Add the room to the list of rooms
                    rooms.Add(room);

                    // Add the room to the gameWorld
                    gameWorld.AddObjectToGameWorld(room);
                }
            }
            return rooms;
        }
    }

}



/*


        
            //Insert random room from the list of possible rooms.
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    // Randomly select a room from the list of possible rooms
                    Room selectedRoomInfo = SelectRandomRoom(possibleRooms.PossibleRoomList, random);

                    // Create a new Room with name, description, and coordinates
                    Room room = new Room(selectedRoomInfo.name, selectedRoomInfo.description, i, j);

                    // Add the room to the list of rooms
                    rooms.Add(room);

                    // Add the room to the gameWorld
                    gameWorld.AddObjectToGameWorld(room);
                }
            }

            return rooms;
        }

        private Room SelectRandomRoom(List<Room> possibleRooms, Random random)
        {
            // Randomly select a room from the list of possible rooms
            return possibleRooms[random.Next(possibleRooms.Count)];
        }
    }
}

*/
