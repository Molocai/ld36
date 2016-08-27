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
        /// Est-ce que le perso est sélectionné par le joueur 1
        /// </summary>
        private bool selected1 = false;

        /// <summary>
        /// Est-ce que le perso est sélectionné par le joueur 2
        /// </summary>
        private bool selected2 = false;

        /// <summary>
        /// Image du personnage
        /// </summary>
        private Image image;

        /// <summary>
        /// Couleur associée à la sélection du joueur 1
        /// </summary>
        private static Color color1 = Color.blue;

        /// <summary>
        /// Couleur associée à la sélection du joueur 2
        /// </summary>
        private static Color color2 = Color.red;

        public void Reload()
        {
            image = GetComponent<Image>();
            SetSelected(1, false);
            SetSelected(2, false);
            currentSprite = 0;
            UpdateImage();
        }

        public void SetSelected(int player, bool selected)
        {
            if (player == 1)
            {
                selected1 = selected;
            }
            else
            {
                selected2 = selected;
            }
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
            if (selected1 && selected2)
            {
                image.color = Color.Lerp(color1, color2, 0.5f);
            }
            else if (selected1)
            {
                image.color = color1;
            }
            else if (selected2)
            {
                image.color = color2;
            }
            else
            {
                image.color = Color.white;
            }
        }
    }
}