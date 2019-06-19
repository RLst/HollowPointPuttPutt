using UnityEngine;
using UnityEngine.Events;
namespace HollowPoint
{
    [RequireComponent(typeof(IInput))]
    public class PlayerPutt : MonoBehaviour
    {
        [SerializeField] UnityEvent OnPutt;
        [SerializeField] LayerMask ballLayer;
        [SerializeField] HoleManager holeManager;
        IInput input;
        Gun gun;
       

        void Awake()
        {
            input = GetComponent<OGoInput>();
            gun = GetComponentInChildren<Gun>();
        }

        void Update()
        {
            if (input.fired)
            {
                gun.powerup = true;
            }

            if(input.fireReleased && gun.powerup)
            {
                Putt();
                gun.powerup = false;
            }
        }

        //Do the shooting
        public void Putt()
        {
            OnPutt.Invoke();

            //If a ball is hit then "putt" it
            if (gun.Raycast<Ball>(out Ball ballHit, out RaycastHit hitInfo, ballLayer))
            {
                holeManager.addShot();
                ballHit.Putt(hitInfo.point, gun.force);
            }
        }
    }
}