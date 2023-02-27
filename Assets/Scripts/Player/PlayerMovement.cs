using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D body;
    Animator animator;

    Vector2 movement;
    public float moveSpeed = 8;
    public float health;

    float time = 1;
    float waitTillNextDamage = 2;




    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = 10;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (health < 0)
        {
            // code for stopping gyame
        }

    }

    private void FixedUpdate() 
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // get the x movement
        movement.y = Input.GetAxisRaw("Vertical"); // get the y movement
        
        if (movement.x > 0)
        {
            transform.localScale = Vector3.one;

        }
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        
        // move the body by adding to body2d position by multiplying both inputs of axis and their movespeed
        body.MovePosition(body.position + movement * moveSpeed * Time.deltaTime);

        animator.SetBool("run", movement.x != 0 || movement.y != 0);


    }

    private void OnTriggerStay2D(Collider2D collision) 
    {

        if (collision.gameObject.layer == 7)
        {
            if (time > waitTillNextDamage)
            {
                health -= 2;
                time = 0;

            }
            

        }
    
    }

}
