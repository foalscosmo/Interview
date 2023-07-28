using UnityEngine;

namespace Items
{
     // Summary: This C# script represents an inventory slot for holding an "Item" object and a corresponding "serialNumber" associated with that item. It allows access to the "serialNumber" property through a public property "SerialNumber".

     public class ItemDisplay : MonoBehaviour
     {
          public Item item; // The Item object representing the item stored in this inventory slot.
          public float serialNumber; // The serial number associated with the item.
          // Public property that provides read-only access to the "serialNumber" field:
          public float SerialNumber => serialNumber;

     }
}