using UnityEngine;
using System.Collections;
using System;

namespace LD36
{
    public class MapManager : MonoBehaviour
    {
        public GameObject[] spawns;
        public GameObject playerPrefab;

        public static Action OnPlayerSpawned;

        void Start()
        {
            int nbPlayers = GameManager.Get.NbPlayers;
            //int nbPlayers = 4;
            for (int i = 0; i < nbPlayers; i++)
            {
                GameObject player = Instantiate(playerPrefab, spawns[i].transform.position, Quaternion.identity) as GameObject;
                PlayerController playerController = player.GetComponentInChildren<PlayerController>();
                playerController.playerInputs = GameManager.Get.keybindings[i];
                playerController.inputsEnabled = false;
                player.GetComponentInChildren<PlayerDisplay>().spriteId = i;

                Animator animator = playerController.GetComponent<Animator>();
                animator.SetInteger("SpriteId", GameManager.Get.Skins[i]);
                //animator.SetInteger("SpriteId", i);

                StartCoroutine(StartCountdown());
            }
        }

        public IEnumerator StartCountdown()
        {
            yield return new WaitForSeconds(3f);

            GetComponent<AudioSource>().Play();
            foreach (PlayerBase p in GameObject.FindObjectsOfType<PlayerBase>())
            {
                p.playerController.inputsEnabled = true;
            }
        }
    }
}