using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        public Room(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }
    }

    public class RoomLayout
    {
        public List<Room> rooms = new List<Room>
        {
            new Room("A prison cell. There is a knife resting upon the counter. There is a large wooden door ahead of you."),
            new Room ("A guard room, there is a desk in the corner. It has a small health potion rested on its edge. There is a door to your right."),
            new Room ("A large banquet hall. There is an array of food and drink spread across the large tables. A wooden door stands tall on the back wall."),
            new Room ("A courtyard. There is a large metal statue of a king in the centre. Surrounding it there is a variety of dying flowers.")
        };

        private int CurrentRoomNumber = 0;

        public void PrintCurrentRoom()
        {
            if (CurrentRoomNumber < rooms.Count)
            {
                Console.WriteLine(rooms[CurrentRoomNumber].GetDescription());
            }
            else
            {
                Console.WriteLine("You cannot go further.");
            }    
        }

        public void MovingRoom()
        {
            if (CurrentRoomNumber < rooms.Count - 1)
            {
                CurrentRoomNumber++;
                PrintCurrentRoom();
            }
            else
            {
                Console.WriteLine("There are no more rooms for you to explore.");
            }
        }
    }
}
