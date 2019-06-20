using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HollowPoint
{
    [SelectionBase]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] ForceMode forceMode = ForceMode.Impulse;
        [SerializeField] UnityEvent OnHit;

        private Rigidbody rb;
        private Collider col;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            col = GetComponent<Collider>();
        }

        //"Putt" with the sniper rifle
        public void Putt(Vector3 hitPoint, float gunPower)
        {
            OnHit.Invoke();
            var trajectory = (transform.position - hitPoint);

            //Prevent the ball from flying up
            trajectory.y = 0f;
            Vector3.Normalize(trajectory);
            rb.AddForceAtPosition(gunPower * trajectory, hitPoint, forceMode);
        }
    }
}
