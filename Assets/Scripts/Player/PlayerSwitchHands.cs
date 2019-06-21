using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{
    public class PlayerSwitchHands : MonoBehaviour
    {
        [SerializeField] bool rightHanded = true;
        [SerializeField] float LOffsetX;

        Gun gun;
        Vector3 ROffset;
        Vector3 LOffset;
        IInput input;

        void Awake()
        {
            gun = GetComponentInChildren<Gun>();
            input = GetComponent<IInput>();
        }

        void Start()
        {
            //Get starting offset (must be right handed)
            ROffset = gun.transform.localPosition;
            LOffset = ROffset;
            LOffset.x = LOffsetX;

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
                    ToggleHand();
                }
            }
            //Left hand
            else if (input.axis.x < 0 && input.touched || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (rightHanded)
                {
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
                gun.transform.localPosition = ROffset;
            }
            else
            {
                //X position inverted
                gun.transform.localPosition = LOffset;
            }
        }

        //void PrintPositions()
        //{
        //    Debug.Log("LocalPosition x: " + gun.transform.localPosition.x);
        //    Debug.Log("Position x: " + gun.transform.position.x);
        //}
    }
}
