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
        public InventoryManager Inventory { get; set; }

        public Player(string name, int health) : base(name, health) 
        {
            Inventory = new InventoryManager();
        }

        public override void Attack()
        {
            Console.WriteLine("An attack!");
        }
    }

    public class Monster : Creature
    {
        public Monster(string name, int health) : base(name, health)
        {
            
        }

        public override void Attack()
        {
            Console.WriteLine("An attack!");
        }
    }
}
