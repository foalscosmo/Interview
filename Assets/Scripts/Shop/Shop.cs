using System.Collections.Generic;
using Items;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;


namespace Shop
{
   // Summary: This Unity script manages the display of a list of items using TextMeshProUGUI and Image components in the Unity Inspector. It sets the price and sell price text and assigns the corresponding sprites to the Image components.
   public class Shop : MonoBehaviour
   {
      // Serialized fields for Unity Inspector:
      [SerializeField] private List<Item> items = new(); // List of Item objects to be displayed.
      [SerializeField] private List<TextMeshProUGUI> text = new(); // List of TextMeshProUGUI components for displaying item information.
      [SerializeField] private List<Image> sprite = new(); // List of Image components for displaying item sprites.
      // Public properties to access the lists from other scripts:
      public List<Item> Items => items; // Read-only property for accessing the list of items.
      public List<Image> Sprite => sprite; // Read-only property for accessing the list of sprite images.
      private void Awake()
      {
         // Loop through the list of items and assign their price and sell price text to the corresponding TextMeshProUGUI components:
         // Also, assign the item sprites to the corresponding Image components:
         for (var i = 0; i < items.Count; i++)
         {
            text[i].text = items[i].price + "$/" + items[i].sellPrice + "$";
            sprite[i].sprite = items[i].sprite;
         }
      }
   }

}