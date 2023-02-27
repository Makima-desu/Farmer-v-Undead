using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D body;
    Animator animator;
    Vector2 movement;

    public float moveSpeed;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // get the direction to the player
        Vector3 direction = (player.transform.position - transform.position).normalized;
        movement = direction;

        if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = Vector3.one;

        }
        else if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }

        if (health < 0)
        {
            Destroy(gameObject);
            player.GetComponent<PlayerShoot>().killCount += 1;

        }
        
        
    }

    private void FixedUpdate() 
    {
        // apply the velocity since movement is always updated with direction
        // direction gets the new coordinates of the player on each frame
        body.velocity = new Vector2(movement.x, movement.y) * moveSpeed;

    
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player Bullet")
        {
            // get the player component to access bullet damage
            animator.SetTrigger("Hit"); // set trigger of hit
            health -= player.GetComponent<PlayerShoot>().bulletDamage;

        }
    
    }
}
