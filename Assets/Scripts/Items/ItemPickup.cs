using UnityEngine;
using System.Collections;

namespace LD36
{
    public class ItemPickup : MonoBehaviour
    {
        public GameObject itemPrefab;

        public void OnCollisionEnter2D(Collision2D collision)
        {
            // Verify it's a player that collides
            PlayerBase collidingPlayer = collision.gameObject.GetComponent<PlayerBase>();
            if (collidingPlayer == null)
                return;

            else
            {
                // Pick up the item and destroy it
                collidingPlayer.playerInventory.PickupItem(itemPrefab);
                Destroy(gameObject);
            }
        }
    }
}