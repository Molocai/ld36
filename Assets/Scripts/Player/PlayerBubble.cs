using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    public class PlayerBubble : MonoBehaviour
    {
        [Tooltip("Canvas contenant l'image de la bulle et le texte affichant la distance")]
        public Canvas bubble;
        [Tooltip("Distance séparant le personnage du coin de la caméra")]
        public Text distance;
        [Range(0, 5)]
        [Tooltip("Décimales après la virgule pour la distance")]
        public int arrondi = 1;

        private Renderer ren;

        // Use this for initialization
        void Start()
        {
            bubble.gameObject.SetActive(false);
            ren = GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            bubble.gameObject.SetActive(!IsVisible());
            distance.text = CalcDist() + "m";
        }

        float CalcDist()
        {
            Camera cam = Camera.main;
            float width = cam.orthographicSize * cam.pixelWidth / cam.pixelHeight;
            float dist = cam.transform.position.x - transform.position.x - width;
            float power = Mathf.Pow(10f, arrondi);

            return Mathf.Round(dist * power) / power;
        }

        bool IsVisible()
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
            return GeometryUtility.TestPlanesAABB(planes, ren.bounds);
        }
    }
}