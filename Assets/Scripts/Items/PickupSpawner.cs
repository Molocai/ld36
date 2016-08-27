using UnityEngine;
using System.Collections.Generic;

namespace LD36
{
    public class PickupSpawner : MonoBehaviour
    {
        public int qtyToSpawn;
        public GameObject[] pickups;
        public float spawnRadius;

        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < qtyToSpawn; i++)
            {
                GameObject spawn = pickups[Random.Range(0, pickups.Length)];
                Vector2 position = Random.insideUnitCircle * spawnRadius;
                Instantiate(spawn, transform.position + new Vector3(position.x, position.y), Quaternion.identity);
            }
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }
}