using UnityEngine;
using System.Collections;

namespace LD36
{
    public class GameManager : MonoBehaviour
    {
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
                }
            }
        }

        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}