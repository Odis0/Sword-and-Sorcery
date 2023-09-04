using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_and_Sorcery
{
    abstract class GameObject
        {
        public string name;
        }

    class Room : GameObject
    {
        public Room (string roomName)
        {
            name = roomName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Room throneRoom = new Room("ThroneRoom");
            Console.WriteLine(throneRoom.name);
            Console.ReadLine();
        }
    }
}
