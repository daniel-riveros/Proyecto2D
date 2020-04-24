using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_FB : MonoBehaviour
{
    public EnemyGeneratorController EGC; //objeto del generador de enemigos.
    Movimiento Player;
    public AIPath Astar;

    public float speed = 3f;
    public Vector2 direction;
    Animator anim;

    GameObject Respawn;

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

    CircleCollider2D attackCollider;

    //Variables relacionadas con la vida
    public int maxHp = 3;
    public int hp;
    float time = 1.25f;


    // Muerte
    public string destroyState;


    // Start is called before the first frame update
    void Start()
    {
        destroyState = "FB_Dead";
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

        AnimatorStateInfo stateInfoDead = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfoDead.IsName(destroyState) && stateInfoDead.normalizedTime >= 1)
        {
            Destroy(gameObject);
        }


        AnimatorStateInfo stateInfo1 = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo1.IsName("FB_revive"))
        {
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
                //En caso de llegar al enemigo:
                anim.SetBool("Walking", false);
                AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                attacking = stateInfo.IsName("FB_Attack");
                anim.SetBool("Attack", true);

                //Actualización del movimiento
                if (attacking)
                {
                    attackCollider.offset = new Vector2(mov.x, mov.y);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        ///--- Restamos uno de vida si es un enemigo
        if (col.tag == "Player") col.SendMessage("Attacked");
    }

    //Gestión del ataque del esqueleto, si se acaban las vidas... destruimos y descontamos número
    public void Attacked()
    {
        if (hp > 0)
        {
            if (--hp == 0)
            {

                // Hacemos que no se pueda mover si esta muerto
                this.GetComponent<AIPath>().canSearch = false;

                //cambiamos al estado muerto para hacer una animación.
                anim.Play(destroyState);


                imDead = true;
                // Si estamos muertos debemos dejar de buscar
                EGC.incMuerte();
                Player.IncPunt();

                Destroy(gameObject, time);
            }
        }
    }

        
}