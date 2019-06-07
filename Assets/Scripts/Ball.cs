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
        [SerializeField] float mass = 100f; //Ball needs to be heavy to resist the gun force
        // [SerializeField] float radius;
        [SerializeField] UnityEvent OnHit;

        private Rigidbody rb;
        private Collider col;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            col = GetComponent<Collider>();
        }
        void Start()
        {
            rb.mass = mass;
        }

        //"Putt" with the sniper rifle
        public void Putt(Vector3 hitPoint, float gunPower)
        {
            OnHit.Invoke();
            var trajectory = (transform.position - hitPoint).normalized;

            //Prevent the ball from flying up
            trajectory.y = 0f;

            rb.AddForceAtPosition(gunPower * trajectory, hitPoint, forceMode);
        }
    }
}
