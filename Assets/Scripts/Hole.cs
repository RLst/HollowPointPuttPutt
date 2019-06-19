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
        [SerializeField] HoleSetStats nextSet;
        [SerializeField] HoleManager holeManager;

        void Start()
        {
            if (!holeManager)
                holeManager = GameObject.Find("SceneManager").GetComponent<HoleManager>();
        }

        void OnTriggerEnter(Collider col)
        {
            OnSink.Invoke();
            Vector3 nextPos = holeManager.ChangeHole(nextSet);
            if (nextPos != Vector3.zero)
            {
                col.gameObject.transform.position = nextPos;
                col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
                Destroy(col.gameObject);
        }
    }
}
