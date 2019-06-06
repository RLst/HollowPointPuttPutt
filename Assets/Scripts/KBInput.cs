using System;
using UnityEngine;
namespace HollowPoint
{
    public class KBInput : MonoBehaviour, IInput
    {
        //Direction
        [SerializeField] string hAxis = "Horizontal";
        [SerializeField] string vAxis= "Vertical";
        Vector2 mouseMovement;
        Quaternion m_rotation;
        public Quaternion rotation => m_rotation;

        //Return mouse movement
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

        public bool wasBack => Input.GetKeyDown(backKey);


        void Start()
        {
            m_rotation = transform.rotation;    //Init m_rotation
        }

        void Update()
        {
            UpdateRotation();
            UpdateMouseMovement();
            UpdateAxes();
        }

        private void UpdateAxes()
        {
            m_axis.x += Input.GetAxis(hAxis);
            m_axis.y += Input.GetAxis(vAxis);
        }

        private void UpdateMouseMovement()
        {
            Debug.Log("MouseMovement: " + mouseMovement);
            // Debug.Log("LastMousePos: "+ lastMousePos);
            mouseMovement = Input.mousePosition - lastMousePos;
            lastMousePos = Input.mousePosition;
        }

        private void UpdateRotation()
        {
            var view = transform.forward;   //Dont' now about this
            view.x += mouseMovement.x;
            view.y += mouseMovement.y;
            m_rotation.SetLookRotation(view);
        }
    }
}
