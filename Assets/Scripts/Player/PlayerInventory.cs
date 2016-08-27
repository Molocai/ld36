using UnityEngine;
using System.Collections.Generic;

namespace LD36
{
    public enum ITEM_SLOT
    {
        REACTOR,
        DOG
    }

    [RequireComponent(typeof(PlayerBase))]
    public class PlayerTuning : PlayerBase
    {
        public Dictionary<ITEM_SLOT, GameObject> itemsEquipped;

        public void PickupItem(ITEM_SLOT slot, GameObject go)
        {
            if (itemsEquipped.ContainsKey(slot))
                itemsEquipped[slot] = go;
            else
                itemsEquipped.Add(slot, go);
        }
    }
}