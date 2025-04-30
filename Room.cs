using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DungeonExplorer
{


    public class Room
    {
        private string description;

        //Instantiates the Items object so that rooms can contain items
        public Items RoomItem { get; set; }

        //Instantiates the Monster object so that rooms can contain Monsters
        public Monster RoomMonster { get; set; }

        //The constructor for the room class with Description, Items and the Monster.
        public Room(string description, Items item, Monster monster)
        {
            this.description = description;
            RoomItem = item;
            RoomMonster = monster;
        } 
        
        //Method to return description where its used
        public string GetDescription()
        {
            return description;
        }
    }

    //RoomyLayout class is used to create the basic game map.
    public class RoomLayout
    {
        //Creates the list of rooms the player can move through
        public List<Room> rooms = new List<Room>
        {
            //A list that creates all the new room objects, with the items and monsters inside them.
            new Room("A prison cell. There is a knife resting upon the counter. There is a large wooden door ahead of you.",
                new Weapons("Iron Knife", 15), null),
            new Room("A guard room, there is a desk in the corner. It has a small health potion rested on its edge. There is a door to your right." +
                " there is a small goblin sat upon the table, it launches itself at you.",new Potions("Health Potion", 25), new Monster ("Goblin", 10, 2)),
            new Room("A large banquet hall. There is an array of food and drink spread across the large tables. A wooden door stands tall on the back wall."
                ,new Weapons("Silver Dagger", 25) , null) ,
            new Room("A courtyard. There is a large metal statue of a king in the centre. Surrounding it there is a variety of dying flowers. Your exit" +
                " from this dungeon lies ahead of you. But a large scaled dragon rests asleep around the statue.", null, new Monster ("Dragon", 50, 7)) // No item in this room 
        };

        //Creates an int for the RoomNumber so the game knows which room the player is in
        public int CurrentRoomNumber = 0;
        //Method to print the description of the current room
        public void PrintCurrentRoom()
        {
            //Checks the current room exists withing the amount of rooms
            if (CurrentRoomNumber < rooms.Count)
            {
                //Prints the description of the current room using the GetDescription method
                Console.WriteLine(rooms[CurrentRoomNumber].GetDescription());
            }
            //Prints if you somehow get into a room that doesn't exist
            else
            {
                Console.WriteLine("You cannot go further.");
            }    
        }
        //Method to move the player forward a room
        public void MovingRoom()
        {
            //Makes sure you are not in the final room. 
            if (CurrentRoomNumber < rooms.Count - 1)
            {
                //Adds 1 to the room number and prints the description of the newly entered room
                CurrentRoomNumber++;
                PrintCurrentRoom();
            }
            //If you leave the final room it congratulates the player and ends the game
            else
            {
                Console.WriteLine("The Exit! You have escaped from the dungeon!");
                Console.WriteLine("Congratluations on completeting the game");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
