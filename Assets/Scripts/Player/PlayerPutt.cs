﻿using UnityEngine;
using UnityEngine.Events;
namespace HollowPoint
{
    [RequireComponent(typeof(IInput))]
    public class PlayerPutt : MonoBehaviour
    {
        [SerializeField] UnityEvent OnPutt;
        [SerializeField] LayerMask ballLayer;
        IInput input;
        Gun gun;
        

        void Awake()
        {
            input = GetComponent<IInput>();
            gun = GetComponentInChildren<Gun>();
        }

        void Update()
        {
            if (input.fired)
            {
                Putt();
            }

            //if (input.fire && !wasFired)
            //{
            //    Putt();
            //    wasFired = true;
            //}
            //else if(!input.fire && wasFired)
            //{
            //    wasFired = false;
            //}
        }

        //Do the shooting
        public void Putt()
        {
            OnPutt.Invoke();

            //If a ball is hit then "putt" it
            if (gun.Raycast<Ball>(out Ball ballHit, out RaycastHit hitInfo, ballLayer))
            {

                ballHit.Putt(hitInfo.point, gun.power);
            }
        }
    }
}