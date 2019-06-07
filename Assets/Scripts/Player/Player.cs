using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{
    //Player controller
    public class Player : MonoBehaviour
    {
        [SerializeField] float lookSensitivity = 150f;
        [SerializeField] Transform cam;
        IInput input;
        Gun gun;


        void Awake()
        {
            LockCursor();
        }

        void Start()
        {
            input = GetComponent<IInput>();
            gun = GetComponentInChildren<Gun>();
        }

        void Update()
        {
            HandleShooting();
        }

        void HandleShooting()
        {
            if (input.fired)
            {
                gun.Shoot();
            }
        }

        void CameraRotation()
        {
            
            transform.Rotate(transform.right * );
        }



        void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}
