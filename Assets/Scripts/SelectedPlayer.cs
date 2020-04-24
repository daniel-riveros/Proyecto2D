using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedPlayer : MonoBehaviour
{
    public static string selected;
    public static int SceneMap;
    public static int numEnemigos;
    public static float volume = 0.5f;

    public Slider Volume;

    public void Update()
    {
        Volume.normalizedValue = volume;
    }

    public void setVolume()
    {
        volume = Volume.normalizedValue;
    }
    
}
