using UnityEngine;
using System.Collections;

namespace LD36
{
    public class PlayerBase : MonoBehaviour
    {
        [HideInInspector()]
        public PlayerController playerController;

        void Start()
        {
            playerController = GetComponent<PlayerController>();
        }
    }
}