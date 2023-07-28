using Inventory;
using UnityEngine;

namespace Shop
{
    public class TradeManager : MonoBehaviour
    {
        // Summary: This C# script represents a player's wallet or coin system in a 2D game using Unity. It uses an InventoryManager to handle buying and selling items, and it keeps track of the player's current coins.

        [SerializeField] private InventoryManager inventoryManager; // Reference to the InventoryManager script to interact with the inventory system.
        public readonly Coins coins = new(300); // A Coins object representing the player's current coins. Initialized with 300 coins.
        
        // The OnEnable method is called when the script is enabled:
        private void OnEnable()
        {
            // Subscribe to the OnBuy and OnSell events in the inventoryManager.
            // When the player buys an item, remove the corresponding amount of money from the coins.
            // When the player sells an item, add the corresponding amount of money to the coins.
            inventoryManager.OnBuy += coins.RemoveMoney;
            inventoryManager.OnSell += coins.AddMoney;
        }
       // The OnDisable method is called when the script is disabled:
        private void OnDisable()
        {
            // Unsubscribe from the OnBuy and OnSell events in the inventoryManager to avoid memory leaks.
            inventoryManager.OnBuy -= coins.RemoveMoney;
            inventoryManager.OnSell -= coins.AddMoney;
        }

    }
}