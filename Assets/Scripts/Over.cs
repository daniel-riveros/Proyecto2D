using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Over : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject Score;
    public GameObject Record;
    public GameObject BackGround;
    public GameObject ScorePlayer;
    public GameObject ScoreRecord;
    public GameObject Retry;
    public GameObject Exit;
    public GameObject B_Retry; //GameObject para el boton
    public GameObject B_Exit; //GameObject para el boton
    public GameObject NewRecord;
    public GameObject Num;

    public static GameObject GameOverStatic;
    public static GameObject ScoreStatic;
    public static GameObject RecordStatic;
    public static GameObject BackStatic;
    public static GameObject TextScoreStatic; //guarda nuestra puntuación para mostrarla.
    public static GameObject TextScoreRecordStatic; //Guarda el record máximo para mostrarlo posteriormente.
    public static GameObject RetryStatic;
    public static GameObject ExitStatic;
    public static GameObject B_RetryStatic; //GameObject para el boton modificable desde fuera.
    public static GameObject B_ExitStatic; //GameObject para el boton modificable desde fuera.
    public static GameObject NewRecordStatic;
    public static GameObject NumStatic;
    

    public static Movimiento movementScript;

    

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
        
        target = GameObject.FindGameObjectWithTag("Player");
        movementScript = target.GetComponent<Movimiento>();
        

        Over.GameOverStatic = GameOverText;
        Over.ScoreStatic = Score;
        Over.RecordStatic = Record;
        Over.BackStatic = BackGround;
        Over.TextScoreStatic = ScorePlayer;
        Over.TextScoreRecordStatic = ScoreRecord;
        Over.RetryStatic = Retry;
        Over.ExitStatic = Exit;
        Over.B_RetryStatic = B_Retry;
        Over.B_ExitStatic = B_Exit;
        Over.NewRecordStatic = NewRecord;
        Over.NumStatic = Num;
        


        Over.GameOverStatic.gameObject.SetActive(false);
        Over.ScoreStatic.gameObject.SetActive(false);
        Over.RecordStatic.gameObject.SetActive(false);
        Over.BackStatic.gameObject.SetActive(false);
        Over.TextScoreStatic.gameObject.SetActive(false);
        Over.TextScoreRecordStatic.gameObject.SetActive(false);
        Over.RetryStatic.gameObject.SetActive(false);
        Over.ExitStatic.gameObject.SetActive(false);
        Over.B_RetryStatic.gameObject.SetActive(false);
        Over.B_ExitStatic.gameObject.SetActive(false);
        Over.NewRecordStatic.gameObject.SetActive(false);
        Over.NumStatic.gameObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void show()
    {
        MenuFin.isGameOver = true;
        Over.GameOverStatic.gameObject.SetActive(true);
        Over.ScoreStatic.gameObject.SetActive(true);
        Over.RecordStatic.gameObject.SetActive(true);
        Over.BackStatic.gameObject.SetActive(true);
        Over.RetryStatic.gameObject.SetActive(true);
        Over.ExitStatic.gameObject.SetActive(true);

        TextScoreStatic.gameObject.GetComponent<Text>().text = movementScript.GetFinal().ToString();
        Over.TextScoreStatic.gameObject.SetActive(true);
        TextScoreRecordStatic.gameObject.GetComponent<Text>().text = movementScript.GetRecord();
        Over.TextScoreRecordStatic.gameObject.SetActive(true);
        Over.B_RetryStatic.gameObject.SetActive(true);
        Over.B_ExitStatic.gameObject.SetActive(true);
       
        if (RecordControl.isRecord(movementScript.GetFinal()))
        {
            Over.NewRecordStatic.gameObject.SetActive(true);
            Over.NumStatic.gameObject.SetActive(true);
            Over.NumStatic.GetComponent<Text>().text = RecordControl.pos.ToString();
                

        }
    }

}
