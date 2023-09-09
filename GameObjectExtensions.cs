using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_and_Sorcery
{
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

        //This function returns what the name of the compass direction is for objects in adjacent location. So if the target object is east, it will return "East". 
        public static string AdjacentLocationDirectionToSelf(this GameObject gameObject, GameObject adjacentObject)
        {
            int xDifference = adjacentObject.xLocation - gameObject.xLocation;
            int yDifference = adjacentObject.yLocation - gameObject.yLocation;

            if (xDifference == 0 && yDifference == 1)
            {
                return "North";
            }
            else if (xDifference == 0 && yDifference == -1)
            {
                return "South";
            }
            else if (xDifference == 1 && yDifference == 0)
            {
                return "East";
            }
            else if (xDifference == -1 && yDifference == 0)
            {
                return "West";
            }
            else
            {
                // Handle the case where objects are not adjacent or diagonally adjacent
                return "Unknown";
            }
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

}
