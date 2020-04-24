using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.audioSource.volume = SelectedPlayer.volume;

        if (MenuFin.isGameOver)
        {
            this.audioSource.Stop();
        }
    }
}
