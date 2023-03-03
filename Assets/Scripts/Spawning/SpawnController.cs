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
            // if chance exceeds 50 or technically < 50%
            // spawn the chest
            if (random >= 50)
            {
                int area = Random.Range(1, 5);
                Vector3 spawnPoint = new Vector3(Random.Range(0, GetComponentsInChildren<Transform>()[area].transform.position.x + 1), Random.Range(0, GetComponentsInChildren<Transform>()[area].transform.position.y + 1), 0);
                GameObject chestObj = Instantiate(chest, spawnPoint, transform.rotation);
                chestObj.GetComponent<Chest>().player = player;

            }
            time = 0;


        }

    }
}
