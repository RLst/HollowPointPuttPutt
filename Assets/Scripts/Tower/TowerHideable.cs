using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{
    public class TowerHideable : MonoBehaviour
    {
        public new MeshRenderer renderer;

        void Start()
        {
            renderer = GetComponent<MeshRenderer>();
        }
    }
}
