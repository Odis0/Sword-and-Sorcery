﻿using System;
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
                Console.WriteLine($"{playerCharacter.FindRoomAtObjectLocation(gameWorld.worldArray).name}\n");
                Console.WriteLine($"{playerCharacter.FindRoomAtObjectLocation(gameWorld.worldArray).description}\n");

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









    
