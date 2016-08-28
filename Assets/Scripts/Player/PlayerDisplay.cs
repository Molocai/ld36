using UnityEngine;
using System.Collections;

namespace LD36
{
    [RequireComponent(typeof(PlayerBase))]
    public class PlayerDisplay : PlayerBase
    {
        public int spriteId;

        public Transform goodReactorBone;
        public Transform badReactorBone;

        public Transform goodIenchBone;
        public Transform badIenchBone;

        public Transform goodRoueCourseBone;
        public Transform badRoueCourseBone;

        public Transform headBone;

        public ParticleSystem wheelParticles;

        public GameObject flammes;

        private Animator animator;
        private Animator flammesAnimator;

        void Start()
        {
            animator = GetComponent<Animator>();
            flammesAnimator = flammes.GetComponent<Animator>();
        }

        public void UpdateParticles(Vector2 velocity, float multiplier = 1000)
        {
            wheelParticles.emissionRate = velocity.magnitude * multiplier;
        }

        public void UpdateAnimations(Vector2 velocity, float xMaxVelocity)
        {
            animator.SetFloat("Speed", velocity.magnitude * 1000);
            flammesAnimator.SetInteger("Intensity", Mathf.RoundToInt((velocity.magnitude / xMaxVelocity) * 30));
        }

        void LateUpdate()
        {

            foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
            {
                sr.sortingOrder = -(int)(transform.position.y * 100);
            }

            GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100) - 1;
        }

        public void DisplayFlammes(bool display)
        {
            flammes.GetComponent<SpriteRenderer>().enabled = display;
        }
    }
}