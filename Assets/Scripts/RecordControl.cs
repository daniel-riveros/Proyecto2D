using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordControl : MonoBehaviour
{
    // This class will control all the records in the actual map

    string Name;
    public GameObject input;
    public Button bt;

    public static int puntAct;
    public int pA;
    public bool ww;
    public GameObject Saved;
    public static int pos;
    static int x = 0;

    public void Start()
    {
    }

    public void Update()
    {
        pA = puntAct;
        ww = isRecord(pA);
    }

 
    public static bool isRecord(int punt)
    {
        puntAct = punt;
        int i = 1;
        bool enc = false;
        int pos = -1;
        while (i < 11 && !enc)
        {
            // Si tiene hay record
            if (PlayerPrefs.GetInt("BestS" + i + " M:" + SelectedPlayer.SceneMap) != 0)
            {
                int aux = PlayerPrefs.GetInt("BestS" + i + " M:" + SelectedPlayer.SceneMap);               

                if (punt > aux && punt != 0)
                {
                    enc = true;
                    pos = i;
                }
            }
            //Si no tiene hay un hueco
            else
            {
                if ( punt != 0)
                {
                    enc = true;
                    pos = i;
                }
                    
            }
            i++;
        }
        //Over.NumStatic.GetComponent<Text>().text = pos.ToString();
        if(RecordControl.x == 0)
        {
            RecordControl.pos = pos;
            RecordControl.x++;
        }
        return pos!=-1;
    }




    // Reorganiza la tabla de records desplazando hacia abajo los records anteriores.
    public void Reorganiza(int pos, int newScore, string newName)
    {
        // Desde la posición que hemos cambiado hasta el final lo cambiamos

        int i = pos;
        bool final = false;


        int antS = newScore;
        string antN= newName;

        int auxS;
        string auxN;

        while(i< 11 && !final)
        {
            //print("it " + i + " = ");

            
            auxS = PlayerPrefs.GetInt("BestS" + i + " M:" + SelectedPlayer.SceneMap);
            auxN = PlayerPrefs.GetString("Best" + i + " M:" + SelectedPlayer.SceneMap);
            //print("retengo : Score = " + auxS + " Name: " + auxN);
            //print("Inserto : Score = " + antS + " Name: " + antN);
            PlayerPrefs.SetInt("BestS" + i + " M:" + SelectedPlayer.SceneMap, antS);
            PlayerPrefs.SetString("Best" + i + " M:" + SelectedPlayer.SceneMap, antN);

            if (auxS == 0)
            {
                final = true;
            }
            else
            {
                antS = auxS;
                antN = auxN;
            }
            i++;
        }
    }

    public void setRecord()
    {
        
        Name = input.GetComponent<Text>().text;


        //print("ActPunt = " + puntAct);
        int pos = RecordControl.pos;
        if (pos != -1){
            //print("POS = " + this.pos);
            Reorganiza(pos, puntAct, Name);
            //PlayerPrefs.SetInt("BestS" + pos + " M:" + SelectedPlayer.SceneMap, puntAct);
            //PlayerPrefs.SetString("Best" + pos + " M:" + SelectedPlayer.SceneMap, Name);
        }

        bt.gameObject.SetActive(false);
        Saved.SetActive(true);
        
    }
}
