using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    [RequireComponent(typeof(Image))]
    public class DisplayPersos : MonoBehaviour
    {
        [Tooltip("Icone de touche Up")]
        public ImgAQ upImg;
        [Tooltip("Icone de touche Down")]
        public ImgAQ downImg;
        [Tooltip("Icone de touche Move")]
        public ImgAQ moveImg;
        [Tooltip("Icone de confirmation")]
        public Image confirm;
        [Tooltip("Image de nom")]
        public Image name;

        private Image image;

        // Use this for initialization
        void Start()
        {
            Reload();
        }

        public void Reload()
        {
            upImg.Reload();
            downImg.Reload();
            moveImg.Reload();
            confirm.gameObject.SetActive(false);
            image = GetComponent<Image>();
        }

        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }

        public void SetNom(Sprite sprite)
        {
            name.sprite = sprite;
        }

        public void SetConfirm(bool conf)
        {
            confirm.gameObject.SetActive(conf);
        }
    }
}