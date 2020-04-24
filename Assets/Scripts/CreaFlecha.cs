using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaFlecha : MonoBehaviour
{
    public float tiempoDeVida = 2f;
    public GameObject enemyPrefab;
    Vector3 MiPos;

    // Start is called before the first frame update
    void Start()
    {
        MiPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDeVida -= Time.deltaTime;
        if(tiempoDeVida <= 0)
        {
            Destroy(this.gameObject);
        }
       
    }
}
