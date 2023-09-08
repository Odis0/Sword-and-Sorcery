using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_and_Sorcery
{
    class UIPlayerMovement
    {
        private Character playerCharacter;
        private GameWorld gameWorld;

        public UIPlayerMovement(Character playerCharacter, GameWorld gameWorld)
        {
            while (true)
            {


                List<Room> adjacentRooms = playerCharacter.FindAdjacentRooms(gameWorld.worldArray);
                int i = 0;
                Console.WriteLine("Where would you like to move to?");
                foreach (var room in adjacentRooms)
                {
                    Console.WriteLine($"{i}:{room.name}");
                    i++;
                }
                Console.WriteLine($"{i}:Back");

                string input2 = Console.ReadLine();

                if (int.TryParse(input2, out int choice) && choice >= 0 && choice < adjacentRooms.Count)
                {
                    Room selectedRoom = adjacentRooms[choice];

                    Console.WriteLine($"You moved to {selectedRoom.name}!");

                    // Move the player to the selected room
                    playerCharacter.MoveObject(selectedRoom.xLocation, selectedRoom.yLocation, gameWorld.worldArray);
                }
                else if (choice == i)
                {
                    // Player chose to go back or perform some other action
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                break;

            }
        }
    }
}