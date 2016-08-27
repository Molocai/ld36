using UnityEngine;
using System.Collections.Generic;

namespace LD36
{
    public class PickupSpawner : MonoBehaviour
    {
        [System.Serializable]
        public struct Spawner
        {
            public GameObject item;
            public int weight;
        }

        public Spawner[] spawners;

        // Use this for initialization
        void Start()
        {
            int total = 0;
            foreach(Spawner s in spawners)
            {
                total += s.weight;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}