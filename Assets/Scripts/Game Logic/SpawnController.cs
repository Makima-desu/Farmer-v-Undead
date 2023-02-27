using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject chest;
    public PlayerShoot player;

    float time = 0;
    float spawnRate = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        // the minimal amount of time to wait
        if (time > spawnRate)
        {
            // get a random chance
            int random = Random.Range(0, 101);
            // if chance exceeds 75 or technically < 25%
            // spawn the chest
            if (random > 65)
            {
                GameObject chestObj = Instantiate(chest, new Vector3(Random.Range(-15, 16), Random.Range(-15, 16), 0), transform.rotation);
                chestObj.GetComponent<Chest>().player = player;

            }
            time = 0;


        }

    }
}
