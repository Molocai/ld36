using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    public class MenuPersos : MonoBehaviour
    {

        public Text commandes2;

        public void Reload()
        {
            commandes2.gameObject.SetActive(GameManager.Get.Are2Players());
        }
    }
}