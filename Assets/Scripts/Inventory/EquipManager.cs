using System.Collections.Generic;
using System.Linq;
using Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class EquipManager : MonoBehaviour
    {
        // Summary: EquipManager class is responsible for managing the equipping and unequipping of items in the game.
// Import necessary libraries or namespaces here, if not already done in the file.
// Summary: EquipManager is a MonoBehaviour class used to manage equipping and unequipping of items.

            // Summary: Private field to store a list of currently equipped items.
            [SerializeField] private List<Item> equippedItems = new();
            // Summary: Private reference to the InventoryContainer that holds player inventory data.
            [SerializeField] private InventoryContainer inventoryContainer;
            // Summary: Private list of unEquippedButtons to represent the buttons for unequipped items.
            [SerializeField] private List<Button> unEquippedButtons = new();
            // Summary: Private list of TextMeshProUGUI elements for displaying item-related text.
            [SerializeField] private List<TextMeshProUGUI> text;
            // Summary: Private list of default sprites for items when they are not equipped.
            [SerializeField] private List<Sprite> defaultSprites = new();
            // Summary: Private list of Image components for item buttons.
            [SerializeField] private List<Image> buttonImage = new();
            // Summary: Private list of ItemDisplay components representing unequipped items.
            [SerializeField] private List<ItemDisplay> unequippedItems = new();
            // Summary: Private list of SpriteRenderer components representing player's clothes.
            [SerializeField] private List<SpriteRenderer> playerCloth = new();
            // Summary: Reference to the ItemDisplay component used for displaying items.
            private ItemDisplay display;
            // Summary: Called when the script is awakened. Sets up default sprite images for buttons and player's clothes.
            private void Awake()
            {
                for (var i = 0; i < unEquippedButtons.Count; i++)
                {
                    buttonImage[i].sprite = defaultSprites[i];
                    playerCloth[i].sprite = defaultSprites[i];
                }
            }
            // Summary: Equips an item based on its index in the inventory.
            public void EquipCloth(int index)
            {
                // Check the type of the item based on its ID to determine the equipment slot.
                switch (inventoryContainer.Items[index].id)
                {
                    case >= 0 and < 5:
                        // Hat item
                        const Items.Items hatEnumValue = Items.Items.Hat;
                        EquipItem(0, index);

                        // Adjust the interactability of unEquippedButtons based on the equipped items.
                        foreach (var t in inventoryContainer.Buttons)
                        {
                            var itemDisplay = t.GetComponent<ItemDisplay>();
                            switch (itemDisplay.item.item)
                            {
                                case hatEnumValue when equippedItems[0].id == itemDisplay.item.id &&
                                                       itemDisplay.serialNumber.Equals(unequippedItems[0].SerialNumber):
                                    t.interactable = false;
                                    break;
                                case hatEnumValue when equippedItems[0].id != itemDisplay.item.id:
                                case hatEnumValue when equippedItems[0].id == itemDisplay.item.id:
                                    t.interactable = true;
                                    break;
                            }
                        }

                        break;
                    case >= 5 and < 10:
                        // Armor item
                        const Items.Items armorEnumValue = Items.Items.Armor;
                        EquipItem(1, index);
                        // Adjust the interactability of unEquippedButtons based on the equipped items.
                        foreach (var t in inventoryContainer.Buttons)
                        {
                            var itemDisplay = t.GetComponent<ItemDisplay>();

                            switch (itemDisplay.item.item)
                            {
                                case armorEnumValue when equippedItems[1].id == itemDisplay.item.id &&
                                                         itemDisplay.serialNumber.Equals(
                                                             unequippedItems[1].SerialNumber):
                                    t.interactable = false;
                                    break;
                                case armorEnumValue when equippedItems[1].id != itemDisplay.item.id:
                                case armorEnumValue when equippedItems[1].id == itemDisplay.item.id:
                                    t.interactable = true;
                                    break;
                            }
                        }

                        break;
                    case >= 10 and < 15:
                        // Mask item
                        const Items.Items maskEnumValue = Items.Items.Mask;
                        EquipItem(2, index);

                        // Adjust the interactability of unEquippedButtons based on the equipped items.
                        foreach (var t in inventoryContainer.Buttons)
                        {
                            var itemDisplay = t.GetComponent<ItemDisplay>();

                            switch (itemDisplay.item.item)
                            {
                                case maskEnumValue when equippedItems[2].id == itemDisplay.item.id &&
                                                        itemDisplay.serialNumber.Equals(unequippedItems[2].SerialNumber)
                                    :
                                    t.interactable = false;
                                    break;
                                case maskEnumValue when equippedItems[2].id != itemDisplay.item.id:
                                case maskEnumValue when equippedItems[2].id == itemDisplay.item.id:
                                    t.interactable = true;
                                    break;
                            }
                        }

                        break;
                    case >= 15 and < 20:
                        // Skirt item
                        const Items.Items skirtEnumValue = Items.Items.Skirt;
                        EquipItem(3, index);

                        // Adjust the interactability of unEquippedButtons based on the equipped items.
                        foreach (var t in inventoryContainer.Buttons)
                        {
                            var itemDisplay = t.GetComponent<ItemDisplay>();

                            switch (itemDisplay.item.item)
                            {
                                case skirtEnumValue when equippedItems[3].id == itemDisplay.item.id &&
                                                         itemDisplay.serialNumber.Equals(
                                                             unequippedItems[3].SerialNumber):
                                    t.interactable = false;
                                    break;
                                case skirtEnumValue when equippedItems[3].id != itemDisplay.item.id:
                                case skirtEnumValue when equippedItems[3].id == itemDisplay.item.id:
                                    t.interactable = true;
                                    break;
                            }
                        }
                        break;
                }
            }

            // Summary: Unequips an item based on its index in the equippedItems list.
            public void UnEquipCloth(int index)
            {
                // Check if the given index is valid within the equippedItems list.
                switch (index)
                {
                    case >= 0 when index < equippedItems.Count:
                        equippedItems[index] = null;
                        Items.Items enumValue;
                        switch (index)
                        {
                            // Determine the item type and reset the corresponding item data.
                            case 0:
                                enumValue = Items.Items.Hat;
                                SetItem(index);
                                SetDefaultImage(index);
                                break;
                            case 1:
                                enumValue = Items.Items.Armor;
                                SetItem(index);
                                SetDefaultImage(index);
                                break;
                            case 2:
                                enumValue = Items.Items.Mask;
                                SetItem(index);
                                SetDefaultImage(index);
                                break;
                            case 3:
                                enumValue = Items.Items.Skirt;
                                SetItem(index);
                                SetDefaultImage(index);
                                break;
                            default:
                                return;
                        }

                        // Make the corresponding unEquippedButtons interactable again.
                        foreach (var containerButton in from containerButton in inventoryContainer.Buttons
                                 let itemDisplay = containerButton.GetComponent<ItemDisplay>()
                                 where itemDisplay.item.item == enumValue
                                 select containerButton)
                        {
                            containerButton.interactable = true;
                        }
                        break;
                }
            }
            
            // Summary: Sets the default sprite image for an item button and player's clothes based on the index.
            private void SetDefaultImage(int index)
            {
                // Check if the item in the display is null to set the default sprite for the button.
                if (display.item == null)
                    buttonImage[index].sprite = defaultSprites[index];

                // Set the default sprite for the player's clothes.
                playerCloth[index].sprite = defaultSprites[index];
            }

// Summary: Resets the item in the display (unequipped button) to null.
            private void SetItem(int index)
            {
                // Get the ItemDisplay component of the unequipped button at the given index.
                display = unEquippedButtons[index].GetComponent<ItemDisplay>();

                // Reset the item in the display to null.
                display.item = null;
            }

// Summary: Equips an item based on the button index and item index in the inventory.
            private void EquipItem(int buttonIndex, int index)
            {
                // Set the equipped item at the corresponding button index in the equippedItems list.
                equippedItems[buttonIndex] = inventoryContainer.Items[index];

                // Set the item of the unequipped button at the corresponding button index in the unequippedItems list.
                unequippedItems[buttonIndex].item = equippedItems[buttonIndex];

                // Get the ItemDisplay component of the inventory button at the given index.
                var inputSn = inventoryContainer.Buttons[index].GetComponent<ItemDisplay>();

                // Set the serial number of the unequipped button to match the input button's serial number.
                unequippedItems[buttonIndex].serialNumber = inputSn.SerialNumber;

                // Set the sprite of the item button to display the equipped item's sprite.
                buttonImage[buttonIndex].sprite = equippedItems[buttonIndex].sprite;

                // Set the sprite of the player's cloth to display the equipped item's sprite.
                playerCloth[buttonIndex].sprite = equippedItems[buttonIndex].sprite;
            }
        }
    }

    



    
  

