using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    public class Testing
    {
        //Testing class to make sure when an item is attempted to be picked up it actually is
        public void InventoryCheck(string Inventory, string Item)
        {
            Debug.Assert(Inventory.Contains(Item), "Item has not been picked up");
            Console.WriteLine("Item has been picked up!");
        }
    }
}   