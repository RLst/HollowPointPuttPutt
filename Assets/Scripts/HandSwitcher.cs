using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{
    public class HandSwitcher : MonoBehaviour
    {
        [SerializeField] bool rightHanded = true;
        Gun gun;

        OVRCameraRig ovrcamrig;
        Vector3 RHgunOffset;
        IInput input;

        void Awake()
        {
            ovrcamrig = GetComponentInChildren<OVRCameraRig>();
            gun = GetComponentInChildren<Gun>();
            input = GetComponent<IInput>();
        }

        void Start()
        {
            //Get starting offset (must be right handed)
            RHgunOffset = gun.transform.localPosition;
            //Make sure it's childed to the right hand initially
            gun.transform.SetParent(ovrcamrig.rightHandAnchor);
        }

        void Update()
        {
            HandleHandSwitching();
        }

        private void HandleHandSwitching()
        {
            //DEBUG
            //Right hand
            if (input.axis.x > 0 && input.touched || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!rightHanded)
                {
                    // rightHanded = true;
                    ToggleHand();
                }
            }
            //Left hand
            else if (input.axis.x < 0 && input.touched || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (rightHanded)
                {
                    // rightHanded = false;
                    ToggleHand();
                }
            }
        }

        public void ToggleHand()
        {
            //Toggle hand
            rightHanded = !rightHanded;

            //Set new offset and parent to the correct anchor on the camera rig
            if (rightHanded)
            {
                gun.transform.SetParent(ovrcamrig.rightHandAnchor);
                gun.transform.localPosition.Set(RHgunOffset.x, RHgunOffset.y, RHgunOffset.z);
            }
            else
            {
                gun.transform.SetParent(ovrcamrig.leftHandAnchor);
                //X position inverted
                gun.transform.localPosition.Set(-RHgunOffset.x, RHgunOffset.y, RHgunOffset.z);
            }
            PrintLocalPosition();
        }

        void PrintLocalPosition()
        {
            Debug.Log("LocalPosition: " + gun.transform.localPosition);
        }
    }
}
