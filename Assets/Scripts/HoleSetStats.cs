using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class holds the stats of the hole as well as references
/// to important objects in the hole.
/// </summary>
namespace HollowPoint
{
    public class HoleSetStats : MonoBehaviour
    {
        [SerializeField]
        public GameObject towers;

        [SerializeField]
        public Hole hole;

        [SerializeField]
        [Range(2, 12)]
        private int par = 2;

        public int Par { get { return par; } }

        public void toggleColliders(bool collidersOn)
        {
            foreach (Transform child in towers.transform)
            {
                child.GetComponent<BoxCollider>().enabled = collidersOn;
            }
            hole.GetComponent<CapsuleCollider>().enabled = collidersOn;
        }

        public Transform getPlayerStartPoint()
        {
            return towers.transform.GetChild(0).GetComponent<Tower>().standPoint;
        }

    }
}
