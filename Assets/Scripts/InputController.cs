﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }

    void Update()
    {
        OVRInput.Update();
    }
}
