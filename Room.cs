using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_and_Sorcery
{
    public class Room : GameObject
    {
        public Room(string name, string description, int x = 999, int y = 999) : base(name, description, x, y)
        {
        }
    }
}
