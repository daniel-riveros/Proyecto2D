using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text T;


public void PlayGame()
    {
        SelectedPlayer.numEnemigos = System.Int32.Parse(T.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //cambio de escena para poder jugar
    }

public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit(); //salimos del juego

    }
public void RetryGame()
    {
        SceneManager.LoadScene(SelectedPlayer.SceneMap); //Cargamos nuestro juego, no avanzamos de escena.
    }

public void ExitMainMenu()
    {
        MenuFin.isGameOver = false;
        SceneManager.LoadScene(0); //Cargamos nuestro menu principal.
        
    }

public void EliminaRecords()
    {
        PlayerPrefs.DeleteAll();
    }
}
