using UnityEngine;
using System.Collections;

namespace LD36
{
    public class ChienItem : MonoBehaviour
    {
        public float value;
        private PlayerController pc;

        public void SetPlayerController(PlayerController pc)
        {
            this.pc = pc;
            pc.xAcceleration += value;
            pc.xMaxVelocity += value;
        }

        void OnDestroy()
        {
            pc.xAcceleration -= value;
            pc.xMaxVelocity -= value;
        }
    }
}