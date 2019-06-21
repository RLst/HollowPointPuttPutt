using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HollowPoint
{
    public class TowerHideBeams : MonoBehaviour
    {
        [SerializeField] float sphereCastRadius = 0.5f;

        Transform centerEyeAnchor;
        Tower currentTower;     //Hopefully this is a pointer

        Tower tower;

        void Awake()
        {
            centerEyeAnchor = FindObjectOfType<OVRCameraRig>().centerEyeAnchor;
            currentTower = centerEyeAnchor.gameObject.GetComponent<TowerTeleport>().currentTower;
            tower = GetComponent<Tower>();
        }

        void Update()
        {
            currentTower.ShowAllOfTower();

            //Check if any of the current tower's hideables are hit
            foreach (var hideable in currentTower.hideables)
            {
                //If the sphere cast from the center eye anchor hits something...
                if (Physics.SphereCast(centerEyeAnchor.position, sphereCastRadius, centerEyeAnchor.forward, out RaycastHit hitInfo, 1000f))
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
