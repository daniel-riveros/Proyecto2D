using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject BossPrefab;

    float generatorTimer = 3f;
    int EnemigosEliminados = 0; //contador de número de enemigos eliminados.
    int EnemigosActual; //contador de número de enemigos en el mapa actualmente.
    public int[] EnemigoPorMapa ; //contador para avanzar en el mapa.
    int Ncont = 0;
    int CountSound = 0; //contador para que sonido se reproduzca una sola vez


    int Cont = 0;
    int Cont1 = 0;



    //Para que aparezca la flecha

    public GameObject flecha1;
    public GameObject flecha2;

    int num = SelectedPlayer.numEnemigos; //numero de enemigos que debe de haber en el mapa
    int mapa = 0;

    public GameObject aux;


    public GameObject FBRespawn;
    public Vector3[] Tabla;
    public Transform[] posiciones;

    public void decrementa()
    {
        EnemigoPorMapa[Ncont]--;
        print("El contador es: " + EnemigoPorMapa);
    }
    

    public int getContador()
    {
        return EnemigoPorMapa[Ncont];
    }

    public int getDead()
    {
        return EnemigosEliminados;
    }

    public void IncMap()
    {
        mapa++;
        Ncont++;
        EnemigosEliminados = 0;
        
    }

    // Start is called before the first frame update
    void Start()
    {

        Tabla = new Vector3[7];
        EnemigoPorMapa = new int[3];
        string PlayerName = SelectedPlayer.selected;
        if (PlayerName.Equals("Easy"))
        {
            EnemigoPorMapa[0] = 5;
            EnemigoPorMapa[1] = 7;
            EnemigoPorMapa[2] = 7;
        }
        else if (PlayerName.Equals("Medium"))
        {
            EnemigoPorMapa[0] = 7;
            EnemigoPorMapa[1] = 10;
            EnemigoPorMapa[2] = 10;
        }
        else
        {
            EnemigoPorMapa[0] = 7;
            EnemigoPorMapa[1] = 10;
            EnemigoPorMapa[2] = 10;
        }

        
       
        // posiciones = new Transform[transform.childCount];
        int i = 0;
        foreach (Transform t in transform)
        {
            Tabla[i++] = t.position;
        }


        //Método, retardo inicial, tiempo de repetición
        InvokeRepeating("CreateEnemy", 1f, generatorTimer);


    }

    // Update is called once per frame
    void Update()
    {
        if (this.EnemigoPorMapa[0] == 0)
        {
            flecha1.SetActive(true);
            

            if (aux != null)
            {
                aux.SetActive(true);

                // SONIDO DE PUERTA
                if(Cont == 0)
                {
                    SoundManagerScript.PlaySound("door");
                }
                
                Cont++;
               
            }
            else
            {
                if (Cont == 0)
                {
                    SoundManagerScript.PlaySound("next");
                }

                Cont++;
            }
        }
        if (this.EnemigoPorMapa[1] == 0)
        {
            flecha2.SetActive(true);
            if (Cont1 == 0)
            {
                SoundManagerScript.PlaySound("next");
            }

            Cont1++;

        }
        if (this.EnemigoPorMapa[2] == 0)
        {
            if (CountSound == 0)
            {
                SoundManagerScript.PlaySound("let");
                CountSound++;
            }

            MenuFin.Show(); //mostramos el menu de fin.
        }
    }

    public void incMuerte()
    {
        EnemigosEliminados++;
        EnemigosActual--;
        EnemigoPorMapa[Ncont]--;
    }

    public int getMap()
    {
        return this.mapa;
    }

    void CreateEnemy()
    {

        if (EnemigosActual < num && EnemigoPorMapa[Ncont]-EnemigosActual > 0)
        {
            int num0;
            int num1;
            if(mapa == 0)
            {
                num0 = 0;
                num1 = 1;
            }
            else if(mapa == 1)
            {
                num0 = 2;
                num1 = 3;
            }
            else
            {
                num0 = 4;
                num1 = 5;
            }
            float r = Random.value;
            Vector3 act;
            if (r < 0.5f)
                act = Tabla[num0];
            else
                act = Tabla[num1];

            float r1 = Random.value;

            if (mapa != 2)
            {
                if (r < 0.8f)
                    Instantiate(enemyPrefab, act, Quaternion.identity);
                else
                    Instantiate(BossPrefab, act, Quaternion.identity);
            }
            else
            {
                Instantiate(BossPrefab, act, Quaternion.identity);
            }
           


            // Aumento el numero de enemigos actuales en el mapa
            EnemigosActual++;
        }
    }


    




}
