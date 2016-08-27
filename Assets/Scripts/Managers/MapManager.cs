using UnityEngine;
using System.Collections;

namespace LD36
{
    public class MapManager : MonoBehaviour
    {
        public GameObject[] spawns;
        public GameObject playerPrefab;

        void Start()
        {
            int nbPlayers = 4; //GameManager.Get.NbPlayers;
            for (int i = 0; i < nbPlayers; i++)
            {
                GameObject player = Instantiate(playerPrefab, spawns[i].transform.position, Quaternion.identity) as GameObject;
                PlayerController playerController = player.GetComponentInChildren<PlayerController>();
                playerController.playerInputs = GameManager.Get.keybindings[i];
            }
        }
    }
}