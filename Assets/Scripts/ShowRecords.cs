using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRecords : MonoBehaviour
{

    public GameObject Tabla1;
    public GameObject Tabla2;
    public GameObject Tabla3;


    // Start is called before the first frame update
    void Start()
    {
        // Mapa 2, 3 y 4
        int i = 0;
        string name2;
        string punt2;
        string name3;
        string punt3;
        string name4;
        string punt4;

        while (i< 10)
        {
            
            name2 = PlayerPrefs.GetString("Best" + (i+1) + " M:" + 2);
            punt2 = PlayerPrefs.GetInt("BestS" + (i+1) + " M:" + 2).ToString();
            name3 = PlayerPrefs.GetString("Best" + (i + 1) + " M:" + 3);
            punt3 = PlayerPrefs.GetInt("BestS" + (i + 1) + " M:" + 3).ToString();
            name4 = PlayerPrefs.GetString("Best" + (i + 1) + " M:" + 4);
            punt4 = PlayerPrefs.GetInt("BestS" + (i + 1) + " M:" + 4).ToString();

            Tabla1.transform.GetChild(i).GetComponent<Text>().text = (i+1) + ": " + name2 + " / " + punt2;
            Tabla2.transform.GetChild(i).GetComponent<Text>().text = (i + 1) + ": " + name3 + " / " + punt3;
            Tabla3.transform.GetChild(i).GetComponent<Text>().text = (i + 1) + ": " + name4 + " / " + punt4;
            i++;
        }
       
        
    }

    public void Recarga()
    {
        // Mapa 2, 3 y 4
        int i = 0;
        string name2;
        string punt2;
        string name3;
        string punt3;
        string name4;
        string punt4;

        while (i < 10)
        {

            name2 = PlayerPrefs.GetString("Best" + (i + 1) + " M:" + 2);
            punt2 = PlayerPrefs.GetInt("BestS" + (i + 1) + " M:" + 2).ToString();
            name3 = PlayerPrefs.GetString("Best" + (i + 1) + " M:" + 3);
            punt3 = PlayerPrefs.GetInt("BestS" + (i + 1) + " M:" + 3).ToString();
            name4 = PlayerPrefs.GetString("Best" + (i + 1) + " M:" + 4);
            punt4 = PlayerPrefs.GetInt("BestS" + (i + 1) + " M:" + 4).ToString();

            Tabla1.transform.GetChild(i).GetComponent<Text>().text = (i + 1) + ": " + name2 + " / " + punt2;
            Tabla2.transform.GetChild(i).GetComponent<Text>().text = (i + 1) + ": " + name3 + " / " + punt3;
            Tabla3.transform.GetChild(i).GetComponent<Text>().text = (i + 1) + ": " + name4 + " / " + punt4;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
