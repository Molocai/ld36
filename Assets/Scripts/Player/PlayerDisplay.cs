using UnityEngine;
using System.Collections;

namespace LD36
{
    [RequireComponent(typeof(PlayerBase))]
    public class PlayerDisplay : PlayerBase
    {
        public Transform engineBone;
        public ParticleSystem wheelParticles;

        public void UpdateParticles(Vector2 velocity, float multiplier = 1000)
        {
            wheelParticles.emissionRate = velocity.magnitude * multiplier;
        }
    }
}