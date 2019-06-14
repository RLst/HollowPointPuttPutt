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
        Player player;
        TeleportController fadeManager;
        int holeNumber = 1;

        [SerializeField] UnityEvent OnTeleport;

        void Awake()
        {
            gun = GetComponentInChildren<Gun>();
            input = GetComponent<IInput>();
            if (input == null) Debug.Log("no input found");
            player = GetComponent<Player>();
            fadeManager = GetComponent<TeleportController>();
        }

        void Start()
        {
            //find all towers
            var towerArr = (Resources.FindObjectsOfTypeAll(typeof(Tower))) as Tower[];
            List<Tower> towerList = new List<Tower>(towerArr);
            //sort by distance
            //towerList.Sort(x, y) => Vector3.Distance((Tower)x.transform.pos)



            //Set the current tower
            //currentTower = FindObjectOfType<Tower>();
            //currentTower.collider.enabled = false;
            GameObject towers = GameObject.Find("Hole " + holeNumber);
            towers = towers.transform.Find("Towers").gameObject;
            if (!towers)
            {
                towers = GameObject.Find("Towers");
            }
            float closest = Mathf.Infinity;
            foreach (Transform child in towers.transform)
            {
                if (Vector3.Distance(child.position, transform.position) < closest)
                {
                    currentTower = child.GetComponent<Tower>();
                    closest = Vector3.Distance(child.position, transform.position);
                }
            }
            Transform newTransform = currentTower.standPoint;
            transform.SetPositionAndRotation(newTransform.position, newTransform.rotation);
            currentTower.GetComponent<Collider>().enabled = false;
        }

        void Update()
        {
            //If player is aiming at tower and pressing a specified button
            int layermask = 1 << 8;
            layermask = ~layermask;
            if (gun.Raycast<Tower>(out Tower towerHit, layermask) && input.fired)
            {
                OnTeleport.Invoke();
                //Do other teleport stuff here
                //fadeManager.InitiateTeleport(towerHit.transform.Find("StandPoint"));
                fadeManager.InitiateTeleport(towerHit.standPoint); // causes game to freeze

                //Renable current tower
                currentTower.GetComponent<Collider>().enabled = true;
                currentTower = towerHit;
                currentTower.GetComponent<Collider>().enabled = false;
                gun.powerup = false;
            }
        }

    }
}

