using System;
using UnityEngine;

namespace Shop
{
   // Summary: This C# script defines a ShopButton class that allows for creating custom shop buttons in Unity. It provides an event called OnShopButtonPressed, which other scripts can subscribe to. When the shop button is pressed, the ShopButtonIndex method is called to invoke the OnShopButtonPressed event and pass the index of the button as an argument.

   public class ShopButton : MonoBehaviour
   {
      // Event for notifying subscribers when the shop button is pressed. It carries an integer argument representing the index of the button.
      public event Action<int> OnShopButtonPressed;
      // Method to call when the shop button is pressed. It takes an integer index as an argument and invokes the OnShopButtonPressed event.
      public void ShopButtonIndex(int index)
      {
         // The ?. operator is used to check if OnShopButtonPressed is not null before invoking it to avoid null reference exceptions.
         OnShopButtonPressed?.Invoke(index);
      }
   }

}