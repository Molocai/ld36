using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    [RequireComponent(typeof(Image))]
    public class ImgAQ : MonoBehaviour
    {
        [Tooltip("Touche pour clavier azerty")]
        public Sprite azerty;
        [Tooltip("Touche pour clavier qwerty")]
        public Sprite qwerty;

        void Start()
        {
            Reload();
        }

        public void Reload()
        {
            GetComponent<Image>().sprite = GameManager.Get.clavier == GameManager.Clavier.AZERTY ? azerty : qwerty;
        }
    }
}