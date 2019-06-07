using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HollowPoint
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class Hole : MonoBehaviour
    {
        [SerializeField] UnityEvent OnSink;
 
        void OnTriggerEnter(Collider col)
        {
            OnSink.Invoke();
            Destroy(col.gameObject);
        }
    }
}
