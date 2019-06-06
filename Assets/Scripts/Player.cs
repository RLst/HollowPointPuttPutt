using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{
    //Player controller
    public class Player : MonoBehaviour
    {
        IInput input;
        Gun gun;

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
    }
}
