using UnityEngine;
using System.Collections;

namespace LD36
{
    [System.Serializable]
    public struct KeyboardKey
    {
        public KeyCode azertyKey;
        public KeyCode qwertyKey;
    }

    [System.Serializable]
    public struct GameInput
    {
        public KeyboardKey UpKey;
        public KeyboardKey DownKey;
        public KeyboardKey UseKey;
        public KeyboardKey MoveKey;
    }

    public class GameManager : MonoBehaviour
    {
        public enum Clavier
        {
            AZERTY,
            QWERTY
        }

        public GameInput[] keybindings;

        [HideInInspector]
        public Clavier clavier = Clavier.AZERTY;

        #region Singleton
        static GameManager _manager;
        public static GameManager Get
        {
            get
            {
                if (_manager == null)
                    _manager = GameObject.FindObjectOfType<GameManager>();
                return _manager;
            }
        }
        #endregion

        /// <summary>
        /// Nombre de joueurs dans la course
        /// </summary>
        private int nbPlayers;
        public int NbPlayers
        {
            get
            {
                return nbPlayers;
            }
            set
            {
                if (value > 1)
                {
                    nbPlayers = value;
                    skins = new int[value];
                }
            }
        }

        /// <summary>
        /// Skins choisis par les joueurs
        /// </summary>
        private int[] skins;
        public int[] Skins
        {
            get
            {
                return skins;
            }
        }

        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void SetSkin(int player, int skin)
        {
            skins[player] = skin;
        }

        public void SetClavier(bool azerty)
        {
            clavier = azerty ? Clavier.AZERTY : Clavier.QWERTY;
        }
    }
}