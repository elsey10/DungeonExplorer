using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DungeonExplorer
{
    //Interface to mark what Objects can be damaged in the game
    public interface IDamageable
    {
        //The Health of the object being damaged
        int Health { get; set; }
        //TakeDamage method for when the objects take damage
        void TakeDamage(int amount);
    }

    public abstract class Creature
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        //Consturctor for the abstract creature class. Shows that creatures require names and hp
        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        //Creates an abstract method for when creatures make an attack
        public abstract int Attack();

        //A simple method to check the creature is alive. Checks if the creatures HP is greater than 0
        public bool IsAlive()
        {
            return Health > 0;
        }
    }

    //Player class, inherits from the creature abtract class and the IDamageable interface
    public class Player : Creature, IDamageable
    {

        public InventoryManager Inventory { get; set; }
        //Constructor for the player, requires a name and health value
        public Player(string name, int health) : base(name, health) 
        {
            //Insantiates the inventory object so that the player has an inventory
            Inventory = new InventoryManager();
        }

        //Attack method, prints a statement and returns a damage. Players attack method isn't used.
        public override int Attack()
        {
            Console.WriteLine("An attack!");
            return 5;
        }

        //The TakeDamage method, applies the damage taken to the players health, as well as checking the player is not dead.
        public void TakeDamage(int amount)
        {
            //Minus damage from player hp
            Health -= amount;
            //Checks the player is alive, and closes the game if they are not
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

    //Monster class, inherits from creature and Idamageable
    public class Monster : Creature, IDamageable
    {
        //Constructor for the Monster, takes name, health and the damage of the creature
        public Monster(string name, int health, int damage) : base(name, health)
        {
            Damage = damage;
        }

        //The attack function which is actually utilised to return the damage number
        public override int Attack()
        {
            return Damage;
        }

        //The same take damage function as is utilised as the one in player
        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Console.WriteLine(Name + " Slain!");
                Console.WriteLine("You may continue exploring now!");
            }
            else
            {
                Console.WriteLine(Name + " got hit for " + amount + " but it survived");
            }
        }
    }
}
