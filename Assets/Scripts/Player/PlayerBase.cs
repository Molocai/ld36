using UnityEngine;
using System.Collections;

namespace LD36
{
    public class PlayerBase : MonoBehaviour
    {
        // Public references to all player components
        [HideInInspector()]
        public PlayerController playerController;
        [HideInInspector()]
        public PlayerInventory playerInventory;
        [HideInInspector()]
        public PlayerBones playerBones;

        void Start()
        {
            // Initialization
            playerController = GetComponent<PlayerController>();
            playerInventory = GetComponent<PlayerInventory>();
            playerBones = GetComponent<PlayerBones>();
        }
    }
}