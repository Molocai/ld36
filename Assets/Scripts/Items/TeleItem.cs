using UnityEngine;
using System.Collections;

namespace LD36
{
    public class TeleItem : MonoBehaviour
    {
        [HideInInspector()]
        public PlayerBase playerToIgnore;

        public AudioClip impactSound;
        public AudioClip goodSound;
        public GameObject effect;

        public bool bad = false;

        void Start()
        {
            GetComponentInChildren<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100);

            if (bad)
            {
                transform.position = playerToIgnore.transform.position + new Vector3(4, 5, 0);
                GetComponentInChildren<Animator>().SetBool("Bad", bad);
                StartCoroutine(StunTV(playerToIgnore, playerToIgnore.playerController.xAcceleration, playerToIgnore.playerController.yAcceleration));
            }

            else
            {
                GetComponent<AudioSource>().PlayOneShot(goodSound);
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerBase>() != null && collision.GetComponent<PlayerBase>() != playerToIgnore)
            {
                PlayerBase player = collision.GetComponent<PlayerBase>();

                StartCoroutine(WatchTv(player, player.playerController.xAcceleration, player.playerController.yAcceleration));
            }
        }

        IEnumerator WatchTv(PlayerBase player, float currentXAcceleration, float currentYAcceleration)
        {
            player.playerController.xAcceleration = 0;
            player.playerController.yAcceleration = 0;
            yield return new WaitForSeconds(3f);

            player.playerController.xAcceleration = currentXAcceleration;
            player.playerController.yAcceleration = currentYAcceleration;
        }

        IEnumerator StunTV(PlayerBase player, float currentXAcceleration, float currentYAcceleration)
        {
            gameObject.transform.SetParent(player.gameObject.transform);
            AudioSource audio = GetComponent<AudioSource>();

            yield return new WaitForSeconds(1.2f);
            audio.PlayOneShot(impactSound);
            gameObject.transform.SetParent(null);
            GameObject particles = Instantiate(effect, player.playerDisplay.headBone.position, Quaternion.identity) as GameObject;

            player.playerController.xAcceleration = 0;
            player.playerController.yAcceleration = 0;
            player.playerController.currentVelocity = Vector2.zero;

            yield return new WaitForSeconds(2f);

            particles.GetComponent<Animator>().SetBool("Stop", true);
            Destroy(particles, 3f);

            player.playerController.xAcceleration = currentXAcceleration;
            player.playerController.yAcceleration = currentYAcceleration;
        }
    }
}