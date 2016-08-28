using UnityEngine;
using System.Collections;

namespace LD36
{
    public class RoueCourseItem : MonoBehaviour
    {
        public float value;
        public AudioClip sound;
        private PlayerController pc;

        public void Init(PlayerController pc)
        {
            this.pc = pc;
            pc.xAcceleration += value;
            pc.xMaxVelocity += value;

            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound);
        }

        void OnDestroy()
        {
            pc.xAcceleration -= value;
            pc.xMaxVelocity -= value;
        }
    }
}