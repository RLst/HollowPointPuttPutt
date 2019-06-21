using UnityEngine;
using UnityEngine.Events;
namespace HollowPoint
{
    public class PlayerTeleport : MonoBehaviour
    {
        [SerializeField] UnityEvent OnTeleport, OnTeleported;

        Gun gun;
        IInput input;
        Tower currentTower;
        Player player;

        ////TeleportController teleporter;
        int holeNumber = 1;

        void Awake()
        {
            gun = GetComponentInChildren<Gun>();
            input = GetComponent<IInput>();
            if (input == null) Debug.Log("no input found");
            player = GetComponent<Player>();
            ////teleporter = GetComponent<TeleportController>();
        }

        void Start()
        {
            GameObject towers = GameObject.Find("Hole " + holeNumber);
            towers = towers.transform.Find("Towers").gameObject;
            if (!towers)
            {
                towers = GameObject.Find("Towers");
            }
            float closest = Mathf.Infinity;
            foreach (Transform child in towers.transform)
            {
                if (Vector3.Distance(child.position, transform.position) < closest)
                {
                    currentTower = child.GetComponent<Tower>();
                    closest = Vector3.Distance(child.position, transform.position);
                }
            }
            Transform newTransform = currentTower.standPoint;
            transform.SetPositionAndRotation(newTransform.position, newTransform.rotation);
            currentTower.GetComponent<Collider>().enabled = false;

            nextTransform = transform;
            screenFade = GetComponentInChildren<OVRScreenFade>();
            fadeTimer = screenFade.fadeTime;

        }

        void Update()
        {
            //If player is aiming at tower and pressing a specified button
            int layermask = 1 << 8;
            layermask = ~layermask;
            if (gun.Raycast<Tower>(out Tower towerHit, layermask) && input.fired)
            {
                OnTeleport.Invoke();

                //Do other teleport stuff here
                InitiateTeleport(towerHit.standPoint);

                //Renable current tower
                currentTower.GetComponent<Collider>().enabled = true;
                currentTower = towerHit;
                currentTower.GetComponent<Collider>().enabled = false;
                gun.powerup = false;
            }

            HandleFading();
        }

        //Ported from "TeleportController.cs"
        private OVRScreenFade screenFade;
        private float fadeTimer;
        public float fadeCountDown { get; private set; } = 0;
        private Transform nextTransform;

        public void InitiateTeleport(Transform towerTransform)
        {
            fadeCountDown = fadeTimer;
            nextTransform = towerTransform;
        }

        void HandleFading()
        {
            if (fadeCountDown > 0)
            {
                if (fadeCountDown == fadeTimer)
                    screenFade.FadeOut();

                fadeCountDown -= Time.deltaTime;

                //If the fade sequence has finished it means the player has finished teleporting
                if(fadeCountDown <= 0) OnTeleported.Invoke();
            }
            else if (transform.position != nextTransform.position)
            {
                //What does this do?
                transform.SetPositionAndRotation(nextTransform.position, nextTransform.rotation);

                //transform.position = nextTransform.position;
                screenFade.FadeIn();
                fadeCountDown = 0;
            }
        }
    }
}

