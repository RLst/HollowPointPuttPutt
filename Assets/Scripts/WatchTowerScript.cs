using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTowerScript : MonoBehaviour
{
    BoxCollider boxCollider;
    
    public bool shouldBeLit = false;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Color towerColour;

        if (shouldBeLit)
            towerColour = Color.green;
        else
            towerColour = Color.white;


        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Renderer>().material.SetColor("_Color", towerColour);
        }
        shouldBeLit = false;
    }

    public void changeTowerColour()
    {

    }
    
}
