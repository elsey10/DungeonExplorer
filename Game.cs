using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32;

namespace DungeonExplorer
{
    internal class Game
    {
        public Player player { get; set; }
        public Room currentRoom { get; set; }
        public Testing test { get; set; }
        public RoomLayout MapLayout { get; set; }
        public InventoryManager Inventory { get; set; }

        public Game(string userName)
        {
            //Instantiates the Player and currentRoom objects using the classes in R    oom.cs and Player.cs
            player = new Player(userName, 15);
            test = new Testing();
            MapLayout = new RoomLayout();
        }

        public void CombatState()
        {
            bool inCombat = true;
            while (inCombat)
            {
                Console.WriteLine("A Monster! Prepare for battle!");
                Console.WriteLine("");
            }
        }

        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            int ItemTracker = 0;
            //Displays the controls to the player
            Console.WriteLine("Q - Show Stats.  F - Show Inventory.  E - Show Room Description. G - Pick up Item. W - Advance Room R - Quit Game.");
            //The loop of game logic
            
            while (playing)
            {
                //Reads a key input and stores it as variable "input"
                var input = Console.ReadKey(true).Key;
                //The beginning of a switch case to check through all possible inputs from the player
               switch (input)
                {
                    //Case is used to check the potential inputs from the player.
                    case ConsoleKey.Q:
                        //Prints the players UserName and Stats
                        Console.WriteLine(player.Name + " Statistics" + "\n" + "Health " + player.Health);
                        break;
                    case ConsoleKey.F:
                        //Prints the players inventory
                        Console.WriteLine("Inventory:");
                        Console.WriteLine(player.Inventory.InventoryContents());
                        break;
                    case ConsoleKey.E:
                        //Prints the description of the room.
                        MapLayout.PrintCurrentRoom();
                        break;
                    case ConsoleKey.W:
                        //Prints a filler phrase and a gap line before running the MovingRoom function
                        Console.WriteLine("You make your way down a corridor. What lies ahead.");
                        Console.WriteLine("");
                        MapLayout.MovingRoom();
                        break;
                    case ConsoleKey.G:
                        // Check if the current room has an item
                        if (MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomItem != null)
                        {
                            // Inform the player about the picked-up item
                            Console.WriteLine("Picked Up " + MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomItem.ItemDescription);

                            // Add the item to the player's inventory
                            player.Inventory.PickUpItem(MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomItem.ItemDescription);

                            // Check the inventory using the Testing class (optional debugging/validation)
                            string inventoryContents = player.Inventory.InventoryContents();
                            test.InventoryCheck(inventoryContents, MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomItem.ItemDescription);

                            // Clear the item from the current room
                            MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomItem = null;
                        }
                        else
                        {
                            // Inform the player that there's no item to pick up
                            Console.WriteLine("There is no item to pick up in this room.");
                        }
                        break;
                    case ConsoleKey.R:
                        //Ends the play loop
                        playing = false;
                        break;
                    default:
                        //Prints if there is an incorrect input
                        Console.WriteLine("Please Input a valid control");
                        break;
                }
            }
        }
    }
}