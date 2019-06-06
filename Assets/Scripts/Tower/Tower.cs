using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{

    public class Tower : MonoBehaviour
    {
        [SerializeField] Transform m_standPoint;
        public Transform standPoint => standPoint;  //Read only

        private Color curColour = Color.white;
        public bool shouldBeLit = false;

        void Update()
        {
            Color towerColour;

            if (shouldBeLit)
                towerColour = Color.green;
            else
                towerColour = Color.white;

            if (towerColour != curColour)
            {
                changeTowerColour(towerColour);
                curColour = towerColour;
            }
            shouldBeLit = false;
        }

        private void changeTowerColour(Color colour)
        {
            foreach (Transform child in transform)
            {
                Renderer childRenderer = child.gameObject.GetComponent<Renderer>();
                if (childRenderer != null)
                    childRenderer.material.SetColor("_Color", colour);
            }

        }

    }

}