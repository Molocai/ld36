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
    }
}