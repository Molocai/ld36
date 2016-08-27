using UnityEngine;
using System.Collections;
using System;

namespace LD36
{
    public class EquippableItem : MonoBehaviour
    {
        public ITEM_SLOT slot;

        public void Use(PlayerBase user)
        {
            // Spawn the item
            GameObject instance = Instantiate(gameObject, user.playerDisplay.engineBone.transform.position, Quaternion.identity) as GameObject;
            // Parent it to the engine bone
            instance.transform.SetParent(user.playerDisplay.engineBone);
        }
    }
}