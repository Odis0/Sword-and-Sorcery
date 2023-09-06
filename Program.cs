using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sword_and_Sorcery
{



    public class Room : GameObject
    {
        public Room(string name, string description, int x, int y) : base(name, description, x, y)
        {
        }
    }


    public class Character : GameObject
    {
        public Character(string name, string description, int x, int y) : base(name, description, x, y)
        {
        }
    }

    public static class GameObjectExtensions
    {
        public static void MoveObject(this GameObject gameObject, int xDestination, int yDestination, List<GameObject>[,] worldArray)
        {
            // Remove the object from its current location in gameWorld
            worldArray[gameObject.xLocation, gameObject.yLocation].Remove(gameObject);

            // Update the x and y coordinates
            gameObject.xLocation = xDestination;
            gameObject.yLocation = yDestination;

            // Add the object to its new location in gameWorld
            worldArray[xDestination, yDestination].Add(gameObject);

            Console.WriteLine($"{gameObject.name} moved to ({xDestination}, {yDestination}).");
        }

        public static List<Room> FindAdjacentRooms(this GameObject gameObject, List<GameObject>[,] worldArray)
        {
            int x = gameObject.xLocation;
            int y = gameObject.yLocation;

            List<Room> adjacentRooms = new List<Room>();

            // Check North
            if (y - 1 >= 0 && worldArray[x, y - 1].Count > 0)
            {
                if (worldArray[x, y - 1][0] is Room northRoom)
                {
                    adjacentRooms.Add(northRoom);
                }
            }

            // Check South
            if (y + 1 < worldArray.GetLength(1) && worldArray[x, y + 1].Count > 0)
            {
                if (worldArray[x, y + 1][0] is Room southRoom)
                {
                    adjacentRooms.Add(southRoom);
                }
            }

            // Check East
            if (x + 1 < worldArray.GetLength(0) && worldArray[x + 1, y].Count > 0)
            {
                if (worldArray[x + 1, y][0] is Room eastRoom)
                {
                    adjacentRooms.Add(eastRoom);
                }
            }

            // Check West
            if (x - 1 >= 0 && worldArray[x - 1, y].Count > 0)
            {
                if (worldArray[x - 1, y][0] is Room westRoom)
                {
                    adjacentRooms.Add(westRoom);
                }
            }

            // Now, adjacentRooms contains all the adjacent rooms
            return adjacentRooms;


        }

    }


    public class GameWorld
    {
        // Declare the gameWorld array as a public field
        public List<GameObject>[,] worldArray = new List<GameObject>[5, 5];

        public GameWorld()
        {
            // Initialize the lists for each cell in the gameWorld array
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    worldArray[i, j] = new List<GameObject>();
                }
            }
        }

        public void AddObjectToGameWorld(GameObject obj)
        {
            worldArray[obj.xLocation, obj.yLocation].Add(obj);
        }


    }

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



            //Game Loop
            while (true)
            {
                Console.WriteLine($"{gameWorld.worldArray[conan.xLocation, conan.yLocation][0].name}\n");
                Console.WriteLine($"{gameWorld.worldArray[conan.xLocation, conan.yLocation][0].description}\n");

                Console.WriteLine("0: Move\n1:Growl");
                string input1 = Console.ReadLine();

                switch (Convert.ToInt64(input1))
                {
                    case 0:
                        List<Room> adjacentRooms = conan.FindAdjacentRooms(gameWorld.worldArray);
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
                            conan.MoveObject(selectedRoom.xLocation, selectedRoom.yLocation, gameWorld.worldArray);
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









    
