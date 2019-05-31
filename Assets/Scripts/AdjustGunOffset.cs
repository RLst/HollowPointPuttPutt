using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustGunOffset : MonoBehaviour
{
    [SerializeField] Toggle useLocalPosition;
    [SerializeField] Text textX;
    [SerializeField] Text textY;
    [SerializeField] Text textZ;

    [SerializeField] Slider sliderX;
    [SerializeField] Slider sliderY;
    [SerializeField] Slider sliderZ;

    [SerializeField] GameObject gun;

    
    Vector3 offset;

    void Update()
    {
        SetOffset();
        UpdateText();
    }

    private void SetOffset()
    {
        //Constantly set the gun's offset
        offset.x = sliderX.value;
        offset.y = sliderY.value;
        offset.z = sliderZ.value;

        if (useLocalPosition.isOn)
            gun.transform.localPosition = offset;
        else
            gun.transform.position = offset;
    }

    private void UpdateText()
    {
        //Update the GUI
        textX.text = offset.x.ToString();
        textY.text = offset.y.ToString();
        textZ.text = offset.z.ToString();
    }

    public void Reset()
    {
        offset = new Vector3();
    }

}
