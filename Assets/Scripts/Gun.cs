using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HollowPoint
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] Transform muzzle;
        public float force = 10f;


        void Update()
        {
            RaycastHit hit;
            int layermask = 1 << 8;
            layermask = ~layermask;

            if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, Mathf.Infinity, layermask))
            {
                if (hit.collider.CompareTag("Tower"))
                {
                    hit.collider.GetComponent<WatchTowerScript>().shouldBeLit = true;
                }
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
}