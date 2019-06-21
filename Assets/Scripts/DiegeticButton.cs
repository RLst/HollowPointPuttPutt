using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace HollowPoint
{
    public class DiegeticButton : MonoBehaviour
    {
        Collider col;
        OVRCameraRig camRig;
        Gun gun;
        IInput input;

        public UnityEvent OnHit;

        void Start()
        {
            col = GetComponent<Collider>();
            camRig = GameObject.FindGameObjectWithTag("Player").GetComponent<OVRCameraRig>();
            gun = camRig.GetComponentInChildren<Gun>();
            input = GetComponent<IInput>();
        }

        private void Update()
        {
            if (gun.Raycast<DiegeticButton>(out DiegeticButton buttonHit))
            {
                if (input.fired)
                    if (buttonHit == this)
                        OnHit.Invoke();
            }
        }

    }
}
