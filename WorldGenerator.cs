using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_and_Sorcery
{
    public class WorldGenerator
    {
        public List<Room> GenerateRooms(int width, int height)
        {
            Random random = new Random();
            PossibleRooms possibleRooms = new PossibleRooms(); // Create an instance of PossibleRooms
            List<Room> rooms = new List<Room>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    // Generate random coordinates within the bounds of the game world
                    int x = random.Next(width);
                    int y = random.Next(height);

                    // Randomly select a room from the list of possible rooms
                    Room selectedRoomInfo = possibleRooms.PossibleRoomList[random.Next(possibleRooms.PossibleRoomList.Count)];

                    Room room = new Room(selectedRoomInfo.name, selectedRoomInfo.description, x, y);
                    rooms.Add(room);
                }
            }

            return rooms;
        }
    }
}

