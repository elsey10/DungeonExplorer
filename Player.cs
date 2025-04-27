using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        public string Name;
        public int Health;

        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public abstract void Attack();

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
    public class Player : Creature
    {
        public List<string> Inventory { get; private set; } = new List<string>();

        public Player(string name, int health) : base(name, health) { }

        public override void Attack()
        {
            Console.WriteLine("An attack!");
        }

        public void PickUpItem(string item)
        {
            Inventory.Add(item);
        }
        public string InventoryContents()
        {
            return string.Join(", ", Inventory);
        }
    }
}
