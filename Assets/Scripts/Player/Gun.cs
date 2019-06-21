using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HollowPoint
{     public class Gun : MonoBehaviour
    {
        [Header("Bullets")]
        [SerializeField] Transform muzzle;
        [SerializeField] List<Bullet> bullets = new List<Bullet>();
        [SerializeField] float range = 1000f;
        public Bullet currentBullet;    //public for GUI access (lazy)
        private int bulletIndex;
        UnityEvent OnBulletSwitch;
        
        
        //Charge
        [SerializeField] Image chargePanel;
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
        public bool powerup = false;    //Gun trigger being held down


        public float force => power * powerScalar;


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


        void Awake()
        {
            //Set initial bullet
            if (bullets.Count > 0)
                currentBullet = bullets[0];
        }

        void Start()
        {
            powerScalar = minPowerScalar;
        }

        void Update()
        {
            if(powerup)
            {
                powerScalar += (maxPowerScalar * Time.deltaTime) * scaleDir;
                chargePanel.fillAmount = powerScalar / maxPowerScalar;

                //Switch power scale directions
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
                chargePanel.fillAmount = 0;
            }
        }

        public void NextBullet()
        {
            OnBulletSwitch.Invoke();
            
            bulletIndex++;
            if (bulletIndex > bullets.Count-1) bulletIndex = 0; //Wrap around
            currentBullet = bullets[bulletIndex];
        }

        public void PrevBullet()
        {
            OnBulletSwitch.Invoke();

            bulletIndex--;
            if (bulletIndex < 0) bulletIndex = bullets.Count-1; //Wrap around
            currentBullet = bullets[bulletIndex];
        }

     
        //======================================
        // void OnGUI()
        // {
        //     GUILayout.Label("Gun");
        //     GUILayout.Space(5);
        //     GUILayout.Label("Primary Hand Trigger: " + Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger"));
        // }
    }
}