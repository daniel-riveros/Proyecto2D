using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Siguiente : MonoBehaviour, IPointerDownHandler
{
    // Guardamos los personajes que vamos a mostrar
    public GameObject Objeto_1;
    public GameObject Objeto_2;
    public GameObject Objeto_3;

    float time = 0;
    float wait1;
    float wait2;


    private void Start()
    {
        this.wait1 = 20;
        this.wait2 = this.wait1 * 2;
    }

    //Si hace click en el boton de la derecha
    private void Update()
    {
        time++;
        Vector3 posAct = this.transform.position;
        if (time == wait1)
        {
            posAct.x += 5;
        }
        else if (time == wait2)
        {
            posAct.x -= 5;
            time = 0;
        }

        //Que se desplace un poco con el tiempo para darle efecto de movimiento
        this.transform.position = posAct;
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " Was Clicked.");
    
        // 0 Izq / 1 Cent / 2 Der
        if (Input.GetMouseButtonDown(0))
        {
            SoundManagerScript.PlaySound("alante");

            // Si esta el personaje facil activo
            if (Objeto_1.activeSelf)
            {
                Objeto_1.SetActive(false);
                Objeto_2.SetActive(true);
            }
            // Si esta el normal activado
            else if (Objeto_2.activeSelf)
            {
                Objeto_2.SetActive(false);
                Objeto_3.SetActive(true);
            }
            // Si esta el dificil activado
            else if (Objeto_3.activeSelf)
            {
                Objeto_3.SetActive(false);
                Objeto_1.SetActive(true);
            }
        }
    }
}
