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

        public override int ItemUse()
         {
            Console.WriteLine("Using" , ItemDescription , "It heals" , HealingAmount , "health");
            return HealingAmount;
        }
    }

    public class InventoryManager
    {
        public List<Items> Inventory = new List<Items>();

        public void PickUpItem(Items item)
        {
            Inventory.Add(item);
        }

        public void RemoveItem(Items item)
        {
            Inventory.Remove(item);
        }

        public string InventoryContents()
        {
            return string.Join(", ", Inventory.Select(item => item.ItemDescription));
        }
    }

}

