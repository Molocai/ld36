using UnityEngine;
using System.Collections;

namespace LD36
{
    [RequireComponent(typeof(PlayerBase))]
    public class PlayerDisplay : PlayerBase
    {
        public Transform engineBone;
        public ParticleSystem wheelParticles;

        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void UpdateParticles(Vector2 velocity, float multiplier = 1000)
        {
            wheelParticles.emissionRate = velocity.magnitude * multiplier;
        }

        public void UpdateAnimations(Vector2 velocity)
        {
            animator.SetFloat("Speed", velocity.magnitude * 1000);
        }

        void LateUpdate()
        {
            GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100);
        }
    }
}