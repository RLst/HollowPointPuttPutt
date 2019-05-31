using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOffsetter : MonoBehaviour
{
    Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    public void SetX(float x)
    {
        pos.x = x;
    }
    public void SetY(float y)
    {
        pos.y = y;
    }
    public void SetZ(float z)
    {
        pos.z = z;
    }


}
