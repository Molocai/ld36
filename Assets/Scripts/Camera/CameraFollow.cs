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

        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * smoothDelay);
        }
    }
}