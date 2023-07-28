using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    // Summary: InventoryContainer class is responsible for managing a list of items and buttons, with a maximum size.

// Import necessary libraries or namespaces here, if not already done in the file.
// Summary: InventoryContainer is a MonoBehaviour class used to manage inventory-related functionality.
    public class InventoryContainer : MonoBehaviour
    {
        // Summary: Private field to store a list of items.
        // The [SerializeField] attribute allows this list to be visible in the Unity Inspector.
        [SerializeField] private List<Item> items = new();
        
        // Summary: Private field to store a list of buttons.
        // The [SerializeField] attribute allows this list to be visible in the Unity Inspector.
        [SerializeField] private List<Button> buttons = new();

        // Summary: Private field to store the maximum size allowed for the lists.
        // The [SerializeField] attribute allows this value to be visible in the Unity Inspector.
        [SerializeField] private int maxSize = 20;
        // Summary: Property to provide read-only access to the 'items' list.
        public List<Item> Items => items;
        
        // Summary: Property to provide read-only access to the 'buttons' list.
        public List<Button> Buttons => buttons;

        // Summary: Property to provide read-only access to the 'maxSize' variable.
        public int MaxSize => maxSize;
    }

}