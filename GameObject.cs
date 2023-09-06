using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_and_Sorcery
{
    public abstract class GameObject
    {
        public string name;
        public int xLocation { get; set; }
        public int yLocation { get; set; }

        public string description { get; set; }

        public GameObject(string name, string description, int x, int y)
        {
            this.name = name;
            this.description = description;
            xLocation = x;
            yLocation = y;

        }
    }
}
