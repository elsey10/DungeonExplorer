using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DungeonExplorer
{
    public interface IDamageable
    {
        int Health { get; set; } // Represents the object's health
        void TakeDamage(int amount); // Method to apply damage
    }

    public abstract class Creature
    {
        public string Name { get; set; }
        public int Health { get; set; }

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
    public class Player : Creature, IDamageable
    {
        public int Damage { get; private set; }

        public InventoryManager Inventory { get; set; }

        public Player(string name, int health) : base(name, health) 
        {
            Inventory = new InventoryManager();
        }

        public override void Attack()
        {
            Console.WriteLine("An attack!");
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Console.WriteLine(Name + " has died");
                Console.WriteLine("Game Over");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(Name + " took " + amount + " damage. Remaining Health " + Health);
            }
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
