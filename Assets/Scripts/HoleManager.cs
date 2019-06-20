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
        [SerializeField] GameObject ScoreCard;

        [Range(0, 10)]
        public float scoreCardTimer = 3;
        private float scoreCardCountdown = 0;

        List<int> pars = new List<int>();
        List<int> shots = new List<int>();

        private int overallScore = 0;
        private int shotsThisHole = 0;



        // Start is called before the first frame update
        void Start()
        {
            shotPar.text = "Shots: 0 | Par: " + curSet.Par;
            bool listFull = false;
            HoleSetStats listHole = curSet;
            while(!listFull)
            {
                pars.Add(listHole.Par);
                if(!listHole.hole.nextSet)
                {
                    listFull = true;
                }
                else
                {
                    listHole = listHole.hole.nextSet;
                }
            }
            printScoreCard();


        }

        void Update()
        {
            if (scoreCardCountdown > 0)
                scoreCardCountdown -= Time.deltaTime;
            else
                ScoreCard.SetActive(false);
        }

        public Vector3 ChangeHole(HoleSetStats nextSet)
        {
            shots.Add(shotsThisHole - curSet.Par);
            overallScore += shotsThisHole - curSet.Par;
            shotsThisHole = 0;
            if (nextSet != null)
            {
                curSet.toggleColliders(false);
                curSet = nextSet;
                curSet.toggleColliders(true);
                
                playerTeleporter.InitiateTeleport(curSet.getPlayerStartPoint());
                shotPar.text = shotPar.text = "Shots: 0 | Par: " + curSet.Par;
                printScoreCard();
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

        void printScoreCard()
        {
            string scoreCardText = " Par:\t\t";
            foreach (int par in pars)
            {
                scoreCardText += par + " | ";
            }
            scoreCardText += "\n Score:\t";
            foreach(int score in shots)
            {
                if(score > 0)
                    scoreCardText += "+" + score + "|";
                else if(score < 0)
                    scoreCardText += score + "|";
                else
                    scoreCardText += score + "| ";
            }
            ScoreCard.transform.Find("Stats").GetComponent<Text>().text = scoreCardText;
            scoreCardCountdown = scoreCardTimer;
            ScoreCard.SetActive(true);
        }
    }

}