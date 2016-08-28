using UnityEngine;
using UnityEngine.UI;

namespace LD36
{

    public class DisplayPersos : MonoBehaviour
    {

        public ImgAQ upImg;
        public ImgAQ downImg;
        public ImgAQ moveImg;

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
        }
    }
}