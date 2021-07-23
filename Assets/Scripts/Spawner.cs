using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] hazards;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    //connecting the spawner script to player, so that it does not show error once the character is destroyed
    public GameObject player;

    //used to have max difficulty in game, minimum time between spawns
    public float minTimeBtwSpawns;
    //so that difficuly is increased this variable will be used to decrease the time between enemy spawns
    public float decrease;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (timeBtwSpawns <= 0)
            {
                //spawn hazards
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];
                //spawn random hazards at random points

                Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);

                //checking if the game is still easier than maximum difficultuy
                if (startTimeBtwSpawns > minTimeBtwSpawns)
                {
                    //decrease time between spawn times to increase difficulty
                    startTimeBtwSpawns -= decrease;
                }

                timeBtwSpawns = startTimeBtwSpawns;

            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;

            }
        }
    }
}
