using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] Transform muzzle;
        [SerializeField] float range = 1000f;

        public float power = 10f;   //Temp?

        public Vector3 force => transform.forward * power;


        public bool Raycast<T>(out T hit, int layer = ~0) where T : MonoBehaviour
        {
            if (Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hitObj, range, layer))
            {
                //Something hit, check to make sure that it's of type T
                var hitComp = hitObj.collider.GetComponent<T>();
                if (hitComp != null)
                {
                    //Object hit is of correct type; SUCCESS
                    hit = hitComp;
                    return true;
                }
                //Wrong type; FAIL
            }
            //Either nothing hit or object hit of wrong type; FAIL
            hit = null;
            return false;
        }

        public bool Raycast<T>(out T hit, out RaycastHit hitInfo, int layer = ~0) where T : MonoBehaviour
        {
            if (Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hitObj, range, layer))
            {
                //Something hit, check to make sure that it's of type T
                var hitComp = hitObj.collider.GetComponent<T>();
                if (hitComp != null)
                {
                    //Object hit is of correct type; SUCCESS
                    hit = hitComp;
                    hitInfo = hitObj;
                    return true;
                }
                //Wrong type; FAIL
            }
            
            //Either nothing hit or object hit of wrong type; FAIL
            hit = null;
            hitInfo = new RaycastHit();
            return false;
        }

        // public void Shoot()
        // {
        //     var bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);

        //     var bulletRB = bullet.GetComponent<Rigidbody>();

        //     bulletRB.AddForce(transform.forward * power);
        // }

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
            this.power = _force;
        }
    }
}