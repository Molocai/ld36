using UnityEngine;
using System.Collections;

namespace LD36
{
    public enum GOOD_BAD
    {
        GOOD,
        BAD
    }

    public class ItemPickup : MonoBehaviour
    {
        public GameObject goodItem;
        [Range(0f, 100f)]
        public float goodChance;
        public GameObject badItem;

        public void OnCollisionEnter2D(Collision2D collision)
        {
            // Verify it's a player that collides
            PlayerBase collidingPlayer = collision.gameObject.GetComponent<PlayerBase>();
            if (collidingPlayer == null)
                return;

            else
            {
                // Decide if good or bad item
                int rand = (int)Random.Range(0f, 101);

                // Pick up the item and destroy it
                collidingPlayer.playerTuning.PickupItem((rand < goodChance) ? goodItem : badItem, (rand < goodChance) ? GOOD_BAD.GOOD : GOOD_BAD.BAD);
                Destroy(gameObject);
            }
        }
    }
}