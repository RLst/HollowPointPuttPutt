using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HollowPoint
{
    public class HoleManager : MonoBehaviour
    {
        [SerializeField] GameObject curSet;
        [SerializeField] TeleportController playerTeleporter;
        [SerializeField] GameObject musicPlayer;
        



        // Start is called before the first frame update
        void Start()
        {
            if(!musicPlayer)
            {
                GameObject temp = GameObject.Find("Music Player");
                if (temp != null) musicPlayer = temp;
            }
        }

        // Update is called once per frame
        void Update()
        {
        }

        public Vector3 ChangeHole(GameObject nextSet)
        {
            if (nextSet != null)
            {
                foreach (Transform child in curSet.transform)
                {
                    child.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                curSet = nextSet;
                foreach (Transform child in curSet.transform)
                {
                    child.gameObject.GetComponent<BoxCollider>().enabled = true;
                }
                playerTeleporter.InitiateTeleport(curSet.transform.Find("watchTower (1)").GetComponent<Tower>().standPoint); // temporary teleport code
                musicPlayer.transform.position = curSet.transform.parent.position;
                return curSet.transform.parent.position;
            }
            else
            {
                // run end of game function
                GetComponent<SceneController>().LoadNextScene();
                return Vector3.zero;
            }
        }
    }
}