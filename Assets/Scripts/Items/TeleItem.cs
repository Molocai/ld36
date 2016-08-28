using UnityEngine;
using System.Collections;

namespace LD36
{
    public class TeleItem : MonoBehaviour
    {
        [HideInInspector()]
        public PlayerBase playerToIgnore;

        public AudioClip impactSound;

        public bool bad = false;

        void Start()
        {
            if (bad)
            {
                transform.position = playerToIgnore.transform.position + new Vector3(4, 5, 0);
                GetComponentInChildren<Animator>().SetBool("Bad", bad);
                StartCoroutine(StunTV(playerToIgnore, playerToIgnore.playerController.xAcceleration));
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

        IEnumerator StunTV(PlayerBase player, float currentXAcceleration)
        {
            gameObject.transform.SetParent(player.gameObject.transform);
            AudioSource audio = GetComponent<AudioSource>();

            yield return new WaitForSeconds(1.2f);
            audio.PlayOneShot(impactSound);
            gameObject.transform.SetParent(null);

            player.playerController.xAcceleration = 0;
            player.playerController.currentVelocity = Vector2.zero;

            yield return new WaitForSeconds(2f);

            player.playerController.xAcceleration = currentXAcceleration;
        }
    }
}