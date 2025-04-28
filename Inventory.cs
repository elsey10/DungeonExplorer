using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public abstract class Items
    {
        public string ItemDescription { get; set; }

        // Constructor to initialize the common property
        public Items(string description)
        {
            ItemDescription = description;
        }

        // Optional: Abstract method(s) that must be implemented by derived classes
        public abstract int ItemUse();
    }

    public class Weapons : Items
    {
        public int Damage { get; set; }

        public Weapons(string description, int damage) : base(description)
        {
            Damage = damage;
        }

        public override int ItemUse()
        {
            Console.WriteLine("An attack using " + ItemDescription + " It deals " + Damage + " damage");
            return Damage;
        }
    }

    public class Potions : Items
    {
        public int HealingAmount { get; set; }

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

