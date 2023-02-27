using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject bullet;
    public float projectileSpeed = 8;
    public bool explosive = false;
    bool piercing;
    public float range = 5;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
            for (int i = 0; i < explosiveBullets; ++i)
            {
                GameObject bulletObj = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
                bulletObj.GetComponent<WeaponProjectile>().explosive = false;
                bulletObj.GetComponent<WeaponProjectile>().piercing = true;
                bulletObj.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;;
                angle += 36;


            }

        }
        else if (piercing && collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
        if (!piercing) {Destroy(gameObject);}
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);

        }

    
    }
}
