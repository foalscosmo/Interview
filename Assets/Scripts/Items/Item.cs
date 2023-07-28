using UnityEngine;

namespace Items
{
    // Summary: This C# script defines an enum called "Items" and a ScriptableObject class named "Item" to represent cloth items in a 2D game using Unity. Each item has properties like an item name (item), an identification number (id), a serial number (serial), a Sprite for visual representation (sprite), a buying price (price), and a selling price (sellPrice).

// Enum representing different types of cloth items:
    public enum Items
    {
        Hat,
        Mask,
        Armor,
        Skirt,
    }

// ScriptableObject class for cloth items:
    [CreateAssetMenu(fileName = "New Item", menuName = "Items/Cloth")]
    public class Item : ScriptableObject
    {
        public Items item; // The type of the item (Hat, Mask, Armor, Skirt).
        public int id; // Identification number for the item.
        public float serial; // A serial number for the item (could represent a unique identifier).
        public Sprite sprite; // The visual representation of the item as a Sprite.
        public int price; // The buying price of the item.
        public int sellPrice; // The selling price of the item.
    }
}