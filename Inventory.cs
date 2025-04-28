using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class InventoryManager
    {
        public List<string> Inventory = new List<string>();

        public void PickUpItem(string item)
        {
            Inventory.Add(item);
        }
        public string InventoryContents()
        {
            return string.Join(", ", Inventory);
        }
    }

    public abstract class Items
    {
        public string ItemDescription { get; set; }

        // Constructor to initialize the common property
        public Items(string description)
        {
            ItemDescription = description;
        }

        // Optional: Abstract method(s) that must be implemented by derived classes
        public abstract void ItemUse();
    }

    public class Weapons : Items
    {
        public int Damage { get; set; }

        public Weapons(string description, int damage) : base(description)
        {
            Damage = damage;
        }

        public override void ItemUse()
        {
            Console.WriteLine("Using" , ItemDescription , "It deals" , Damage , "damage");
        }
    }

    public class Potions : Items
    {
        public int HealingAmount { get; set; }

        public Potions(string description, int healingAmount) : base(description)
        {
            HealingAmount = healingAmount;
        }

        public override void ItemUse()
         {
            Console.WriteLine("Using" , ItemDescription , "It heals" , HealingAmount , "health"); 
        }
    }
}

