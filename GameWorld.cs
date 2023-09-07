using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_and_Sorcery
{
    public class GameWorld
    {
        // Declare the gameWorld array as a public field
        public List<GameObject>[,] worldArray;

        public GameWorld(int width, int height)
        {
            // Initialize the gameWorld array with the specified dimensions
            worldArray = new List<GameObject>[width, height];

            // Initialize the lists for each cell in the gameWorld array
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    worldArray[i, j] = new List<GameObject>();
                }
            }
        }

        public void AddObjectToGameWorld(GameObject obj)
        {
            if (IsValidLocation(obj.xLocation, obj.yLocation))
            {
                worldArray[obj.xLocation, obj.yLocation].Add(obj);
            }
            else
            {
                // Handle the case when the location is out of bounds
                Console.WriteLine("Invalid location for object placement.");
            }
        }

        private bool IsValidLocation(int x, int y)
        {
            return x >= 0 && x < worldArray.GetLength(0) && y >= 0 && y < worldArray.GetLength(1);
        }
    }
}