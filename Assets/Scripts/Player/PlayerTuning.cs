using UnityEngine;
using System.Collections.Generic;

namespace LD36
{
    [RequireComponent(typeof(PlayerBase))]
    public class PlayerTuning : PlayerBase
    {
        public GameObject reactorGo;
        public GameObject chienGo;

        public void PickupItem(GameObject go, GOOD_BAD status)
        {
            if (go.GetComponent<ReactorItem>() != null)
            {
                Transform bone = (status == GOOD_BAD.GOOD) ? playerDisplay.goodReactorBone : playerDisplay.badReactorBone;

                if (reactorGo != null)
                {
                    Destroy(reactorGo);
                }

                reactorGo = Instantiate(go, bone.transform.position, bone.transform.rotation) as GameObject;
                reactorGo.transform.SetParent(bone);

                ReactorItem reactor = reactorGo.GetComponent<ReactorItem>();
                reactor.SetPlayerController(playerController);
            }

            if (go.GetComponent<ChienItem>() != null)
            {
                Transform bone = (status == GOOD_BAD.GOOD) ? playerDisplay.goodIenchBone : playerDisplay.badIenchBone;

                if (chienGo != null)
                {
                    Destroy(chienGo);
                }

                chienGo = Instantiate(go, bone.transform.position, bone.transform.rotation) as GameObject;
                chienGo.transform.SetParent(bone);

                ChienItem chien = chienGo.GetComponent<ChienItem>();
                chien.SetPlayerController(playerController);
            }

            if (go.GetComponent<TeleItem>() != null)
            {
                GameObject teleGo = Instantiate(go, transform.position - new Vector3(-2, 0, 0), Quaternion.identity) as GameObject;
                teleGo.GetComponent<TeleItem>().playerToIgnore = GetComponent<PlayerBase>();
            }
        }
    }
}