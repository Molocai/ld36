using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace LD36
{
    public class Menu : MonoBehaviour
    {

        [Tooltip("Ecran titre")]
        public RectTransform menuTitre;
        [Tooltip("Ecran de sélection des personnages")]
        public RectTransform menuPerso;
        [Tooltip("Ecran de fin")]
        public RectTransform menuFin;
        [Tooltip("Ecran générique")]
        public RectTransform menuCredits;

        /// <summary>
        /// Menu affiché à l'écran
        /// </summary>
        private RectTransform currentMenu;

        void Start()
        {
            currentMenu = GameManager.Get.End ? menuFin : menuTitre;
            SetSelection();
        }

        void SetSelection()
        {
            Selectable[] selectables = currentMenu.GetComponentsInChildren<Selectable>();
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(selectables[0].gameObject);
        }

        void ChangeTo(RectTransform newMenu)
        {
            if (currentMenu != null)
            {
                currentMenu.gameObject.SetActive(false);
            }

            if (newMenu != null)
            {
                newMenu.gameObject.SetActive(true);
                currentMenu = newMenu;
            }
        }

        public void ChangeToPlayers(int nbPlayers)
        {
            GameManager.Get.NbPlayers = nbPlayers;
            ChangeTo(menuPerso);
            menuPerso.GetComponent<MenuPersos>().Reload();
        }

        public void GoBack()
        {
            ChangeTo(menuTitre);
        }

        public void LancerJeu()
        {
            SceneManager.LoadScene("Game");
        }

        public void ChangeToCredits()
        {
            ChangeTo(menuCredits);
        }

        public void Quit()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_WEBPLAYER
                Application.OpenURL("http://www.google.fr");
            #else
                Application.Quit();
            #endif
        }
    }
}