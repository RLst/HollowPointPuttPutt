using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HollowPoint
{
    public class HoleManager : MonoBehaviour
    {
        [SerializeField] HoleSetStats curSet;
        [SerializeField] TeleportController playerTeleporter;
        [SerializeField] GameObject musicPlayer;

        private int overallScore = 0;


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

        public Vector3 ChangeHole(HoleSetStats nextSet)
        {
            overallScore = curSet.Par;
            if (nextSet != null)
            {
                curSet.toggleColliders(false);
                curSet = nextSet;
                curSet.toggleColliders(true);
                
                playerTeleporter.InitiateTeleport(curSet.getPlayerStartPoint());
                
                return curSet.transform.position;
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