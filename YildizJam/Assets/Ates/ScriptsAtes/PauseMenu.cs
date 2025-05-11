using UnityEngine;

namespace Ates.ScriptsAtes
{
    public class PauseMenu : MonoBehaviour
    {
        public static PauseMenu instance;
        public GameObject pauseMenu;
        public static bool isPaused;

        void Awake()
        {
            instance = this;
        }
        void Start()
        {
            pauseMenu.SetActive(false);
        }
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        public void PauseGame()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.000000001f;
            isPaused = true;
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}


