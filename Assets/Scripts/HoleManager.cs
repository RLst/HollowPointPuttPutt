using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HollowPoint
{
    public class HoleManager : MonoBehaviour
    {
        [SerializeField] HoleSetStats curSet;
        [SerializeField] TeleportController playerTeleporter;
        [SerializeField] GameObject musicPlayer;
        [SerializeField] Text shotPar;

        private int overallScore = 0;
        private int shotsThisHole = 0;

        // Start is called before the first frame update
        void Start()
        {
            if(!musicPlayer)
            {
                GameObject temp = GameObject.Find("Music Player");
                if (temp != null) musicPlayer = temp;
            }
            shotPar.text = "Shots: 0 | Par: " + curSet.Par;
        }

        // Update is called once per frame
        void Update()
        {
        }

        public Vector3 ChangeHole(HoleSetStats nextSet)
        {
            overallScore = shotsThisHole - curSet.Par;
            shotsThisHole = 0;
            if (nextSet != null)
            {
                curSet.toggleColliders(false);
                curSet = nextSet;
                curSet.toggleColliders(true);
                
                playerTeleporter.InitiateTeleport(curSet.getPlayerStartPoint());
                shotPar.text = shotPar.text = "Shots: 0 | Par: " + curSet.Par;
                return curSet.transform.position;
            }
            else
            {
                // run end of game function
                GetComponent<SceneController>().LoadNextScene();
                return Vector3.zero;
            }
        }

        public void addShot(int shots = 1)
        {
            shotsThisHole += shots;
            shotPar.text = "Shots: " + shotsThisHole + " | Par: " + curSet.Par;
        }
    }

}