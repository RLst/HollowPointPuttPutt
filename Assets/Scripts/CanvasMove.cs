using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMove : MonoBehaviour
{

    public GameObject destinationObject;
    public Camera mainCamera;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lTargetDir = transform.position - mainCamera.transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lTargetDir), moveSpeed * Time.deltaTime);

        transform.position = Vector3.Lerp(transform.position, destinationObject.transform.position, moveSpeed * Time.deltaTime);
    }
}
