using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace HollowPoint
{
    public class TowerTeleport : MonoBehaviour
    {
        Gun gun;
        IInput input;

        UnityEvent OnTeleport;

        void Awake()
        {
            gun = GetComponentInChildren<Gun>();
        }

        void Update()
        {
            //If player is aiming at tower and pressing a specified button
            int layermask = 1 << 8;
            layermask = ~layermask;
            if (gun.Raycast<Tower>(out Tower hit, layermask) && input.fired)
            {
                Teleport();
            }
        }

        void Teleport()
        {
            OnTeleport.Invoke();
            //Do other teleport stuff here
        }
    }
}

// GameObject towerHit = towerCheck();
// if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
// {
//     if (towerHit == null)
//         Shoot();
//     else
//     {
//         GameObject player = GameObject.Find("OVRCameraRig");
//         player.GetComponent<FadeManager>().InitiateTeleport(towerHit.transform.position);
//     }
// }