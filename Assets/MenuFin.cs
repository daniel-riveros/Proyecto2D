using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFin : MonoBehaviour
{
    public GameObject End; //GameObject para el fin del juego
    public GameObject ScoreEnd;
    public GameObject ExtraEnd;
    public GameObject TotalEnd;
    public GameObject NextButton;
    public GameObject NewRecord;
    public GameObject Panel;
    public GameObject PlayerScore;
    public GameObject PlayerTotal;
    public GameObject Num;

    public static GameObject StaticEnd; //GameObject apra el final
    public static GameObject StaticScoreEnd;
    public static GameObject StaticExtraEnd;
    public static GameObject StaticTotalEnd;
    public static GameObject StaticNextButton;
    public static GameObject NewRecordStatic;
    public static GameObject StaticPanel;
    public static GameObject StaticPlayerScore;
    public static GameObject StaticPlayerTotal;
    public static GameObject NumStatic;
    static Movimiento movementScript;
    public static bool isGameOver ;

    GameObject target;

    static int Cont = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player");
        movementScript = target.GetComponent<Movimiento>();

        MenuFin.StaticEnd = End;
        MenuFin.StaticScoreEnd = ScoreEnd;
        MenuFin.StaticExtraEnd = ExtraEnd;
        MenuFin.StaticTotalEnd = TotalEnd;
        MenuFin.NewRecordStatic = NewRecord;
        MenuFin.StaticPanel = Panel;
        MenuFin.StaticNextButton = NextButton;
        MenuFin.StaticPlayerScore = PlayerScore;
        MenuFin.StaticPlayerTotal = PlayerTotal;
        MenuFin.NumStatic = Num;

        MenuFin.StaticEnd.gameObject.SetActive(false);
        MenuFin.StaticScoreEnd.gameObject.SetActive(false);
        MenuFin.StaticExtraEnd.gameObject.SetActive(false);
        MenuFin.StaticTotalEnd.gameObject.SetActive(false);
        MenuFin.StaticNextButton.gameObject.SetActive(false);
        MenuFin.StaticPanel.gameObject.SetActive(false);
        MenuFin.StaticPlayerScore.gameObject.SetActive(false);
        MenuFin.StaticPlayerTotal.gameObject.SetActive(false);
        MenuFin.NewRecordStatic.gameObject.SetActive(false);
        MenuFin.NumStatic.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Show()
    {
        isGameOver = true;
        MenuFin.StaticEnd.gameObject.SetActive(true);
        MenuFin.StaticScoreEnd.gameObject.SetActive(true);
        MenuFin.StaticExtraEnd.gameObject.SetActive(true);
        MenuFin.StaticTotalEnd.gameObject.SetActive(true);
        MenuFin.StaticNextButton.gameObject.SetActive(true);
        MenuFin.StaticPanel.gameObject.SetActive(true);

        MenuFin.StaticPlayerScore.gameObject.GetComponent<Text>().text = movementScript.GetScore().ToString();
        MenuFin.StaticPlayerScore.gameObject.SetActive(true);

        MenuFin.StaticPlayerTotal.gameObject.GetComponent<Text>().text = movementScript.GetTotal().ToString();
        MenuFin.StaticPlayerTotal.gameObject.SetActive(true);

        if(Cont == 0)
        {
            SoundManagerScript.PlaySound("win");
        }
        Cont++;
        

        if (RecordControl.isRecord(movementScript.GetFinal()))
        {
            MenuFin.NewRecordStatic.gameObject.SetActive(true);
            MenuFin.NumStatic.gameObject.SetActive(true);
            MenuFin.NumStatic.GetComponent<Text>().text = RecordControl.pos.ToString();
        }
        
//        Time.timeScale = 0f;
    }
}
