using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HollowPoint
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] Transform muzzle;
        [SerializeField] float range = 1000f;
        
        [SerializeField] Image ChargePanel;

        private float powerScalar;
        private int scaleDir = 1; // 1 or -1
        [Tooltip("How Much Power the Shot Has With a Scalar of 1")]
        [Range(1, 100)]
        public float power = 10f;
        [Tooltip("The Minimum Power Scale to be used in a Shot")]
        [Range(0, 10)]
        public float minPowerScalar = 0.5f;
        [Tooltip("The Minimum Power to be used in a Shot")]
        [Range(1, 50)]
        public float maxPowerScalar = 10.0f; // how high power scale should go
        
        public bool powerup = false;

        public float force => power * powerScalar;

        public Transform frozenPosition;

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

        //======================================
        void OnGUI()
        {
            GUILayout.Label("Gun");
            GUILayout.Space(5);
            GUILayout.Label("Primary Hand Trigger: " + Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger"));
        }

        void Start()
        {
            powerScalar = minPowerScalar;
        }
        void Update()
        {
            if(powerup)
            {
                powerScalar += (maxPowerScalar * Time.deltaTime ) * scaleDir;
                ChargePanel.fillAmount = powerScalar / maxPowerScalar;
                if(powerScalar > maxPowerScalar || powerScalar < minPowerScalar)
                {
                    scaleDir = -scaleDir;
                    powerScalar = Mathf.Clamp(powerScalar, minPowerScalar, maxPowerScalar);
                }
                
            }
            else
            {
                scaleDir = 1;
                powerScalar = 1;
                ChargePanel.fillAmount = 0;
                
            }

        }

        //--------- TEMP --------------
        public void SetGunForce(float _force)
        {
            this.power = _force;
        }

       
    }
}