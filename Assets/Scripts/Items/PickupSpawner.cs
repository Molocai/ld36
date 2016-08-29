using UnityEngine;
using System.Collections.Generic;

namespace LD36
{
    public class PickupSpawner : MonoBehaviour
    {
        [System.Serializable]
        public struct SpawnGroup
        {
            public int weight;
            public GameObject item;
            [HideInInspector()]
            public int cumulativeWeight;
        }

        public SpawnGroup[] itemsToSpawn;
        public int qtyToSpawn;
        public float spawnRadius;

        // Use this for initialization
        void Start()
        {
            int total = 0;

            for (int i = 0; i < itemsToSpawn.Length; i++)
            {
                total += itemsToSpawn[i].weight;
                itemsToSpawn[i].cumulativeWeight = total;
            }

            for (int i = 0; i < qtyToSpawn; i++)
            {
                int rand = Random.Range(0, total + 1);
                foreach (SpawnGroup s in itemsToSpawn)
                {
                    if (s.cumulativeWeight >= rand)
                    {
                        Vector2 position = Random.insideUnitCircle * spawnRadius;
                        GameObject item = Instantiate(s.item, transform.position + new Vector3(position.x, position.y), Quaternion.identity) as GameObject;
                        item.transform.localScale = new Vector3((Random.Range(0, 2) == 0) ? s.item.transform.localScale.x * -1 : s.item.transform.localScale.x, s.item.transform.localScale.y);
                        break;
                    }
                }
            }
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }
}