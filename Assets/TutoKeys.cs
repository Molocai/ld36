using UnityEngine;
using System.Collections;

namespace LD36
{
    public class TutoKeys : MonoBehaviour
    {
        public SpriteRenderer[] keys;
        public Animator[] animators;

        public void Init(int nbPlayers)
        {
            for(int i = 0; i < nbPlayers; i++)
            {
                keys[i].enabled = true;
            }
        }

        public void Stop()
        {
            foreach(Animator a in animators)
            {
                a.SetBool("Stop", true);
            }
        }
    }
}