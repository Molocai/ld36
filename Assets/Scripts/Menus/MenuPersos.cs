using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    [RequireComponent(typeof(RectTransform))]
    public class MenuPersos : MonoBehaviour
    {
        [Tooltip("Affichage des commandes du 2ème joueur")]
        public Text commandes2;
        [Tooltip("Affichage des commandes du 3ème joueur")]
        public Text commandes3;
        [Tooltip("Affichage des commandes du 4ème joueur")]
        public Text commandes4;
        [Tooltip("Boutons de sélection des personnages")]
        public BoutonPerso[] persos;

        /// <summary>
        /// Nombre de joueurs
        /// </summary>
        private int nbPlayers;

        /// <summary>
        /// Personnages sélectionnés par les joueurs
        /// </summary>
        private int[] selected;

        public void Reload()
        {
            nbPlayers = GameManager.Get.NbPlayers;

            commandes2.gameObject.SetActive(nbPlayers >= 2);
            commandes3.gameObject.SetActive(nbPlayers >= 3);
            commandes4.gameObject.SetActive(nbPlayers == 4);

            foreach (BoutonPerso bouton in persos)
            {
                bouton.Reload();
            }

            selected = new int[nbPlayers];

            for (int i = 0; i < nbPlayers; i++)
            {
                persos[i].SetSelected(i, true);
                selected[i] = i;
            }
        }

        void Update()
        {
            Move1();
            if (nbPlayers >= 2)
            {
                Move2();
            }
        }

        void Move1()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                persos[selected[0]].ChangeImage(true);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                persos[selected[0]].ChangeImage(false);
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
                persos[selected[1]].ChangeImage(true);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                persos[selected[1]].ChangeImage(false);
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

        void ChangePerso(int player, bool right)
        {
            persos[selected[player]].SetSelected(player, false);
            if (right)
            {
                selected[player]++;
                if (selected[player] >= persos.Length)
                {
                    selected[player] = 0;
                }
            }
            else
            {
                selected[player]--;
                if (selected[player] < 0)
                {
                    selected[player] = persos.Length - 1;
                }
            }
            persos[selected[player]].SetSelected(player, true);
        }
    }
}