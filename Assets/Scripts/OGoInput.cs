using UnityEngine;
namespace HollowPoint
{
    public class OGoInput : MonoBehaviour, IInput
    {
        //Direction
        public Quaternion rotation => OVRInput.

        //Touchpad axis
        public Vector2 axis => OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        //Touchpad click
        public bool click => OVRInput.Get(OVRInput.Button.One);
        public bool clicked => OVRInput.GetDown(OVRInput.Button.One);

        //Touchpad touch
        public bool touch => OVRInput.Get(OVRInput.Touch.One);
        public bool touched => OVRInput.GetDown(OVRInput.Touch.One);


        //Trigger
        public bool fire => OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);

        public bool fired => OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);

        public bool back => OVRInput.Get(OVRInput.Button.Two);

        public bool wasBack => OVRInput.GetDown(OVRInput.Button.Two);

        void FixedUpdate()
        {
            OVRInput.FixedUpdate(); //Must be run each fixed frame
        }

        void Update()
        {
            OVRInput.Update();  //Must be run each frame
        }
    }
}
