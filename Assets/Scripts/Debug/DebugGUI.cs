using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HollowPoint.DB
{
    public class DebugGUI : MonoBehaviour
    {
        [SerializeField] Toggle useLocalPosition;
        [SerializeField] Text textX;
        [SerializeField] Text textY;
        [SerializeField] Text textZ;

        [SerializeField] Slider sliderX;
        [SerializeField] Slider sliderY;
        [SerializeField] Slider sliderZ;


        [SerializeField] Text textGunForce;
        [SerializeField] Slider sliderGunForce;

        [SerializeField] GameObject gunObject;


        Vector3 offset;
        private Gun gun;

        void Start()
        {
            gun = gunObject.GetComponent<Gun>();
        }

        void Update()
        {
            SetOffset();
            SetGunForce();
            UpdateText();
        }

        private void SetGunForce()
        {
            gun.power = sliderGunForce.value;
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
            //Offset
            textX.text = "Offset X: " + offset.x.ToString();
            textY.text = "Offset Y: " + offset.y.ToString();
            textZ.text = "Offset Z: " + offset.z.ToString();

            //Gun force
            textGunForce.text = "Gun Force: " + gun.power.ToString();
        }

        public void Reset()
        {
            offset = new Vector3();
        }
    }
}