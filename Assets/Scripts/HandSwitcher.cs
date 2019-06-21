using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{
    public class HandSwitcher : MonoBehaviour
    {
        [SerializeField] bool rightHanded = true;
        Gun gun;

        // OVRCameraRig ovrcamrig;
        Vector3 ROffset;
        IInput input;

        void Awake()
        {
            // ovrcamrig = GetComponentInChildren<OVRCameraRig>();
            gun = GetComponentInChildren<Gun>();
            input = GetComponent<IInput>();
        }

        void Start()
        {
            //Get starting offset (must be right handed)
            ROffset = gun.transform.localPosition;
            Debug.Log("Right hand gun offset x: " + ROffset.x);

            //NOTE! Oculus go always uses the right hand controller!
            //Make sure it's childed to the right hand initially
            // gun.transform.SetParent(ovrcamrig.rightHandAnchor);
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

            Vector3 newLocalPos;
            //Set new offset and parent to the correct anchor on the camera rig
            if (rightHanded)
            {
                newLocalPos = new Vector3(ROffset.x, ROffset.y, ROffset.z);
                gun.transform.localPosition = newLocalPos;
                // gun.transform.localPosition.Set(1, ROffset.y, ROffset.z);
            }
            else
            {
                //X position inverted
                newLocalPos = new Vector3(-ROffset.x, ROffset.y, ROffset.z);
                gun.transform.localPosition = newLocalPos;
                // gun.transform.localPosition.Set(-1, ROffset.y, ROffset.z);
            }
        }

        void PrintPositions()
        {
            Debug.Log("LocalPosition x: " + gun.transform.localPosition.x);
            Debug.Log("Position x: " + gun.transform.position.x);
        }
    }
}
