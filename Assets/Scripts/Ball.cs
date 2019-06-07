using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HollowPoint
{
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
        public void Putt(Vector3 hitPoint, Vector3 gunForce)
        {
            OnHit.Invoke();
            
            rb.AddForceAtPosition(gunForce, hitPoint, forceMode);
        }
    }
}
