using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    [RequireComponent(typeof(RectTransform))]
    public class MenuPersos : MonoBehaviour
    {
        [Tooltip("Affichage des commandes du 2ème joueur")]
        public Text commandes2;
        [Tooltip("Boutons de sélection des personnages")]
        public BoutonPerso[] persos;

        private int selected1 = 0;
        private int selected2 = 0;

        public void Reload()
        {
            bool twoPlayers = GameManager.Get.Are2Players();

            commandes2.gameObject.SetActive(twoPlayers);
            foreach (BoutonPerso bouton in persos)
            {
                bouton.Reload();
            }
            persos[0].SetSelected(1, true);
            selected1 = 0;
            if (twoPlayers)
            {
                persos[persos.Length - 1].SetSelected(2, true);
                selected2 = persos.Length - 1;
            }
        }

        void Update()
        {
            Move1();
            if (GameManager.Get.Are2Players())
            {
                Move2();
            }
        }

        void Move1()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                persos[selected1].ChangeImage(true);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                persos[selected1].ChangeImage(false);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangePerso(1, false);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                ChangePerso(1, true);
            }
        }

        void Move2()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                persos[selected2].ChangeImage(true);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                persos[selected2].ChangeImage(false);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChangePerso(2, false);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangePerso(2, true);
            }
        }

        void ChangePerso(int player, bool right)
        {
            if (player == 1)
            {
                persos[selected1].SetSelected(1, false);
                if (right)
                {
                    selected1++;
                    if (selected1 >= persos.Length)
                    {
                        selected1 = 0;
                    }
                }
                else
                {
                    selected1--;
                    if (selected1 < 0)
                    {
                        selected1 = persos.Length - 1;
                    }
                }
                persos[selected1].SetSelected(1, true);
            }
            else
            {
                persos[selected2].SetSelected(2, false);
                if (right)
                {
                    selected2++;
                    if (selected2 >= persos.Length)
                    {
                        selected2 = 0;
                    }
                }
                else
                {
                    selected2--;
                    if (selected2 < 0)
                    {
                        selected2 = persos.Length - 1;
                    }
                }
                persos[selected2].SetSelected(2, true);
            }
        }
    }
}