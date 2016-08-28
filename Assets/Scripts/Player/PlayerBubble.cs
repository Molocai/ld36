using UnityEngine;
using UnityEngine.UI;

namespace LD36
{
    public class PlayerBubble : PlayerBase
    {
        [Tooltip("Canvas contenant l'image de la bulle et le texte affichant la distance")]
        public Canvas bubble;
        [Tooltip("Distance séparant le personnage du coin de la caméra")]
        public Text distance;
        [Range(0, 5)]
        [Tooltip("Décimales après la virgule pour la distance")]
        public int arrondi = 1;

        private Renderer ren;
        private Image im;

        // Use this for initialization
        void Start()
        {
            Color[] colors = new Color[4];
            colors[0] = new Color(38f / 255f, 25f / 255f, 216f / 255f);
            colors[1] = new Color(242f / 255f, 210f / 255f, 73f / 255f);
            colors[2] = new Color(126f / 255f, 214f / 255f, 35f / 255f);
            colors[3] = new Color(214f / 255f, 26f / 255f, 44f / 255f);

            bubble.worldCamera = Camera.main;
            bubble.gameObject.SetActive(false);
            ren = GetComponent<Renderer>();
            im = bubble.GetComponentInChildren<Image>();

            im.sprite = Resources.Load("bulle" + playerDisplay.spriteId, typeof(Sprite)) as Sprite;
            Debug.Log(colors[playerDisplay.spriteId]);
            distance.color = colors[playerDisplay.spriteId];
        }

        // Update is called once per frame
        void Update()
        {
            bubble.gameObject.SetActive(!IsVisible());
            distance.text = CalcDist() + "m";
            Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
            RectTransform rect = distance.rectTransform;
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, camPos.y);
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