using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_and_Sorcery
{
    public class Character : GameObject
    {
        public Character(string name, string description, int x, int y) : base(name, description, x, y)
        {
        }
    }
}
