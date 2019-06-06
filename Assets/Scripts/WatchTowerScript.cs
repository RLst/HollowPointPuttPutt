using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTowerScript : MonoBehaviour
{
    private Color curColour = Color.white;

    public bool shouldBeLit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            if(childRenderer != null)
                childRenderer.material.SetColor("_Color", colour);
        }
        
    }
    
}
