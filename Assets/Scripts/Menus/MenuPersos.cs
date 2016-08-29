using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    [RequireComponent(typeof(RectTransform))]
    public class MenuPersos : MonoBehaviour
    {
        [Tooltip("Images de sélection des personnages")]
        public DisplayPersos[] persos;
        [Tooltip("Sprites disponibles")]
        public Sprite[] sprites;
        [Tooltip("Bouton pour lancer la partie")]
        public Button lancer;

        /// <summary>
        /// Nombre de joueurs
        /// </summary>
        private int nbPlayers;

        /// <summary>
        /// Détermine le skin choisi par les joueurs
        /// </summary>
        private int[] choix;

        /// <summary>
        /// Détermine si tous les joueurs ont choisi un personnage
        /// </summary>
        private bool[] valides;

        public void Reload()
        {
            nbPlayers = GameManager.Get.NbPlayers;

            choix = new int[nbPlayers];
            valides = new bool[nbPlayers];

            for (int i = 0; i < 4; i++)
            {
                persos[i].gameObject.SetActive(i < nbPlayers);
                if (i < nbPlayers)
                {
                    persos[i].Reload();
                    persos[i].SetSprite(sprites[0]);
                    choix[i] = 0;
                    valides[i] = false;
                }
            }
        }

        void Update()
        {
            GameManager.Clavier clavier = GameManager.Get.clavier;
            GameInput[] inputs = GameManager.Get.keybindings;

            for (int i = 0; i < nbPlayers; i++)
            {
                if (!valides[i])
                {
                    Move(i);
                }
                if ((clavier == GameManager.Clavier.AZERTY && Input.GetKeyDown(inputs[i].MoveKey.azertyKey))
                    || (clavier == GameManager.Clavier.QWERTY && Input.GetKeyDown(inputs[i].MoveKey.qwertyKey)))
                {
                    Selection(i);
                }
            }
        }

        void Move(int player)
        {
            GameManager.Clavier clavier = GameManager.Get.clavier;
            GameInput[] inputs = GameManager.Get.keybindings;

            if (clavier == GameManager.Clavier.AZERTY)
            {
                if (Input.GetKeyDown(inputs[player].UpKey.azertyKey))
                {
                    ChangeImage(player, true);
                }
                if (Input.GetKeyDown(inputs[player].DownKey.azertyKey))
                {
                    ChangeImage(player, false);
                }
            }
            else
            {
                if (Input.GetKeyDown(inputs[player].UpKey.qwertyKey))
                {
                    ChangeImage(player, true);
                }
                if (Input.GetKeyDown(inputs[player].DownKey.qwertyKey))
                {
                    ChangeImage(player, false);
                }
            }
        }

        void ChangeImage(int player, bool up)
        {
            Increment(ref choix[player], up);
            bool busy = true;
            while (busy)
            {
                busy = false;
                for (int i = 0; i < nbPlayers; i++)
                {
                    if (choix[player] == choix[i] && valides[i])
                    {
                        Increment(ref choix[player], up);
                        busy = true;
                        break;
                    }
                }
            }
            UpdateImage();
            FindObjectOfType<Menu>().PlayBouton();
        }

        void Increment(ref int start, bool up)
        {
            if (up)
            {
                start++;
                if (start >= sprites.Length)
                {
                    start = 0;
                }
            }
            else
            {
                start--;
                if (start < 0)
                {
                    start = sprites.Length - 1;
                }
            }
        }

        void UpdateImage()
        {
            for (int i = 0; i < nbPlayers; i++)
            {
                persos[i].SetSprite(sprites[choix[i]]);
                persos[i].SetConfirm(valides[i]);
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
                GameManager.Get.SetSkin(player, choix[player]);
                valides[player] = true;
                CheckSprites();
            }
            UpdateImage();
            CheckLancer();
            FindObjectOfType<Menu>().PlaySelect();
        }

        void CheckSprites()
        {
            bool busy = true;
            while (busy)
            {
                busy = false;
                for (int i = 0; i < nbPlayers; i++)
                {
                    if (!valides[i])
                    {
                        continue;
                    }
                    for (int j = 0; j < nbPlayers; j++)
                    {
                        if (!valides[j] && choix[j] == choix[i])
                        {
                            Increment(ref choix[j], true);
                            busy = true;
                        }
                    }
                }
            }
            UpdateImage();
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