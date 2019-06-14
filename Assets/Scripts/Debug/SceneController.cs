﻿using UnityEngine;
using UnityEngine.SceneManagement;
namespace HollowPoint
{

    public class SceneController : MonoBehaviour
    {
        IInput input;

        private void Awake()
        {
            input = GetComponent<IInput>();
        }

        private void Update()
        {
            if (input.backed)
                ReloadCurrentScene();
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //Just reload current scene
        }

        public void LoadNextScene()
        {
            //temp: reload the scene instead of loading the game end
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
