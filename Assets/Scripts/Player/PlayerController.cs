using UnityEngine;
using System.Collections;

namespace LD36
{
    [RequireComponent(typeof(PlayerBase))]
    public class PlayerController : PlayerBase
    {
        [Header("Player movements")]
        /// <summary>
        /// How fast the player accelerates to the right
        /// </summary>
        public float xAcceleration = 1f;

        /// <summary>
        /// How fast the player accelerates up and down
        /// </summary>
        public float yAcceleration = 1f;

        [Header("Constraints")]
        /// <summary>
        /// Maximum value for the velocity vector on the x axis
        /// </summary>
        public float xMaxVelocity = 1f;

        /// <summary>
        /// Maximum value for the velocity vector on the y axis
        /// </summary>
        public float yMaxVelocity = 1f;

        /// <summary>
        /// Speed at which the velocity decays
        /// </summary>
        public float velocityDecaySpeed = 2f;

        [Header("Player inputs")]
        public GameInput playerInputs;

        [Header("Sounds")]
        public AudioClip wheelsSound;
        [Range(0f, 1f)]
        public float wheelsVolume;

        public AudioClip collisionSound;
        [Range(0f, 1f)]
        public float collisionVolume;

        /// <summary>
        /// Current velocity
        /// </summary>
        [HideInInspector()]
        public Vector2 currentVelocity;

        void Update()
        {
            if (Input.GetKeyDown(playerInputs.MoveKey.azertyKey))
            {
                currentVelocity.x += xAcceleration * Time.deltaTime;
                audioSource.clip = wheelsSound;
                audioSource.volume = wheelsVolume;
                if (!audioSource.isPlaying)
                    audioSource.Play();
            }

            if (Input.GetKeyDown(playerInputs.UpKey.azertyKey))
            {
                currentVelocity.y += yAcceleration * Time.deltaTime;
            }

            if (Input.GetKeyDown(playerInputs.DownKey.azertyKey))
            {
                currentVelocity.y -= yAcceleration * Time.deltaTime;
            }

            ApplyAndClampVelocity();
            playerDisplay.UpdateParticles(currentVelocity);
            playerDisplay.UpdateAnimations(currentVelocity, xMaxVelocity);
        }

        /// <summary>
        /// Clamps the velocity to a max value and moves the player towards the velocity direction
        /// </summary>
        private void ApplyAndClampVelocity()
        {
            // Clamp velocity to max value
            currentVelocity.x = currentVelocity.x > xMaxVelocity ? xMaxVelocity : currentVelocity.x;
            currentVelocity.y = currentVelocity.y > yMaxVelocity ? yMaxVelocity : currentVelocity.y;

            // Move towards new position taking velocity into account
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(currentVelocity.x, currentVelocity.y), float.PositiveInfinity);
            // Apply decay
            DecayVelocity();
        }

        /// <summary>
        ///  Reduces the velocity over time
        /// </summary>
        private void DecayVelocity()
        {
            currentVelocity = Vector2.Lerp(currentVelocity, Vector2.zero, Time.deltaTime * velocityDecaySpeed);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerBase otherPlayer = collision.gameObject.GetComponent<PlayerBase>();

            if (otherPlayer != null)
            {
                if (!GameManager.Get.audioSource.isPlaying)
                {
                    GameManager.Get.audioSource.clip = collisionSound;
                    GameManager.Get.audioSource.Play();
                }
            }
        }
    }
}