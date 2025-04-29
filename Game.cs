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

        //Method to handle the Items being used. Checks for the item types then uses them as needed.
        public void ItemHandler (Items item)
        {
            //Checks if the item is a Weapon
            if (item is Weapons weapon)
            {
                //Use the weapon and store the damage it will deal in DamageTaken
                int DamageTaken = weapon.ItemUse(); 
                //Runs the TakeDamage method from the Monster class to cause the monster to lose health. 
                MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomMonster.TakeDamage(DamageTaken);
            }
            //Checks if the item is a Potion
            else if (item is Potions potion)
            {
                //Uses the potion and stores the health gained in a variable called HealthGained
                int HealthGained = potion.ItemUse();
                //Removes the health potion from the inventory as it is single use
                player.Inventory.RemoveItem(item);
                //Adds the health gained to the players hp
                player.Health += HealthGained;
            }
            //Error handling for if the item is not one of the two known item types.    
            else
            {
                Console.WriteLine("Invalid item type!");
            }
        }

        public void CombatState()
        {
            //Creates a new inCombat variable to know if the player is currently in combat
            bool inCombat = true;
            Console.WriteLine("");
            Console.WriteLine("A Monster! Prepare for battle!");
            Console.WriteLine("");
            //Create the loop for when a player is in Combat 
            while (inCombat)
            {
                //Checks the monster inside the room is alive before going into the player input section.
                if (MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomMonster.IsAlive() == true)
                {
                    //The monster attacks the player as combat starts
                    int MonsterAttack = MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomMonster.Attack();
                    Console.WriteLine("The " + MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomMonster.Name + 
                        " attacks! It hits you for " + MonsterAttack.ToString() + " damage");
                    //Runs the TakeDamage method so the player takes the damage
                    player.TakeDamage(MonsterAttack);

                    //Prints the players inventory again so they can choose which item to use
                    Console.WriteLine("You currently have " + player.Inventory.InventoryContents());
                    Console.WriteLine("Input the number corrosponding to the item you wish to use!");
                    //Takes the player input so they can select there item
                    var CombatInput = Console.ReadKey(true).Key;
                    //The if statement for the logic of which item has been selected
                    if (player.Inventory.Inventory.Count > 0)
                    {
                        //Checks that the input falls between 1 and 3, as the player can only hold 3 items in this game buid
                        if (CombatInput >= ConsoleKey.D1 && CombatInput <= ConsoleKey.D3)
                        {
                            //Converts the key press to an inventory index 
                            int selectedItem = CombatInput - ConsoleKey.D1;
                            //Ensures that the index above falls within inventory size 
                            if (selectedItem < player.Inventory.Inventory.Count)
                            {
                                //Gets the selected item out of the inventory and stores it in item
                                var item = player.Inventory.Inventory[selectedItem];
                                //Runs ItemHandler method with the item selected above.
                                ItemHandler(item);
                            }
                            //Error handling for when an input greater then 3 is put in.
                            else
                            {
                                Console.WriteLine("Invalid selection, no item in that slot.");
                            }
                        }
                        //Input reader so that the player can still exit the game from inside the combat logic
                        else if (CombatInput == ConsoleKey.Escape)
                        {
                            Console.WriteLine("Exiting Game");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        //Error handling for if an input that is not 1-3 is put in
                        else
                        {
                            Console.WriteLine("Invalid Input. Please try again.");
                        }
                    }
                    //Statement for if the players inventory is empty
                    else
                    {
                        Console.WriteLine("Your inventory is empty");
                    }

                }
                //Runs once the monster in the room has no health and combat has ended.
                else
                {
                    inCombat = false;
                }
            }  
        }

        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            //Displays the controls to the player
            Console.WriteLine("Q - Show Stats.  F - Show Inventory.  E - Show Room Description. G - Pick up Item. W - Advance Room ESC - Quit Game.");
            MapLayout.PrintCurrentRoom();
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
                        if (MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomMonster != null)
                        {
                            Console.ReadKey();
                            CombatState();
                            break;
                        }    
                        break;
                    case ConsoleKey.G:
                        //Check if the current room has an item
                        if (MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomItem != null)
                        {
                            //Prints a line saying the player has picked up the item
                            Console.WriteLine("Picked Up " + MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomItem.ItemDescription);

                            //Add the item to the player's inventory
                            player.Inventory.PickUpItem(MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomItem);

                            //Check the inventory using the Testing class (optional debugging/validation)
                            string inventoryContents = player.Inventory.InventoryContents();
                            test.InventoryCheck(inventoryContents, MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomItem.ItemDescription);

                            //Clear the item from the current room
                            MapLayout.rooms[MapLayout.CurrentRoomNumber].RoomItem = null;
                        }
                        else
                        {
                            // Inform the player that there's no item to pick up
                            Console.WriteLine("There is no item to pick up in this room.");
                        }
                        break;
                    case ConsoleKey.Escape:
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