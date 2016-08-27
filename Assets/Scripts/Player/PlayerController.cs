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


        /// <summary>
        /// Current velocity
        /// </summary>
        private Vector2 currentVelocity;
        public Vector2 CurrentVelocity
        {
            get
            {
                return currentVelocity;
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentVelocity.x += xAcceleration * Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                currentVelocity.y += yAcceleration * Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                currentVelocity.y -= yAcceleration * Time.deltaTime;
            }

            ApplyAndClampVelocity();
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
    }
}