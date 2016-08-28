using UnityEngine;
using System.Collections;

namespace LD36
{
    public class ChienItem : MonoBehaviour
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
            audioSource.clip = sound;
            audioSource.Play();
        }

        void OnDestroy()
        {
            pc.xAcceleration -= value;
            pc.xMaxVelocity -= value;
        }
    }
}