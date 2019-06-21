using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{
    public class TowerHideable : MonoBehaviour
    {
        MeshRenderer rend;
        Collider col;

        void Start()
        {
            rend = GetComponent<MeshRenderer>();
            col = GetComponent<Collider>();
        }

        public void SetHidden(bool active)
        {
            rend.enabled = active;
            col.enabled = active;
        }
    }
}
