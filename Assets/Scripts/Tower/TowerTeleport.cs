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
        Tower currentTower;

        [SerializeField] UnityEvent OnTeleport;

        void Awake()
        {
            gun = GetComponentInChildren<Gun>();
            input = GetComponent<IInput>();
            if (input == null) Debug.Log("no input found");
        }

        void Update()
        {
            //If player is aiming at tower and pressing a specified button
            int layermask = 1 << 8;
            layermask = ~layermask;
            if (gun.Raycast<Tower>(out Tower hit, layermask) && input.fired)
            {

                OnTeleport.Invoke();
                //Do other teleport stuff here
                GameObject player = GameObject.Find("OVRCameraRig");
                player.GetComponent<FadeManager>().InitiateTeleport(hit.transform.position);
                currentTower.GetComponent<Collider>().enabled = true;
                currentTower = hit;
                currentTower.GetComponent<Collider>().enabled = false;
            }
        }

        void Teleport()
        {

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