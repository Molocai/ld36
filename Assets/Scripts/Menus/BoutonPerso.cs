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
        /// Image du personnage
        /// </summary>
        private Image image;

        public void Reload()
        {
            image = GetComponent<Image>();
            currentSprite = 0;
            UpdateImage();
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

        public int GetCurrentSprite()
        {
            return currentSprite;
        }
    }
}