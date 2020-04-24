using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMenu : MonoBehaviour
{

    GameObject ActiveMap;
    GameObject Player;
    GameObject Manager;
    SelectedPlayer player1;
    string PlayerName;

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }


    public void DieButton()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerName = Player.name;
        if (PlayerName.Equals("Personaje_Facil"))
        {
            SelectedPlayer.selected = "Easy";
            //print(" Es facil");

            // Dependiendo del personaje tiene una vida máxima?
        }
        else if (PlayerName.Equals("Personaje_Medio"))
        {
            SelectedPlayer.selected = "Medium";
            //print(" Es M");
        }
        else
        {
            SelectedPlayer.selected = "Hard";
            //print(" Es Dif");
        }


        ActiveMap = GameObject.FindGameObjectWithTag("Mapa");
        if (ActiveMap.name.Equals("Mapa_1"))
        {
            SceneManager.LoadScene(2); //Cargamos nuestro juego, no avanzamos de escena.
            SelectedPlayer.SceneMap = 2;
        }
        else if (ActiveMap.name.Equals("Mapa_2"))
        {
            SceneManager.LoadScene(3); //Cargamos nuestro juego, no avanzamos de escena.
            SelectedPlayer.SceneMap = 3;
        }
        else if (ActiveMap.name.Equals("Mapa_3"))
        {
            SceneManager.LoadScene(4); //Cargamos nuestro juego, no avanzamos de escena.
            SelectedPlayer.SceneMap = 4;
        }
        SoundManagerScript.PlaySound("die");
    }


}
