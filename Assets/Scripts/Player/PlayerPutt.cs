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
        // [SerializeField] HoleManager holeManager;
        [SerializeField] GameObject ball;

        // TeleportController tpController;

        IInput input;
        Gun gun;

        Transform gunPrevParent;

        void Awake()
        {
            input = GetComponent<OGoInput>();
            gun = GetComponentInChildren<Gun>();
            gunPrevParent = gun.transform.parent;
            // tpController = GetComponent<TeleportController>();
            // Debug.Log(tpController);
        }

        void Update()
        {
            HandlePutting();
            HandleBulletSwitching();
        }

        private void HandleBulletSwitching()
        {
            //Next bullet
            if (input.axis.y > 0 && input.touched)
            {
                gun.NextBullet();
            }
            //Prev bullet
            else if (input.axis.y < 0 && input.touched)
            {
                gun.PrevBullet();
            }
        }

        private void HandlePutting()
        {
            //If the teleportation is done
            // if (tpController.fadeCountDown <= 0)
            // {
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
            // }
            // else if(gun.transform.parent.Equals(transform))
            // {
            //     gun.transform.SetParent(gunPrevParent);
            //     gun.transform.SetPositionAndRotation(gun.transform.parent.position, gun.transform.parent.rotation);
            // }
        }


        //Do the shooting
        public void Putt()
        {
            OnPutt.Invoke();

            //If a ball is hit then "putt" it
            if (gun.Raycast<Ball>(out Ball ballHit, out RaycastHit hitInfo, ballLayer))
            {
                // holeManager.addShot();
                ballHit.Putt(hitInfo.point, gun.force);
            }
        }
    }
}