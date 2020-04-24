using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Pathfinding;


public class Enemy : MonoBehaviour
{
    //public float speed = 4f;
    public Transform player;
    Rigidbody2D rb2d;
    Vector2 mov;
    public float moveSpeed = 4f;
    //Animator anim;
    //public AIPath aiPath;

    void Start()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        this.mov = new Vector2(
            -1,
            0
        );

        if (mov != Vector2.zero)
        {
            anim.SetFloat("Mov_x", mov.x);
            anim.SetFloat("Mov_y", mov.y);
            anim.SetBool("Walking",true);
        }
        else
        {
            anim.SetBool("Walking",false);
        }
        */
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb2d.rotation =  angle;
        direction.Normalize();
        mov = direction;
    }

    void moveCharacter(Vector2 direction) {
        rb2d.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
