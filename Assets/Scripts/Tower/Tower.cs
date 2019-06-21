using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{
    [RequireComponent(typeof(BoxCollider))]
    public class Tower : MonoBehaviour
    {
        [Header("Standpoint")]
        [SerializeField] Transform m_standPoint;
        public Transform standPoint => m_standPoint;  //Read only

        [Header("Hideables")]
        public List<TowerHideable> hideables;

        [Header("Highlighting")]
        [SerializeField] Material normalMaterial;
        [SerializeField] Material highlightedMaterial;
        public bool isHighlighted = false;

        Collider m_col;
        public new Collider collider => m_col;

        private void Awake()
        {
            m_col = GetComponent<Collider>();
        }

        void Update()
        {
            if (isHighlighted)
            {
                SetMaterial(highlightedMaterial);
            }
            else
            {
                SetMaterial(normalMaterial);
            }
        }

        public void SetMaterial(Material mat)
        {
            foreach (Transform child in transform)
            {
                Renderer childRenderer = child.gameObject.GetComponent<Renderer>();
                if (childRenderer != null)
                    childRenderer.material = mat;
            }
        }

        public void ShowAllOfTower()
        {
            foreach (var h in hideables)
            {
                h.SetHidden(true);
            }
        }
    }
}



// void UpdateOld()
// {

//     Color towerColour;

//     if (shouldBeLit)
//         towerColour = Color.green;
//     else
//         towerColour = Color.white;

//     if (towerColour != curColour)
//     {
//         ChangeTowerColor(towerColour);
//         curColour = towerColour;
//     }
//     shouldBeLit = false;
// }
// private void ChangeTowerColor(Color colour)
// {
//     foreach (Transform child in transform)
//     {
//         Renderer childRenderer = child.gameObject.GetComponent<Renderer>();
//         if (childRenderer != null)
//             childRenderer.material.SetColor("_Color", colour);
//     }

// }