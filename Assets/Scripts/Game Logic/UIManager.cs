using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerShoot playerShoot;
    public PlayerMovement playerMovement;
    public Text level;
    public Text health;
    public Text kills;
    public Text rof;
    public Text damage;
    public Text explosiveShots;
    public Text projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerShoot = playerShoot.GetComponent<PlayerShoot>();
        playerMovement = playerShoot.GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "Lv." + playerShoot.level.ToString();
        health.text = playerMovement.health.ToString() + "HP";
        kills.text = playerShoot.killCount.ToString();
        rof.text = "Fire Rate: " + playerShoot.rateOfFire.ToString();
        damage.text = "Damage: " + playerShoot.bulletDamage.ToString();
        projectileSpeed.text = "Projectile Speed: " + playerShoot.projectile.projectileSpeed.ToString();
        if (!playerShoot.projectile.explosive){explosiveShots.text = "";} else {explosiveShots.text = "Explosive Shots";}

    }
}
