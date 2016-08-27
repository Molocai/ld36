using UnityEngine;
using System.Collections;

namespace LD36
{
    public abstract class ItemBase : MonoBehaviour
    {
        public abstract void Use(PlayerBase user);
    }
}