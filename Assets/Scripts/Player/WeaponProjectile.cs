using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public Sprite shovel;
    public Sprite bulletSprite;
    public GameObject bullet;

    public float projectileSpeed = 8;
    public bool explosive = false;
    public bool piercing;

    public float range = 5;
    float time;

    public bool shovelSprite;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        body.velocity = transform.right * projectileSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > range)
        {
            Destroy(gameObject);
        }
        
    }

    float explosiveBullets = 10;
    float angle = 0;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (explosive)
        {
            Destroy(gameObject);
            if (collision.gameObject.layer != 8) 
            {
                for (int i = 0; i < explosiveBullets; ++i)
                {
                    GameObject bulletObj = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
                    bulletObj.GetComponent<WeaponProjectile>().explosive = false;
                    bulletObj.GetComponent<WeaponProjectile>().piercing = true;
                    bulletObj.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;;
                    angle += 36;

                }
            }

        }
        else if (piercing && collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
        if (shovelSprite)
        {
            // check to see if the are zombies in the radius when the bullet colldies
            var colliders = Physics2D.OverlapCircleAll(transform.position, 3.5f);
            // for all zombies
            foreach (var collider in colliders)
            {
                // if it matches the zombie layer
                if (collider.gameObject.layer == 7)
                {
                    // initiate a hit from zombie behaviour function
                    collider.gameObject.GetComponent<ZombieBehaviour>().zombieHit();

                }
            }

        }
        if (!piercing) {Destroy(gameObject);}
        if (collision.gameObject.layer == 8){Destroy(gameObject);}

    
    }
}
