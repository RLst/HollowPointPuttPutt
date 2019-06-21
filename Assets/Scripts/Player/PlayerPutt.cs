using System;
using UnityEngine;
using UnityEngine.Events;
namespace HollowPoint
{
    [RequireComponent(typeof(IInput))]
    public class PlayerPutt : MonoBehaviour
    {
        [SerializeField] UnityEvent OnPutt;
        [SerializeField] LayerMask ballLayer;
        [SerializeField] GameObject ball;

        IInput input;
        Gun gun;

        Transform gunPrevParent;

        void Awake()
        {
            input = GetComponent<OGoInput>();
            gun = GetComponentInChildren<Gun>();
            gunPrevParent = gun.transform.parent;
        }

        void Update()
        {
            HandlePutting();
            HandleBulletSwitching();
        }

        private void HandleBulletSwitching()
        {
            //Next bullet
            if (input.axis.x > 0 && input.clicked)
            {
                gun.NextBullet();
            }
            //Prev bullet
            else if (input.axis.x < 0 && input.clicked)
            {
                gun.PrevBullet();
            }
        }

        private void HandlePutting()
        {
            if (input.fired && ball.GetComponent<Rigidbody>().velocity.magnitude < 0.25f)
            {
                gun.powerup = true;
                gunPrevParent = gun.transform.parent;
                if (!gun.transform.parent.Equals(transform))
                    gun.transform.SetParent(transform); //this is going to ruin everything
            }
            if (input.fireReleased && gun.powerup)
            {
                Putt();
                gun.powerup = false;
                gun.transform.SetParent(gunPrevParent);
                gun.transform.SetPositionAndRotation(gun.transform.parent.position, gun.transform.parent.rotation);
            }
        }


        //Do the shooting
        public void Putt()
        {
            OnPutt.Invoke();

            //If a ball is hit then "putt" it
            if (gun.Raycast<Ball>(out Ball ballHit, out RaycastHit hitInfo, ballLayer))
            {
                ballHit.Putt(hitInfo.point, gun.force);
            }
        }
    }
}