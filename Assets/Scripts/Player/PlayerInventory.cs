using UnityEngine;
using System.Collections;

namespace LD36
{
    [RequireComponent(typeof(PlayerBase))]
    public class PlayerInventory : PlayerBase
    {
        /// <summary>
        /// The item the player owns
        /// </summary>
        private ItemBase currentItem;

        /// <summary>
        /// Uses the currently owned item
        /// </summary>
        public void UseItem()
        {
            if (currentItem != null)
            {
                // Use the item and remove it from the inventory
                currentItem.Use(this);
                currentItem = null;
            }
        }

        public void PickupItem(GameObject pickupItem)
        {
            currentItem = pickupItem.GetComponent<ItemBase>();
        }
    }
}