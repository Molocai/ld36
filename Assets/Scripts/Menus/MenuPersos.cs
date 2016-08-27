using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    [RequireComponent(typeof(RectTransform))]
    public class MenuPersos : MonoBehaviour
    {
        [Tooltip("Affichage des commandes du 3ème joueur")]
        public Text commandes3;
        [Tooltip("Affichage des commandes du 4ème joueur")]
        public Text commandes4;
        [Tooltip("Boutons de sélection des personnages")]
        public BoutonPerso[] boutons;
        [Tooltip("Bouton pour lancer la partie")]
        public Button lancer;

        /// <summary>
        /// Nombre de joueurs
        /// </summary>
        private int nbPlayers;

        /// <summary>
        /// Personnages sélectionnés par les joueurs
        /// </summary>
        private int[] selected;

        /// <summary>
        /// Détermine si tous les joueurs ont choisi un personnage
        /// </summary>
        private bool[] valides;

        public void Reload()
        {
            nbPlayers = GameManager.Get.NbPlayers;

            commandes3.gameObject.SetActive(nbPlayers >= 3);
            commandes4.gameObject.SetActive(nbPlayers == 4);

            foreach (BoutonPerso bouton in boutons)
            {
                bouton.Reload();
            }

            selected = new int[nbPlayers];
            valides = new bool[nbPlayers];

            for (int i = 0; i < nbPlayers; i++)
            {
                boutons[i].SetSelected(i, true);
                selected[i] = i;
                valides[i] = false;
            }
        }

        void Update()
        {
            if (!valides[0])
            {
                Move1();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Selection(0);
            }
            if (!valides[1])
            {
                Move2();
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Selection(1);
            }
            if (nbPlayers >= 3)
            {
                if (!valides[2])
                {
                    Move3();
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Selection(2);
                }
            }
            if (nbPlayers == 4)
            {
                if (!valides[3])
                {
                    Move4();
                }
                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Selection(3);
                }
            }
        }

        void Move1()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                boutons[selected[0]].ChangeImage(true);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                boutons[selected[0]].ChangeImage(false);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangePerso(0, false);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                ChangePerso(0, true);
            }
        }

        void Move2()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                boutons[selected[1]].ChangeImage(true);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                boutons[selected[1]].ChangeImage(false);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChangePerso(1, false);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangePerso(1, true);
            }
        }

        void Move3()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                boutons[selected[2]].ChangeImage(true);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                boutons[selected[2]].ChangeImage(false);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                ChangePerso(2, false);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                ChangePerso(2, true);
            }
        }

        void Move4()
        {
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                boutons[selected[3]].ChangeImage(true);
            }

            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                boutons[selected[3]].ChangeImage(false);
            }

            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                ChangePerso(3, false);
            }

            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                ChangePerso(3, true);
            }
        }

        void ChangePerso(int player, bool right)
        {
            boutons[selected[player]].SetSelected(player, false);
            if (right)
            {
                selected[player]++;
                if (selected[player] >= boutons.Length)
                {
                    selected[player] = 0;
                }
            }
            else
            {
                selected[player]--;
                if (selected[player] < 0)
                {
                    selected[player] = boutons.Length - 1;
                }
            }
            boutons[selected[player]].SetSelected(player, true);
        }

        void Selection(int player)
        {
            if (valides[player])
            {
                valides[player] = false;
            }
            else
            {
                GameManager.Get.SetPerso(player, selected[player]);
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