using System;
using System.Collections.Generic;
using Items;
using Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Inventory
{
  // Summary: InventoryManager class is responsible for managing the player's inventory and interactions with the shop.

// Import necessary libraries or namespaces here, if not already done in the file.

// Summary: InventoryManager is a MonoBehaviour class used to manage player inventory and shop interactions.
public class InventoryManager : MonoBehaviour
{
    // Summary: Private field to store a list of ShopButtons (buttons for buying items from the shop).
    [SerializeField] private List<ShopButton> shopButtons = new();
    // Summary: Private field to store a list of Transforms representing inventory panels.
    [SerializeField] private List<Transform> inventoryPanel;
    // Summary: Private reference to the InventoryContainer that holds player inventory data.
    [SerializeField] private InventoryContainer inventoryContainer;
    // Summary: Private reference to the ShopManager that handles shop-related functionalities.
    [SerializeField] private ShopManager shopManager;
    // Summary: Private reference to the EquipManager that handles equipping items.
    [SerializeField] private EquipManager equipManager;
    // Summary: Private reference to the TradeManager that manages player's coins and transactions.
    [SerializeField] private TradeManager tradeManager;
    // Summary: Private reference to the Shop that contains available items for purchase.
    [SerializeField] private Shop.Shop shop;
    // Summary: Private reference to a TextMeshProUGUI component to display player's coins.
    [SerializeField] private TextMeshProUGUI playerText;
    // Summary: Private reference to a Button component for inventory interactions.
    [SerializeField] private Button button;
    // Summary: Private variable to keep track of the amount of items in the player's inventory.
    [SerializeField] private int itemAmount;
    // Summary: Event that is triggered when an item is bought. It provides the price and player's TextMeshProUGUI for updates.
    public event Action<int, TextMeshProUGUI> OnBuy;

    // Summary: Event that is triggered when an item is sold. It provides the sell price and player's TextMeshProUGUI for updates.
    public event Action<int, TextMeshProUGUI> OnSell;

    // Summary: Reference to the ItemDisplay component used for displaying items in the inventory.
    private ItemDisplay display;

    // Summary: Private variable to track whether the inventory is currently open.
    private bool isInventoryOpen;

    // Summary: Property to get or set the 'isInventoryOpen' variable.
    public bool IsInventoryOpen
    {
        set => isInventoryOpen = value;
    }

    // Summary: Called when the script is enabled. Sets up initial state and subscribes to events.
    private void OnEnable()
    {
        // Update player's coin display.
        playerText.text = tradeManager.coins.CurrentCoin + " $ ";

        // Deactivate all inventory panels initially.
        foreach (var inventory in inventoryPanel)
            inventory.gameObject.SetActive(false);

        // Subscribe to shop button events to handle item purchases.
        foreach (var hatShopButton in shopButtons)
            hatShopButton.OnShopButtonPressed += Buy;
    }

    // Summary: Called when the script is disabled. Unsubscribes from events.
    private void OnDisable()
    {
        // Unsubscribe from shop button events.
        foreach (var buttons in shopButtons)
            buttons.OnShopButtonPressed -= Buy;
    }

    // Summary: Handles the process of buying an item from the shop.
    private void Buy(int index)
    {
        // Check if the player has enough coins to buy the item.
        if (tradeManager.coins.CurrentCoin < shop.Items[index].price)
            return;

        // Check if the player's inventory is already full.
        if (itemAmount >= inventoryContainer.MaxSize)
            return;

        // Increment the item amount in the player's inventory.
        itemAmount++;

        // Invoke the OnBuy event to update the player's coins display.
        OnBuy?.Invoke(shop.Items[index].price, playerText);

        // Add the bought item to the player's inventory.
        inventoryContainer.Items.Add(shop.Items[index]);

        // Create a new inventory button (UI element) for the bought item and add it to the inventory panel.
        var obj = Instantiate(button, inventoryPanel[0]);
        display = obj.GetComponent<ItemDisplay>();
        display.serialNumber = Random.value;
        display.item = shop.Items[index];
        inventoryContainer.Buttons.Add(obj);

        // Add a click listener to the button for equipping or selling the item.
        obj.onClick.AddListener(() =>
        {
            if (shopManager.IsShopping)
                Sell(inventoryContainer.Buttons.IndexOf(obj));
            else
                equipManager.EquipCloth(inventoryContainer.Buttons.IndexOf(obj));
        });

        // Set the image of the button to display the item's sprite.
        obj.GetComponentInChildren<Image>().sprite = shop.Sprite[index].sprite;
    }

    // Summary: Handles the process of selling an item from the player's inventory.
    private void Sell(int index)
    {
        // Check if the player is in the shop (not in the inventory).
        if (!shopManager.IsShopping)
            return;

        // Invoke the OnSell event to update the player's coins display.
        OnSell?.Invoke(inventoryContainer.Items[index].sellPrice, playerText);

        // Remove the sold item from the player's inventory list.
        inventoryContainer.Items.RemoveAt(index);

        // Destroy the corresponding inventory button (UI element).
        var buttonToRemove = inventoryContainer.Buttons[index];
        Destroy(buttonToRemove.gameObject);

        // Remove the button reference from the inventory buttons list.
        inventoryContainer.Buttons.RemoveAt(index);

        // Decrement the item amount in the player's inventory.
        itemAmount--;
    }

    // Summary: Handles interactions with the inventory panel, toggling it on and off.
    public void InventoryInteract()
    {
        switch (shopManager.IsShopping)
        {
            // If not in the shop and the inventory is closed, open it.
            case false when !isInventoryOpen:
                isInventoryOpen = true;
                foreach (var inventory in inventoryPanel)
                    inventory.gameObject.SetActive(true);
                break;

            // If not in the shop and the inventory is open, close it.
            case false when isInventoryOpen:
                isInventoryOpen = false;
                foreach (var inventory in inventoryPanel)
                    inventory.gameObject.SetActive(false);
                break;
        }
    }
}

}