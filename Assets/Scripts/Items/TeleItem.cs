using UnityEngine;
using System.Collections;

namespace LD36
{
    public class TeleItem : MonoBehaviour
    {
        [HideInInspector()]
        public PlayerBase playerToIgnore;

        public bool bad = false;

        void Start()
        {
            if (!bad)
            {
                foreach(BoxCollider2D box in GetComponents<BoxCollider2D>())
                {
                    if (box.isTrigger)
                        Destroy(box);
                }
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerBase>() != null && collision.GetComponent<PlayerBase>() != playerToIgnore)
            {
                PlayerBase player = collision.GetComponent<PlayerBase>();

                StartCoroutine(WatchTv(player, player.playerController.xAcceleration));
            }
        }

        IEnumerator WatchTv(PlayerBase player, float currentXAcceleration)
        {
            player.playerController.xAcceleration = 0;
            yield return new WaitForSeconds(3f);

            player.playerController.xAcceleration = currentXAcceleration;
        }
    }
}