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
        /*
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



        GameWorld gameWorld = new GameWorld(5,5);
        foreach (GameObject i in gameObjectsList)
        {
            gameWorld.worldArray[i.xLocation, i.yLocation].Add(i);
        }
        */


        {
            // Create an instance of GameWorld with your desired width and height
            GameWorld gameWorld = new GameWorld(5, 5);

            // Create an instance of WorldGenerator
            WorldGenerator worldGenerator = new WorldGenerator();

            // Create an instance of PossibleRooms
            PossibleRooms possibleRooms = new PossibleRooms();

            // Generate rooms based on the dimensions of the gameWorld
            List<Room> rooms = worldGenerator.GenerateRooms(gameWorld, possibleRooms);

            // Add the generated rooms to the gameWorld
            foreach (var room in rooms)
            {
                gameWorld.AddObjectToGameWorld(room);
            }

            // Now, create and add characters to the gameWorld
            Character conan = new Character("Conan", "A brutish looking man, with a wise twinkle in his eye.", 0, 0);
            gameWorld.AddObjectToGameWorld(conan);

            // You can create and add more characters as needed

            // Now, your gameWorld has rooms and characters




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
                        UIPlayerMovement uiplayermovement = new UIPlayerMovement(playerCharacter, gameWorld);
                        break;
                    default:
                        break;

                }
            }
        }
    }
}









    
