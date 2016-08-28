using UnityEngine;
using System.Collections;

namespace LD36
{
    public class ReactorItem : MonoBehaviour
    {
        public float value;
        public SpriteRenderer flammesBleues;
        public AudioClip sound;

        private PlayerController pc;
        private AudioSource source;

        float timer = 8;

        public void Init(PlayerController pc)
        {
            source = GetComponent<AudioSource>();
            this.pc = pc;
            pc.playerDisplay.DisplayFlammes(false);
        }

        void Update()
        {
            timer += Time.deltaTime;

            if (timer >= 10)
            {
                StartCoroutine(PushInDirection());
                timer = 0;
            }
        }

        public IEnumerator PushInDirection()
        {
            source.PlayOneShot(sound);
            pc.currentVelocity = new Vector2(value, 0);
            flammesBleues.enabled = true;
            yield return new WaitForSeconds(1f);
            flammesBleues.enabled = false;
        }
    }
}