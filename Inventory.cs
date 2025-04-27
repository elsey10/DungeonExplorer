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
}

