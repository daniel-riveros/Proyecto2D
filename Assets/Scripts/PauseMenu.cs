using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public AudioSource AS;
    public AudioSource AS1;
    // Update is called once per frame
    void Update()
    {
        if (!MenuFin.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    if (AS != null)
                    {
                        AS.UnPause();
                    }
                    if (AS1 != null)
                    {
                        AS1.UnPause();
                    }
                    Resume();
                }
                else
                {
                    if (AS != null)
                    {
                        AS.Pause();
                    }
                    if (AS1 != null)
                    {
                        AS1.Pause();
                    }

                    Pause();
                }
            }
        }
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RetryGame()
    {
        Resume();
        SceneManager.LoadScene(SelectedPlayer.SceneMap); //Cargamos nuestro juego, no avanzamos de escena.
    }

    public void ExitMainMenu()
    {
        Resume();
        SceneManager.LoadScene(0); //Cargamos nuestro menu principal.
    }

}
