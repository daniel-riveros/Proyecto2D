using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFollow : MonoBehaviour
{
    public GameObject AttackSound;
    public EnemyGeneratorController EGC; //objeto del generador de enemigos.
    Movimiento Player;
    public AIPath Astar;

    public float speed = 3f;
    public Vector2 direction;
    Animator anim;

    GameObject Respawn;

    // Posibles sonidos cuando es atacado
    string S1 = "e1";
    string S2 = "e2";
    string S3 = "e3";

    // Contador de repetición de sonido
    int max = 150;
    public int cont = 0;

    //Variables relacionadas con el ataque
    public float attackSpeed = 2f;
    float CloseToYou = 2.5f;
    public float distance;
    Vector2 mov;
    bool attacking;
    public GameObject target;

    bool imDead;
    bool imLiving;

    // Tiempo de espera antes de ejecutar ninguna acción
    int bloqueo = 100;

    int contSound = 0;

    CircleCollider2D attackCollider;

    //Variables relacionadas con la vida
     public int maxHp = 3;
     public int hp;
     float time = 1.25f;


    // Offset de ataque
    float offset = 5f;

    // Muerte
    public string destroyState;


    // Start is called before the first frame update
    void Start()
    {
        destroyState = "Skeleton_Dead";
        this.GetComponent<AIPath>().canSearch = false;
        imLiving = true;
        imDead = false;
        target = GameObject.FindGameObjectWithTag("Player");
        Player = target.GetComponent<Movimiento>();
        anim = GetComponent<Animator>();
        
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;

        //Inicializamos la vida del enemigo de manera que tenga la máxima posible
        hp = maxHp;

        Respawn = GameObject.FindGameObjectWithTag("Respawn");
        EGC = Respawn.GetComponent<EnemyGeneratorController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!MenuFin.isGameOver)
        {

            AnimatorStateInfo stateInfoDead = anim.GetCurrentAnimatorStateInfo(0);

            if (stateInfoDead.IsName(destroyState) && stateInfoDead.normalizedTime >= 1)
            {
                Destroy(gameObject);
            }


            AnimatorStateInfo stateInfo1 = anim.GetCurrentAnimatorStateInfo(0);
            if (stateInfo1.IsName("Skeleton_Revive"))
            {
                //Instantiate(AttackSound);
                if (contSound == 0)
                {
                    SoundManagerScript.PlaySound("Hit1");
                    this.contSound++;
                }

                imLiving = true;
            }
            else
            {
                imLiving = false;
            }


            if (!imDead && !imLiving)
            {
                this.GetComponent<AIPath>().canSearch = true;
                this.direction = (target.transform.position - transform.position).normalized;
                this.mov = direction;
                this.distance = Vector2.Distance(target.transform.position, transform.position);

                //Para movernos y activar la animación de caminar.
                if (distance > CloseToYou)
                {
                    anim.SetFloat("Mov_x", mov.x);
                    anim.SetFloat("Mov_y", mov.y);
                    //modificamos las direcciones para las animaciones.
                    anim.SetBool("Walking", true);
                }
                else
                {
                    // Estamos atacando
                    if (cont < 2)
                    {
                        SoundManagerScript.PlaySound(S2);
                    }
                    else if (cont > max)
                    {
                        cont = 0;
                    }

                    cont++;


                    //En caso de llegar al enemigo:
                    anim.SetBool("Walking", false);
                    AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                    attacking = stateInfo.IsName("Skeleton_Attack");
                    anim.SetBool("Attack", true);

                    //Actualización del movimiento
                    if (attacking)
                    {
                        attackCollider.offset = new Vector2(mov.x * offset, mov.y * offset);
                        float playbackTime = stateInfo.normalizedTime;

                        if (playbackTime > 0.5 && playbackTime < 1.0)
                            attackCollider.enabled = true;
                        else
                            attackCollider.enabled = false;

                        if (playbackTime > 1.0)
                        {
                            anim.SetFloat("Mov_x", mov.x);
                            anim.SetFloat("Mov_y", mov.y);
                            anim.SetBool("Attack", false);

                        }
                    }
                }
            }
        }
        else
        {
            anim.Play(destroyState);

            AnimatorStateInfo stateInfoDead = anim.GetCurrentAnimatorStateInfo(0);

            if (stateInfoDead.IsName(destroyState) && stateInfoDead.normalizedTime >= 1)
            {
                Destroy(gameObject);
            }
        }
    }
    
    void OnTriggerEnter2D (Collider2D col) {
        ///--- Restamos uno de vida si es un enemigo
        if (!MenuFin.isGameOver)
            if (col.tag == "Player") col.SendMessage("Attacked");
    }

    //Gestión del ataque del esqueleto, si se acaban las vidas... destruimos y descontamos número
    public void Attacked(){
        if (hp > 0)
        {
            // Si he sido atacado
            SoundManagerScript.PlaySound(S3);

            if (--hp == 0)
            {

                // Hacemos que no se pueda mover si esta muerto
                this.GetComponent<AIPath>().canSearch = false;

                //cambiamos al estado muerto para hacer una animación.
                anim.Play(destroyState);
                SoundManagerScript.PlaySound("Hit2");
                imDead = true;
                // Si estamos muertos debemos dejar de buscar
                EGC.incMuerte();
                Player.IncPunt();

                
            }
        }
    }

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
