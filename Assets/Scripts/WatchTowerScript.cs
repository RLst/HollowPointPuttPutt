using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTowerScript : MonoBehaviour
{
    BoxCollider boxCollider;

    bool isLit = false;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setTowerColour(Collider raycastHit)
    {

        if (!isLit && raycastHit.CompareTag("Tower"))
        {
            GameObject tower = raycastHit.gameObject;
            Color towerColour = Color.green;

            foreach (Transform child in raycastHit.transform)
            {
                child.gameObject.GetComponent<Renderer>().material.SetColor("_Color", towerColour);
            }
            isLit = !isLit;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isLit)
        {
            Color towerColour = Color.white;

            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<Renderer>().material.SetColor("_Color", towerColour);
            }
            isLit = !isLit;
        }
    }
}
