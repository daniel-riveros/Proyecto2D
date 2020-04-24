using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    GameObject Jugador;
    Movimiento MovPlayer;
    public GameObject HeartSound;


    // Start is called before the first frame update
    void Start()
    {
        Jugador = GameObject.FindGameObjectWithTag("Player");
        MovPlayer = Jugador.GetComponent<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {

            // Le doy una vida al jugador
            this.MovPlayer.IncHP();
            Instantiate(HeartSound);
            Destroy(this.gameObject);

        }

        
    }

}
