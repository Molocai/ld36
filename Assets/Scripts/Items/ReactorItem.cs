using UnityEngine;
using System.Collections;

namespace LD36
{
    public class ReactorItem : MonoBehaviour
    {
        public float value;
        private PlayerController pc;

        float timer = 0;

        void Start()
        {
        }

        public void SetPlayerController(PlayerController pc)
        {
            this.pc = pc;
        }

        void Update()
        {
            timer += Time.deltaTime;

            if (timer >= 10)
            {
                PushInDirection();
                timer = 0;
            }
        }

        public void PushInDirection()
        {
            pc.currentVelocity = new Vector2(value, 0);
        }
    }
}