using UnityEngine;
using System.Collections;
using System;

namespace LD36
{
    /// <summary>
    /// Defines a throwable item
    /// </summary>
    public class ThrowableItem : ItemBase
    {
        /// <summary>
        /// Offset for throwing the item
        /// </summary>
        public Vector2 spawnOffset;
        // Used to convert from Vector2 to Vector3
        private Vector3 _spawnOffset
        {
            get
            {
                return new Vector3(spawnOffset.x, spawnOffset.y);
            }
        }

        public override void Use(PlayerBase user)
        {
            // Instantiate the gameobject prefab
            Instantiate(gameObject, user.gameObject.transform.position + _spawnOffset, Quaternion.identity);
        }
    }
}