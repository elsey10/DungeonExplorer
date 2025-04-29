using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{   
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dungeon Crawler Game!");
            Console.WriteLine("Please enter your name.");
            string userName = Console.ReadLine();
            Console.WriteLine("Welcome " + userName + "!");
            Game game = new Game(userName);
            game.Start();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
