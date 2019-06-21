using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMove : MonoBehaviour
{
    public GameObject destinationObject;
    public Camera mainCamera;
    public float moveSpeed;

    void Update()
    {
        this.transform.LookAt(mainCamera.transform);
        this.transform.position = Vector3.MoveTowards(transform.position, destinationObject.transform.position, moveSpeed * Time.deltaTime);
    }
}
