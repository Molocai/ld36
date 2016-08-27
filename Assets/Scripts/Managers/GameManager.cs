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

        public void SetNbPlayers(int nb)
        {
            if (nb > 0)
            {
                nbPlayers = nb;
            }
        }

        public bool Are2Players()
        {
            return nbPlayers == 2;
        }
    }
}