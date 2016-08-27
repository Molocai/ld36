using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    [RequireComponent(typeof(Button))]
    public class BoutonPerso : MonoBehaviour
    {
        [Tooltip("Couleurs disponibles pour ce personnage")]
        public Sprite[] sprites;

        /// <summary>
        /// Skin du perso affiché à l'écran
        /// </summary>
        private int currentSprite = 0;

        /// <summary>
        /// Est-ce que le bouton est sélectionné par un joueur ?
        /// </summary>
        private bool[] selected;

        /// <summary>
        /// Image du personnage
        /// </summary>
        private Image image;

        /// <summary>
        /// Couleurs de survol pour les joueurs
        /// </summary>
        private static Color[] colors =
        {
            Color.blue,
            Color.red,
            Color.green,
            Color.yellow
        };

        public void Reload()
        {
            image = GetComponent<Image>();
            selected = new bool[4];
            for (int i = 0; i < 4; i++)
            {
                SetSelected(i, false);
            }
            currentSprite = 0;
            UpdateImage();
        }

        public void SetSelected(int player, bool select)
        {
            selected[player] = select;
            UpdateColor();
        }

        public void ChangeImage(bool up)
        {
            if (up)
            {
                currentSprite++;
                if (currentSprite >= sprites.Length)
                {
                    currentSprite = 0;
                }
            }
            else
            {
                currentSprite--;
                if (currentSprite < 0)
                {
                    currentSprite = sprites.Length - 1;
                }
            }
            UpdateImage();
        }

        void UpdateImage()
        {
            image.sprite = sprites[currentSprite];
        }

        void UpdateColor()
        {
            int nbSelect = 0;
            Vector4 finalColor = Vector4.zero;
            for (int i = 0; i < 4; i++)
            {
                if (selected[i])
                {
                    nbSelect++;
                    Vector4 col = colors[i];
                    finalColor += col;
                }
            }
            
            if (nbSelect > 0)
            {
                Color col = finalColor / nbSelect;
                col.a = 1f;
                image.color = col;
            }
            else
            {
                image.color = Color.white;
            }
        }

        public int GetCurrentSprite()
        {
            return currentSprite;
        }
    }
}