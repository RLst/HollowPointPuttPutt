﻿using UnityEngine;
namespace HollowPoint
{
    public class OGoInput : MonoBehaviour, IInput
    {
        //Direction
        public Quaternion rotation => OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        //Touchpad axis
        public Vector2 axis => OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        //Touchpad click
        public bool click => OVRInput.Get(OVRInput.Button.One);
        public bool clicked {
            get {
                if (OVRInput.Get(OVRInput.Button.One) && !clickFlag)
                {
                    return true;
                }
                return false; } }
        bool clickFlag = false;

        //Touchpad touch
        public bool touch => OVRInput.Get(OVRInput.Touch.One);
        public bool touched {
            get {
                if (OVRInput.Get(OVRInput.Touch.One) && !touchFlag)
                {
                    return true;
                }
                return false; } }
        bool touchFlag = false;

        //Trigger
        public bool fire => OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
        public bool fired {
            get {
                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && !firedFlag)
                {
                    return true;
                }
                return false; } }
        public bool fireReleased {
            get {
                if (!OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && firedFlag)
                {
                    return true;
                }
                return false; } }
        bool firedFlag = false;

        public bool back => OVRInput.Get(OVRInput.Button.Two);
        public bool backed {
            get {
                if (OVRInput.Get(OVRInput.Button.Two) && !backFlag)
                {
                    return true;
                }
                return false; } }
        bool backFlag = false;
        

        void FixedUpdate()
        {
            OVRInput.FixedUpdate(); //Must be run each fixed frame
        }

        void Update()
        {
            OVRInput.Update();  //Must be run each frame
        }

        private void LateUpdate()
        {
            clickFlag = click;
            touchFlag = touch;
            firedFlag = fire;
            backFlag = back;
        }
    }
}
