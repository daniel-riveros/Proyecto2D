using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuestraTexto : MonoBehaviour
{
    Text texto;
    public Slider Sl;

    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
    }

    public void textUpdate()
    {
        texto.text = Sl.value.ToString();
    }
}
