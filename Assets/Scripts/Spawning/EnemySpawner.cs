using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Rigidbody2D body;

    // enemies object to spawn
    public GameObject zombie;
    public GameObject veteranZombie;
    public GameObject bones;

    public GameObject player;
    public PlayerShoot playerVar;
    // spawnrate
    public float spawnRate;
    float spawnTime = 0;

    Vector2 spawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1.5f;
        

    }

    private void Update() 
    {
        spawnTime += Time.deltaTime;


        // apply the area changes to all zombie instantiates otherwise i look stupid

        if (spawnTime > spawnRate)
        {
            // checks to see if the player is in the radius so it doesnt spawn the zombies on top of the play
            GameObject zombieObj = Instantiate(zombie, (new Vector3(Random.Range(0, GetComponentsInChildren<Transform>()[Random.Range(1, 5)].transform.position.x + 1), Random.Range(0, GetComponentsInChildren<Transform>()[Random.Range(1, 5)].transform.position.y + 1), 0) + (player.transform.position.normalized * 25)), transform.rotation);
            zombieObj.GetComponent<ZombieBehaviour>().player = player;
            zombieObj.GetComponent<ZombieBehaviour>().moveSpeed = 4.5f + (Mathf.Sqrt(playerVar.killCount)) * 0.04f;
            zombieObj.GetComponent<ZombieBehaviour>().health = 4 + (Mathf.Sqrt(playerVar.killCount)) * Mathf.Sqrt(playerVar.level);

            if (playerVar.level >= 15)
            {
                // change area
                GameObject veteranZombieObj = Instantiate(veteranZombie, (new Vector3(Random.Range(0, GetComponentsInChildren<Transform>()[Random.Range(1, 5)].transform.position.x + 1), Random.Range(0, GetComponentsInChildren<Transform>()[Random.Range(1, 5)].transform.position.y + 1), 0) + (player.transform.position.normalized * 25)), transform.rotation);
                veteranZombieObj.GetComponent<ZombieBehaviour>().player = player;
                veteranZombieObj.GetComponent<ZombieBehaviour>().moveSpeed = 6 + (Mathf.Sqrt(playerVar.killCount)) * 0.05f;
                veteranZombieObj.GetComponent<ZombieBehaviour>().health = 12 + (Mathf.Sqrt(playerVar.killCount)) * Mathf.Sqrt(playerVar.level);
                
            }
            if (playerVar.level >= 35)
            {
                // chage area
                GameObject bonesObj = Instantiate(bones, (new Vector3(Random.Range(0, GetComponentsInChildren<Transform>()[Random.Range(1, 5)].transform.position.x + 1), Random.Range(0, GetComponentsInChildren<Transform>()[Random.Range(1, 5)].transform.position.y + 1), 0) + (player.transform.position.normalized * 25)), transform.rotation);
                bonesObj.GetComponent<ZombieBehaviour>().player = player;
                bonesObj.GetComponent<ZombieBehaviour>().moveSpeed = 8 + (Mathf.Sqrt(playerVar.killCount)) * 0.05f;
                bonesObj.GetComponent<ZombieBehaviour>().health = 36 + (Mathf.Sqrt(playerVar.killCount)) * Mathf.Sqrt(playerVar.level);

            }


            spawnTime = 0;

        }
    
    }


}
