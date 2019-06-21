using UnityEngine;
using UnityEngine.SceneManagement;
namespace HollowPoint
{

    public class SceneController : MonoBehaviour
    {
        IInput input;

        const float timer = 3;
        float countdown;

        public bool backtest = false;

        private void Awake()
        {
            countdown = timer;
            input = GetComponent<IInput>();
        }

        private void Update()
        {
            if (input.back)
            {
                countdown -= Time.deltaTime;
                if(countdown <= 0)
                    ReloadCurrentScene();
            }
            else
                countdown = timer;
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
