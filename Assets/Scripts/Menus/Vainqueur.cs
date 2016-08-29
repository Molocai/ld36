using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    [RequireComponent(typeof(Image))]
    public class Vainqueur : MonoBehaviour
    {
        private Image image;

        // Use this for initialization
        void Start()
        {
            Reload();
        }

        // Update is called once per frame
        public void Reload()
        {
            GetComponent<Image>().sprite = GameManager.Get.winnerSprite;
        }
    }
}