using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{
    //variaciones entre personajes
    string ActualState;
    string ActualTrigger;
    string ActualDead;
    string ActualAttack;

    int cont1 = 0;
    int cont2 = 0;

    //Texturas
    public Texture texture;

    string StateEasy = "Facil_Attack";
    string StateMedium = "Bob_Attack";
    string StateHard = "Attack_Dificil";

    string EasyTrigger = "Attack3";
    string MediumTrigger = "Attack1";
    string HardTrigger = "Attack2";

    string DeadEasy = "Facil_Dead";
    string DeadMedium = "Bob_Dead";
    string DeadHard = "Dificil_Dead";

    string A1 = "a1";
    string A2 = "a2";
    string A3 = "a3";


    // Desplazamiento del ataque de los personajes (rango)
    double desplazamientoX;
    double desplazamientoY;


    // Velocidad de jugador
    float speed = 4f;
    Rigidbody2D rb2d;
    Animator anim;
    Vector2 mov;

    CircleCollider2D attackCollider;
    GameObject initialMap;

    GameObject[] Players;
    string PlayerName;
    //Variables relacionadas con la vida
    public int maxHp;
    public int hp;
    float time = 1f;
    float lifeSteal;


    // Puntuacion del jugador
    int punt = 0;
    public Text textpoint;
    int total;
    int final;


    //Puntuación endgame del jugador
    private Over overScript;
    GameObject target;


    // Al inicio del juego
    GameObject area;
    GameObject UI;

    int contSound;
    private void Awake()
    {

        // ELIMINA ESTO PA QUE FUNCIONE EL MENU DE SELECCION
        //SelectedPlayer.selected = "Easy";
        //SelectedPlayer.SceneMap = 3;
        MenuFin.isGameOver = false;



        initialMap = GameObject.FindGameObjectWithTag("Initial_Map");
        Assert.IsNotNull(initialMap);

        Players = GameObject.FindGameObjectsWithTag("Player");
        for(int i= 0; i < Players.Length; i++)
        {
            Players[i].SetActive(false);
            if (SelectedPlayer.selected.Equals("Easy") && Players[i].name == "PersonajeFacil")
            {
                Players[i].SetActive(true);
                
            }
            else if (SelectedPlayer.selected.Equals("Medium") && Players[i].name == "PersonajeMedio")
            {
                Players[i].SetActive(true);
                
            }
            else if (SelectedPlayer.selected.Equals("Hard") && Players[i].name == "Personaje_Dificil")
            {
                Players[i].SetActive(true);
                
            }
        }
            

    }

    public void IncHP()
    {
        if(hp < maxHp)
        {
            this.hp++;
        }
    }

    public void IncPunt()
    {
        this.punt += 100;
        textpoint.text = punt.ToString();
    }
    public int GetScore()
    {
        if(cont1< this.punt)
        {
            cont1 += 5;
        }
        this.final = this.punt;
        return this.cont1;
    }

    
    public string GetRecord()
    {
        
         return PlayerPrefs.GetInt("BestS" + 1 + " M:" + SelectedPlayer.SceneMap).ToString();
 
    }

    public int GetTotal()
    {
        this.total = this.punt + 500;
        if (cont2 < this.total)
        {
            cont2 += 5;
        }
        this.final = this.total;
        return this.cont2;
    }

    public int GetFinal()
    {
        return this.final;
    }


    // Start is called before the first frame update
    void Start()
    {


        

        UI = GameObject.FindGameObjectWithTag("UI_Punt");
        area = GameObject.FindGameObjectWithTag("Area");
        StartCoroutine(area.GetComponent<Area>().ShowArea(initialMap.name));
        //El funcionamiento del script dependerá del personaje elegido.
        // Player = GameObject.FindGameObjectWithTag("Player");
        PlayerName = SelectedPlayer.selected;
        if (PlayerName.Equals("Easy"))
        {
            ActualState = StateEasy;
            ActualTrigger = EasyTrigger;
            ActualDead = DeadEasy;
            ActualAttack = A1;
            speed = 3f;
            lifeSteal = 5; // 5%

            // Dependiendo del personaje tiene una vida máxima?
            this.maxHp = 13;
            this.desplazamientoX = 2;
            this.desplazamientoY = 2;
        }
        else if (PlayerName.Equals("Medium"))
        {
            ActualState = StateMedium;
            ActualTrigger = MediumTrigger;
            ActualDead = DeadMedium;
            ActualAttack = A2;
            speed = 4f;
            lifeSteal = 10; // 10%
            this.maxHp = 10;
            this.desplazamientoX = 1.5;
            this.desplazamientoY = 1.5;
        }
        else
        {
            ActualState = StateHard;
            ActualTrigger = HardTrigger;
            ActualDead = DeadHard;
            ActualAttack = A3;
            speed = 6f;
            lifeSteal = 15; // 15%
            this.maxHp = 7;
            this.desplazamientoX = 1.5;
            this.desplazamientoY = 1.5;
        }

        punt = 0;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
        
        //Inicialización de la vida al máximo
         hp = maxHp;

        //Seguimiento de la cámara.
        Camera.main.GetComponent<MainCamera>().SetBound(initialMap);
        
        //Inicialización para poder mostrar los valores tanto de puntuación como de record
        target = GameObject.FindGameObjectWithTag("Manager");
        contSound = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!MenuFin.isGameOver)
        {

            if (contSound == 0)
            {
                SoundManagerScript.PlaySound("Start_Man");
                contSound++;
            }
            // Para la animación de muerte
            AnimatorStateInfo stateInfoDead = anim.GetCurrentAnimatorStateInfo(0);

            if (stateInfoDead.IsName(ActualDead) && stateInfoDead.normalizedTime >= 1)
            {
                this.final = this.punt;
                Destroy(gameObject);
            }


            attackCollider.enabled = false;

            this.mov = new Vector2(
                 Input.GetAxisRaw("Horizontal"), // Detectamos si presionamos derecha o izquierda (1 o -1)
                 Input.GetAxisRaw("Vertical")
            );

            if (mov != Vector2.zero)
            {
                anim.SetFloat("Mov_x", mov.x);
                anim.SetFloat("Mov_y", mov.y);
                anim.SetBool("Walking", true);
            }
            else
            {
                anim.SetBool("Walking", false);
            }

            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
            bool attacking = stateInfo.IsName(ActualState);

            if (Input.GetKeyDown("space") && !attacking)
            {
                anim.SetTrigger(ActualTrigger);
                SoundManagerScript.PlaySound(ActualAttack);
            }

            //Actualización del movimiento
            if (mov != Vector2.zero) attackCollider.offset = new Vector2((mov.x * (float)desplazamientoX) / 2, (mov.y * (float)desplazamientoY) / 2);

            if (attacking)
            {

                float playbackTime = stateInfo.normalizedTime;
                if (playbackTime > 0.8 && playbackTime < 0.83)
                    attackCollider.enabled = true;
                else
                    attackCollider.enabled = false;
            }
        }
        

     }

    public void Attacked() {
        if (hp > 0)
        {

            if (--hp <= 0)
            {
                this.final = this.punt;
                SoundManagerScript.PlaySound("Dead_Man");
                SoundManagerScript.PlaySound("GO");

                // Desactivamos el UI
                UI.SetActive(false);

                //cambiamos al estado muerto para hacer una animación.
                anim.Play(ActualDead);
                Over.show();
                //overScript.showI();

            }
        }
        

         
    }

    void OnTriggerEnter2D (Collider2D col) {
        ///--- Restamos uno de vida si es un enemigo
        if (col.tag == "Enemy")
        {
            col.SendMessage("Attacked");
            if (PlayerName.Equals("Easy"))
                col.SendMessage("Attacked");


            // En cada hit puede curarse (tanto a los enemigos como a los jarrones)
            if (hp < maxHp)
            {
                float r = Random.value;
                if (lifeSteal > (r * 100))
                {
                    this.hp++;
                    SoundManagerScript.PlaySound("heal");
                }
            }

        }
        
    }

    private void FixedUpdate()
    {
        // Nos movemos en el fixed por las fisicas
        if(!MenuFin.isGameOver)
            rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }

    ///---  Dibujamos las vidas del enemigo en una barra 
    void OnGUI() {
        // Guardamos la posición del enemigo en el mundo respecto a la cámara
        Vector2 pos = Camera.main.WorldToScreenPoint (transform.position);
        

        // Dibujamos el cuadrado debajo del enemigo con el texto
        GUI.Box(
            new Rect(
                pos.x - 20,                   // posición x de la barra
                Screen.height - pos.y + 15,   // posición y de la barra
                40,                           // anchura de la barra    
                24                            // altura de la barra  
            ), hp + "/" + maxHp               // texto de la barra
        );
    }

}
