using UnityEngine;
using System.Collections.Generic;

namespace LD36
{
    [RequireComponent(typeof(PlayerBase))]
    public class PlayerTuning : PlayerBase
    {
        public GameObject reactorGo;

        public void PickupItem(GameObject go, GOOD_BAD status)
        {
            if (go.GetComponent<ReactorItem>() != null)
            {
                Transform bone = (status == GOOD_BAD.GOOD) ? playerDisplay.goodReactorBone : playerDisplay.badReactorBone;

                // Instantiate the reactor
                if (reactorGo != null)
                {
                    Destroy(reactorGo);
                }

                reactorGo = Instantiate(go, bone.transform.position, bone.transform.rotation) as GameObject;
                reactorGo.transform.SetParent(bone);

                ReactorItem reactor = reactorGo.GetComponent<ReactorItem>();
                reactor.SetPlayerController(playerController);
            }
        }
    }
}