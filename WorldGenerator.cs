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


            //Next, we transform those empty rooms into rooms of a type.
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    // Create a new list of all possible indices
                    List<int> allIndices = Enumerable.Range(0, possibleRooms.PossibleRoomList.Count).ToList();

                    // Create a list of available indices initially containing all indices
                    List<int> availableIndices = new List<int>(allIndices);

                    while (availableIndices.Count > 0)
                    {
                        // Randomly select an index from the available indices
                        int randomIndex = random.Next(availableIndices.Count);
                        int selectedIndex = availableIndices[randomIndex];

                        // Get the selected room from the possible rooms list
                        Room selectedRoomInfo = possibleRooms.PossibleRoomList[selectedIndex];

                        // Check conditions for placement here
                        if (MeetsPlacementCriteria(i, j, gameWorld, selectedRoomInfo))
                        {
                            // Create a new Room with name, description, and coordinates
                            Room room = new Room(selectedRoomInfo.name, selectedRoomInfo.description, i, j);
                            gameWorld.worldArray[i, j][0] = room;

                            // Remove the selected index from availableIndices
                            availableIndices.RemoveAt(randomIndex);
                            Console.WriteLine($"{i},{j} - {room.name}");
                            break;
                        }
                        else
                        {
                            // Remove the selected index from availableIndices and continue
                            availableIndices.RemoveAt(randomIndex);
                        }
                    }
                }
            }




            return rooms;
        }
        private Room SelectRandomRoom(List<Room> possibleRooms, Random random)
        {
            // Randomly select a room from the list of possible rooms
            return possibleRooms[random.Next(possibleRooms.Count)];
        }

        // Define your criteria-checking method
        private bool MeetsPlacementCriteria(int x, int y, GameWorld gameWorld, Room selectedRoom)
        {
            if (selectedRoom.name == "")
            {
                return false;
            }
            //There can only be one shrine in the game world at the moment.
            if ((selectedRoom.name == "Shrine") && (CountRoomsOfType(gameWorld,"Shrine")>0))
            {
                return false;
            }
            //There can only be one shrine in the game world at the moment.
            if ((selectedRoom.name == "Fortress Ruins") && (CountRoomsOfType(gameWorld, "Fortress Ruins") > 0))
            {
                return false;
            }

            if (selectedRoom.name == "dsf")
            {
                return false;
            }
            if (selectedRoom.name == "")
            {
                return false;
            }




            // Implement your criteria logic here
            // For example, check if there's already a room of a certain type nearby
            // Or check if there's a road nearby, etc.
            return true; // Return true if the criteria are met, otherwise, return false
        }

        public int CountRoomsOfType(GameWorld gameWorld, string type)
        {
            int count = 0;
            int width = gameWorld.worldArray.GetLength(0);
            int height = gameWorld.worldArray.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    // Check if the cell contains a room and if its type matches the specified type
                    if (gameWorld.worldArray[i, j].Count > 0 && gameWorld.worldArray[i, j][0].name == type)
                    {
                        count++;
                    }
                }
            }

            return count;
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
/
        private Room SelectRandomRoom(List<Room> possibleRooms, Random random)
        {
            // Randomly select a room from the list of possible rooms
            return possibleRooms[random.Next(possibleRooms.Count)];
        }
    }
}

*/
