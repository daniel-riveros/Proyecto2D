using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class warp : MonoBehaviour
{
    // Objetivo del warp
    public GameObject target;
    GameObject Respawn;

    public GameObject targetMap;
    
    public EnemyGeneratorController EGC;

    public AudioSource AS;

    bool start = false; 
    bool isFadeIn = false;
    float alpha = 0;
    float fadeTime = 1f;

    GameObject area;

    int CountMap = 0;

    private void Awake()
    {
        Respawn = GameObject.FindGameObjectWithTag("Respawn");
        GetComponent<SpriteRenderer>().enabled = false;
        area = GameObject.FindGameObjectWithTag("Area");
        EGC = Respawn.GetComponent<EnemyGeneratorController>();

    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {

        if (EGC.getContador() == 0)
        {

            if (other.CompareTag("Player"))
            {

                FadeIn();

                yield return new WaitForSeconds(fadeTime);
                if (target != null)
                {
                    EGC.IncMap();
                    other.transform.position = target.transform.position;
                    other.GetComponent<Animator>().enabled = true;

                }

                //Eliminamos el desvanecido
                FadeOut();

                StartCoroutine(area.GetComponent<Area>().ShowArea(targetMap.name));

                if(CountMap==0 && EGC.getMap() == 1)
                {
                    SoundManagerScript.PlaySound("Around");
                    if(AS != null)
                    {
                        AS.Stop();

                    }
                    
                    
                }
                else if (CountMap == 0 && EGC.getMap() == 2)
                {
                    SoundManagerScript.PlaySound("buy");

                }

            }



            if (targetMap != null)
            {
                //actualizamos la cámara
                Camera.main.GetComponent<MainCamera>().SetBound(targetMap);

            }

        }
    }

    
    void OnGUI(){
        if(!start){
            return;
        }
    
        //Creamos un color y lo aplicamos a la textura
        GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,alpha);
        Texture2D tex;
        tex = new Texture2D(1,1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();
        
        //Dibujamos dicha textura en la pantalla.
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        //Ahora añadimos o eliminamos opacidad según convenga.
        if (isFadeIn){
            alpha = Mathf.Lerp (alpha, 1.1f, fadeTime * Time.deltaTime);
        }
        else
        {
            alpha = Mathf.Lerp (alpha, -0.1f, fadeTime * Time.deltaTime);
            if (alpha < 0) start = false;
        }
    }

    void FadeIn() {
            start = true;
            isFadeIn = true;
    }
    
    void FadeOut(){
        isFadeIn = false;
    }

}

