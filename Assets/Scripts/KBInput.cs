using System;
using UnityEngine;
namespace HollowPoint
{
    public class KBInput : MonoBehaviour, IInput
    {
        //Direction from mouse movement (OGo look ~= Mouse movement)
        [SerializeField] string hAxis = "Mouse X";
        [SerializeField] string vAxis= "Mouse Y";
        [SerializeField] float mouseSensitivity = 150f;
        float xAxisClamp = 0f;
        Transform rotObj;
        Quaternion m_rotation;
        public Quaternion rotation => m_rotation;

        //Return WASD (OGo touchpad ~= WASD)
        Vector2 m_axis;
        public Vector2 axis => m_axis;

        //Right click
        [SerializeField] KeyCode touchKey = KeyCode.Mouse2;
        public bool touch => Input.GetKey(touchKey);
        public bool touched => Input.GetKeyDown(touchKey);

        [SerializeField] KeyCode clickKey = KeyCode.Mouse1;
        public bool click => Input.GetKey(clickKey);
        public bool clicked => Input.GetKeyDown(clickKey);

        [SerializeField] KeyCode fireKey = KeyCode.Mouse0;
        public bool fire => Input.GetKey(fireKey);

        public bool fired => Input.GetKeyDown(fireKey);

        [SerializeField] KeyCode backKey = KeyCode.Backspace;
        private Vector3 lastMousePos;

        public bool back => Input.GetKey(backKey);

        public bool backed => Input.GetKeyDown(backKey);


        void Start()
        {
            m_rotation = transform.rotation;    //Init m_rotation
        }

        void Update()
        {
            UpdateInternalRotation();
            // UpdateMouseMovement();
            UpdateAxes();
        }

        private void UpdateAxes()
        {
            m_axis.x += Input.GetAxis(hAxis);
            m_axis.y += Input.GetAxis(vAxis);
        }

        // private void UpdateMouseMovement()
        // {
        //     Debug.Log("MouseMovement: " + mouseMovement);
        //     // Debug.Log("LastMousePos: "+ lastMousePos);
        //     mouseMovement = Input.mousePosition - lastMousePos;
        //     lastMousePos = Input.mousePosition;
        // }

        // private void UpdateRotation()
        // {
            

        //     var view = transform.forward;   //Dont' now about this
        //     view.x += mouseMovement.x;
        //     view.y += mouseMovement.y;
        //     m_rotation.SetLookRotation(view);
        // }

        void UpdateInternalRotation()
        {
            float mouseX = Input.GetAxis(hAxis) * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis(vAxis) * mouseSensitivity * Time.deltaTime;

            //Do clamps and limits
            xAxisClamp += mouseY;
            Mathf.Clamp(xAxisClamp, -90f, 90f);
            mouseY = 0f;
            // ClampXAxisRotationToValue()

            //Apply rotation to the internal rotation object
            rotObj.transform.Rotate(Vector3.left * mouseY + Vector3.up * mouseX);

            //Get the quaternion from the rotation object
            m_rotation = rotObj.rotation;

            void ClampXAxisRotationToValue(float value)
            {
                Vector3 eulerRotation = transform.eulerAngles;
                eulerRotation.x = value;
                transform.eulerAngles= eulerRotation;
            }
        }
    }
}
