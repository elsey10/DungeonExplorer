using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    //Creates the abstract class for Items so that Item types can inherit later down the line
    public abstract class Items
    {
        public string ItemDescription { get; set; }

        //Constructor to initialize the common property
        public Items(string description)
        {
            ItemDescription = description;
        }

        //An abstract method that be used in the later items, implements the items use 
        public abstract int ItemUse();
    }

    //Class that inherits from the Items abstract class
    public class Weapons : Items
    {
        //Variable damage, used to determine the damage dealt by the weapon
        public int Damage { get; set; }
        //Constructor for the weapons created in the game. Takes in a description and the damage the weapon deals
        public Weapons(string description, int damage) : base(description)
        {
            Damage = damage;
        }
        //The ItemUse method altered for the weapons
        public override int ItemUse()
        {
            //Prints to console declaring an attack has been made, and the damage dealt
            Console.WriteLine("An attack using " + ItemDescription + " It deals " + Damage + " damage");
            //Returns the damage dealt to wherever the method is called.
            return Damage;
        }
    }

    //Class that inherits from the Items abstract class
    public class Potions : Items
    {
        //Variable healing amount, used to determine how much the potion will heal
        public int HealingAmount { get; set; }
        //Constructor for the potions created in the game, takes a description and the amount the potion heals
        public Potions(string description, int healingAmount) : base(description)
        {
            HealingAmount = healingAmount;
        }
        //ItemUse altered for the potion
        public override int ItemUse()
         {
            //Prints a line declaring how much the player has been healed for
            Console.WriteLine("Using" + ItemDescription + "It heals" + HealingAmount + "health");
            //Returns the quantity of healing so it can be used in other locations
            return HealingAmount;
        }
    }
    //The inventory manager class, this is used to manage the players inventory.
    public class InventoryManager
    {
        //Creates the new list of Items to act as the players inventory
        public List<Items> Inventory = new List<Items>();

        //PickUpItem method. It adds whatever is passed into the method to the player inventory 
        public void PickUpItem(Items item)
        {
            Inventory.Add(item);
        }

        //RemoveItem method. Removes whatever is passed into the method from the inventory
        public void RemoveItem(Items item)
        {
            Inventory.Remove(item);
        }
        //A simple method that just prints the Inventory List
        public string InventoryContents()
        {
            return string.Join(", ", Inventory.Select(item => item.ItemDescription));
        }
    }

}

