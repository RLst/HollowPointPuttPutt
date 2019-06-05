using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Ammo
{
    public float power;
    public float mass;
}

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzle;
    public float force = 10f;


    //TEMP! Make a proper input controller
    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }

    void Update()
    {
        OVRInput.Update();

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);

        var bulletRB = bullet.GetComponent<Rigidbody>();

        bulletRB.AddForce(transform.forward * force);
    }


    //======================================
    void OnGUI()
    {
        GUILayout.Label("Gun");
        GUILayout.Space(5);
        GUILayout.Label("Primary Hand Trigger: " + Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger"));
    }

    //--------- TEMP --------------
    public void SetGunForce(float _force)
    {
        this.force = _force;
    }
}