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
}
