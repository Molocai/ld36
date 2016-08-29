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
        void Start()
        {
            InvokeRepeating("CheckForNewTarget", 3, 1);
        }

        void Update()
        {
            if (target != null)
            {
                Vector3 newPos = new Vector3(Mathf.Lerp(transform.position.x, target.transform.position.x, Time.deltaTime * smoothDelay), transform.position.y, transform.position.z);
                transform.position = newPos;
            }
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