using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HollowPoint
{
    public class TowerHideBeams : MonoBehaviour
    {
        [SerializeField] float sphereCastRadius = 0.5f;
        [SerializeField] float distanceToCheck = 2f;

        OVRCameraRig camRig;
        Transform centerEyeAnchor;
        // Tower currentTower;     //Hopefully this is a pointer

        Tower thisTower;

        void Awake()
        {
            thisTower = GetComponent<Tower>();
            camRig = GameObject.FindGameObjectWithTag("Player").GetComponent<OVRCameraRig>();
            // centerEyeAnchor = OVRManager.instance.GetComponent<OVRCameraRig>().centerEyeAnchor;
            // centerEyeAnchor = FindObjectOfType<ovrmang>().centerEyeAnchor;
        }

        void Start()
        {
            centerEyeAnchor = camRig.centerEyeAnchor;

            // currentTower = camRig.GetComponent<TowerTeleport>().currentTower;
            // currentTower = centerEyeAnchor.gameObject.GetComponent<TowerTeleport>().currentTower;
        }

        void Update()
        {
            thisTower.ShowAllOfTower();

            //Check if any of the current tower's hideables are hit
            foreach (var hideable in thisTower.hideables)
            {
                //If the sphere cast from the center eye anchor hits something...
                if (Physics.SphereCast(centerEyeAnchor.position, sphereCastRadius, centerEyeAnchor.forward, out RaycastHit hitInfo, distanceToCheck))
                {
                    //If that something is this hideable then hide it
                    var hideableHit = hitInfo.collider.GetComponent<TowerHideable>();
                    if (hideableHit == hideable)
                    {
                        hideable.renderer.enabled = false;
                    }
                }
            }
        }
    }
}





// if (Physics.Raycast(centerEyeAnchor.position, centerEyeAnchor.forward, out RaycastHit hit, 1000f))
// {
//     var towerHideableHit = hit.collider.GetComponent<TowerHideable>();
//     if (towerHideableHit != null)
//     {
//         //Hide the tower post/panel
//         towerHideableHit.renderer.enabled = false;
//     }
// }
