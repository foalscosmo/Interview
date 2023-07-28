using TMPro;

namespace Inventory
{
    // Summary: This C# class represents a coin system or wallet in a 2D game using Unity. It manages the player's current coins, provides methods to add and remove coins, and updates the corresponding TextMeshProUGUI element to display the updated coin amount.

    public class Coins
    {
        private int currentCoin; // The current amount of coins held by the player.
        
        // Public property that provides read-only access to the "currentCoin" field:
        public int CurrentCoin => currentCoin;

        // Constructor to initialize the "currentCoin" value:
        public Coins(int currentCoin)
        {
            this.currentCoin = currentCoin;
        }
        // Method to remove coins from the player's wallet:
        public void RemoveMoney(int amount, TextMeshProUGUI currentText)
        {
            // If the player has enough coins to deduct the specified amount:
            if (currentCoin >= amount)
            {
                currentCoin -= amount; // Deduct the coins.
                currentText.text = currentCoin + "$"; // Update the corresponding TextMeshProUGUI to display the updated coin amount.
            }
        }
        // Method to add coins to the player's wallet:
        public void AddMoney(int amount, TextMeshProUGUI currentText)
        {
            currentCoin += amount; // Add the coins.
            currentText.text = currentCoin + "$"; // Update the corresponding TextMeshProUGUI to display the updated coin amount.
        }
    }
}