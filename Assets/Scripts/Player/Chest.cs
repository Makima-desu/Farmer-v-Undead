using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public PlayerShoot player;
    public WeaponProjectile projectile;
    // player level
    // player fire rate
    // player projectile Speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addFireRate()
    {
        if (player.rateOfFire > 0.15f)
        {
            player.rateOfFire -= Random.Range(0.05f, 0.1f);

        } 
        else addBulletDamage();

    }

    void addProjectileSpeed()
    {
        player.projectile.projectileSpeed += Random.Range(0.5f, 1.5f);

    }

    void addBulletDamage()
    {
        player.bulletDamage += Random.Range(0.5f, 5);

    }

    void addBulletCount()
    {
        if (player.bulletCount < 20)
        {
            player.bulletCount += 1;

        }
        else addBulletDamage();

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player")
        {
            int random = Random.Range(0, 101);
            if (random >= 75 && random <= 80)
            {
                if (!player.projectile.explosive)
                {
                    player.projectile.explosive = true;

                }
                else addBulletDamage();
            }
            else if (random > 80)
            {
                addBulletCount();

            }
            else
            {
                random = Random.Range(1, 4);
                switch (random)
                {
                    case 1:
                    {
                        addBulletDamage();
                        break;
                    }
                    case 2:
                    {
                        addFireRate();
                        break;
                    }
                    case 3:
                    {
                        addProjectileSpeed();
                        break;   
                    }

                }

            }
            Destroy(gameObject);

        }    
    
    }


}
