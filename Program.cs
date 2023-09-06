using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sword_and_Sorcery
{

    class Program
    {
        static void Main(string[] args)
        {
            Room throneRoom = new Room("Throne Room", "A luxurious throne room.", 0, 0);
            Room armory = new Room("Armory", "An array of weapons and armor line the shelves.", 0, 1);
            Room bobcatRoom = new Room("Bobcat Room", "The decor of this room is distinctly bobcat themed, using many of the cats' pelts.", 0, 2);
            Character conan = new Character("Conan", "A brutish looking man, with a wise twinkle in his eye.", 0, 0);
            GameObject[] gameObjectsList =
            {
                    //Rooms
                    throneRoom,
                    armory,
                    bobcatRoom,
                    //Characters
                    conan
                };
            GameWorld gameWorld = new GameWorld();
            foreach (GameObject i in gameObjectsList)
            {
                gameWorld.worldArray[i.xLocation, i.yLocation].Add(i);
            }

            Character playerCharacter = conan;


            //Game Loop
            while (true)
            {
                Console.WriteLine($"{gameWorld.worldArray[playerCharacter.xLocation, playerCharacter.yLocation][0].name}\n");
                Console.WriteLine($"{gameWorld.worldArray[playerCharacter.xLocation, playerCharacter.yLocation][0].description}\n");

                Console.WriteLine("0: Move\n1:Growl");
                string input1 = Console.ReadLine();

                switch (Convert.ToInt64(input1))
                {
                    case 0:
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

                    default:
                        Console.WriteLine("You can't do that!");
                        break;
                }
                //Console.WriteLine(gameWorld.worldArray[0, 0][1].name);
                //conan.MoveObject(0, 1, gameWorld.worldArray);
                //Console.ReadLine();
            }
        }
    }
}









    
