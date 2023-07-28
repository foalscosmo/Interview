using System;
using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;

namespace Shop
{
    public class ShopManager : MonoBehaviour
    {
        // Summary: This C# script manages a shop system and player interactions with it in a 2D game using Unity. It allows the player to open the shop and interact with shop panels when within a certain detection radius. The script handles the activation and deactivation of shop panels and player inventory.

        [SerializeField] private List<GameObject> shopSystem = new(); // List of GameObjects representing the shop panels.
        [SerializeField] private InventoryManager manager; // Reference to the InventoryManager script for inventory-related functionality.
        [SerializeField] private List<GameObject> inventory; // List of GameObjects representing the player's inventory panels.
        [SerializeField] private TextMeshProUGUI interactText; // Text object for displaying an interaction prompt.
        [SerializeField] private LayerMask playerLayer; // Layer mask to detect the player for interaction.
        [SerializeField] private float detectionRadius; // The radius for detecting the player's presence for interaction.
        private Collider2D[] _collider2D; // Array to store colliders of the player for interaction detection.
        private bool isShopping; // Flag to indicate if the player is currently shopping.
        private bool closeShop; // Flag to indicate if the shop should be closed.
        private bool closeInteraction; // Flag to indicate if the interaction prompt should be hidden.
        public bool IsShopping => isShopping; // Public property to check if the player is shopping.

        private void Awake()
        {
            // Deactivate all shop panels and the interaction prompt text initially.
            foreach (var panel in shopSystem)
            {
                panel.gameObject.SetActive(false);
            }

            interactText.gameObject.SetActive(false);
        }
        private void Update()
        {
            // Function to detect colliders within the detection radius of the player's position and with the playerLayer mask.
            Func<Vector2, float, int, Collider2D[]> overLapCircle = Physics2D.OverlapCircleAll;
            _collider2D = overLapCircle(transform.position, detectionRadius, playerLayer);

            // If the player is within the detection radius and interaction is not closed, show the interaction prompt text.
            if (_collider2D.Length > 0 && !closeInteraction)
                interactText.gameObject.SetActive(true);

            // If the player is within the detection radius:
            if (_collider2D.Length > 0)
            {
                closeShop = true; // Flag to indicate that the shop should be closed.
                // If 'E' key is pressed and the player is not already shopping:
                if (Input.GetKeyDown(KeyCode.E) && !isShopping)
                {
                    //set interaction flags.
                    closeInteraction = true;
                    interactText.gameObject.SetActive(false);
                    isShopping = true;
                    
                    // Deactivate player's inventory panels and activate shop panels.
                    foreach (var panels in inventory)  panels.gameObject.SetActive(false);
                    foreach (var panel in shopSystem)  panel.gameObject.SetActive(true);
                   
                }
                // If 'E' key is pressed and the player is already shopping:
                else if (Input.GetKeyDown(KeyCode.E) && isShopping)
                {
                    // reset shopping and interaction flags.
                    isShopping = false;
                    manager.IsInventoryOpen = false;
                    closeInteraction = false;
                    // Deactivate shop panels.
                    foreach (var panel in shopSystem) panel.gameObject.SetActive(false);
                   
                }
            }
            // If the player is not within the detection radius and the shop was previously open:
            else if (_collider2D.Length <= 0 && closeShop && isShopping)
            {
               // reset shopping and interaction flags, and hide the interaction prompt text.
                isShopping = false;
                manager.IsInventoryOpen = false;
                closeShop = false;
                interactText.gameObject.SetActive(false);
                closeInteraction = false;
                
                // Deactivate shop panels. 
                foreach (var panel in shopSystem ) panel.gameObject.SetActive(false);
               
                // Deactivate player's inventory panels.
                foreach (var panels in inventory) panels.gameObject.SetActive(false);
               
            }
            else
            {
                interactText.gameObject.SetActive(false);
            }
        }
    }
}