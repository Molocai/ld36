using UnityEngine;
using System.Collections;

namespace LD36
{
    public class CameraFollow : MonoBehaviour
    {
        /// <summary>
        /// Target to follow
        /// </summary>
        public PlayerBase target;

        /// <summary>
        /// Delay for the camera to catch up to the player
        /// </summary>
        public float smoothDelay = 2f;

        /// <summary>
        /// Offset the camera must maintain
        /// </summary>
        private Vector3 offset = new Vector3(0, 0, -10);

        void Start()
        {
            InvokeRepeating("CheckForNewTarget", 2, 2);
        }

        void Update()
        {
            if (target != null)
                transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * smoothDelay);
        }

        void CheckForNewTarget()
        {
            PlayerBase[] players = GameObject.FindObjectsOfType<PlayerBase>();
            PlayerBase numberOne = players[0];

            foreach(PlayerBase p in players)
            {
                if (p.transform.position.x > numberOne.transform.position.x)
                    numberOne = p;
            }

            target = numberOne;
        }
    }
}