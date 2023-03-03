using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public EnemySpawner spawner;
    public WeaponProjectile projectile;
    public PlayerMovement playerMovement;

    public float rateOfFire = 0.3f;
    float time = 0.0f;
    public int bulletCount = 1;

    float angle;
    Vector3 mousePosition;
    Vector3 worldPos;

    public float killCount;
    public float level;

    public float bulletDamage;
    public float offsetAngle;


    // Start is called before the first frame update
    void Start()
    {
        // projectile = GetComponent<WeaponProjectile>();
        offsetAngle = 10;
        bulletDamage = 2;
        killCount = 0;
        level = 1;
        projectile.projectileSpeed = 6;
        projectile.explosive = false;
        projectile.shovelSprite = false;
        projectile.spriteRenderer.sprite = projectile.bulletSprite;
        projectile.transform.localScale = new Vector3(1, 1, 1);
        projectile.piercing = false;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        // get the position of the mouse in pixels
        mousePosition = Input.mousePosition;
        // capture the mouse in front of the camera 
        // otherwise it will it not capture it // can be any positive value probably
        mousePosition.z = Camera.main.nearClipPlane = 1;
        // get the mouse position inside a world
        worldPos = Camera.main.ScreenToWorldPoint(mousePosition);

        // convert the mouse position to an angle by minusing world cursor position and the position of the player
        // so its shooting from 0,0 position or something like that I have zero idea
        // and convert it from rdaiance to degrees
        angle = Mathf.Atan2(worldPos.y - transform.position.y, worldPos.x - transform.position.x) * Mathf.Rad2Deg;

        if (time > rateOfFire)
        {
            // divide the angle according to the amount of bullets so the spread is equal
            float changeOffset = offsetAngle * bulletCount; // 10 * 2 = 20
            float angleStep = changeOffset / bulletCount; // 20 / 2 = 10
            float centeringOffset = (changeOffset / 2) - (angleStep / 2); // 20 / 2 = 10 - 10 / 2 = 5 = 5
            for (int i = 0; i < bulletCount; ++i)
            {
                // assing the current angle depending on which shot it is
                // angleStep = 10, angleStep * 0 = 0 so the angle is 0 and so on
                float currentBulletAngle = angleStep * i; // 10 * 2 = 20Deg
                // current mouse angel + (20 - 5 = 15) 
                GameObject bulletObj = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle + (currentBulletAngle - centeringOffset)));
                bulletObj.GetComponent<WeaponProjectile>().bullet = bullet;

            }
            
            time = 0;

        }

        // note to self
        // if needed an increment of a specific stat, add something like here
        // kill count and the players current health, if they add up with a remainder of 0 it heals the player by 1
        if ((killCount + level) % 11 == 0 )
        {
            level++;
            if (playerMovement.health <= 50)
            {
                playerMovement.health += 0.2f;

            }
            if (spawner.spawnRate >= 0.10f)
            {
                spawner.spawnRate -= Random.Range(0.05f, 0.031f);

            }
            if (playerMovement.moveSpeed < 12)
            {
                playerMovement.moveSpeed += 0.2f;
            }

        }


        
    }



}

