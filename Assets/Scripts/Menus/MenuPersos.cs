using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    [RequireComponent(typeof(RectTransform))]
    public class MenuPersos : MonoBehaviour
    {
        [Tooltip("Affichage des commandes")]
        public Text[] commandes;
        [Tooltip("Boutons de sélection des personnages")]
        public BoutonPerso[] boutons;
        [Tooltip("Bouton pour lancer la partie")]
        public Button lancer;

        /// <summary>
        /// Nombre de joueurs
        /// </summary>
        private int nbPlayers;

        /// <summary>
        /// Détermine si tous les joueurs ont choisi un personnage
        /// </summary>
        private bool[] valides;

        public void Reload()
        {
            nbPlayers = GameManager.Get.NbPlayers;

            valides = new bool[nbPlayers];

            for (int i = 0; i < 4; i++)
            {
                commandes[i].gameObject.SetActive(nbPlayers > i);
                boutons[i].Reload();
                boutons[i].gameObject.SetActive(nbPlayers > i);
                if (i < nbPlayers)
                {
                    valides[i] = false;
                }
            }
        }

        void Update()
        {
            GameManager game = GameManager.Get;
            GameManager.Clavier clavier = game.clavier;
            GameInput[] inputs = game.keybindings;

            for (int i = 0; i < nbPlayers; i++)
            {
                if (!valides[i])
                {
                    Move(i);
                }
                if ((clavier == GameManager.Clavier.AZERTY && Input.GetKeyDown(inputs[i].UseKey.azertyKey)
                    || clavier == GameManager.Clavier.QWERTY && Input.GetKeyDown(inputs[i].UseKey.qwertyKey)))
                {
                    Selection(i);
                }
            }
        }

        void Move(int player)
        {
            GameManager game = GameManager.Get;
            GameManager.Clavier clavier = game.clavier;
            GameInput[] inputs = game.keybindings;

            if (clavier == GameManager.Clavier.AZERTY)
            {
                if (Input.GetKeyDown(inputs[player].UpKey.azertyKey))
                {
                    boutons[player].ChangeImage(true);
                }
                if (Input.GetKeyDown(inputs[player].DownKey.azertyKey))
                {
                    boutons[player].ChangeImage(false);
                }
            }
        }

        void Selection(int player)
        {
            if (valides[player])
            {
                valides[player] = false;
            }
            else
            {
                GameManager.Get.SetSkin(player, boutons[player].GetCurrentSprite());
                valides[player] = true;
            }
            CheckLancer();
        }

        void CheckLancer()
        {
            bool result = true;
            foreach (bool valide in valides)
            {
                result &= valide;
            }
            lancer.gameObject.SetActive(result);
        }
    }
}