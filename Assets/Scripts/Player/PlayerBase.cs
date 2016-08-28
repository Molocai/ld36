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
        public PlayerTuning playerTuning;
        [HideInInspector()]
        public PlayerDisplay playerDisplay;
        [HideInInspector()]
        public PlayerBubble playerBubble;
        [HideInInspector()]
        public AudioSource audioSource;

        void Awake()
        {
            // Initialization
            playerController = GetComponent<PlayerController>();
            playerTuning = GetComponent<PlayerTuning>();
            playerDisplay = GetComponent<PlayerDisplay>();
            playerBubble = GetComponent<PlayerBubble>();
            audioSource = GetComponent<AudioSource>();
        }
    }
}