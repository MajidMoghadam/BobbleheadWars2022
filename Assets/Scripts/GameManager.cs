using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;   //reference to the SpaceMarine
    public GameObject[] spawnPoints;    //reference to the enemy spawn locations
    public GameObject alien;    //reference to enemy prefab, which you use to create an 
                                //many instances from
    public int maxAliensOnScreen;   //max number of aliens appearing on screen at once
    public int totalAliens;     //total num of aliens player must kill to win
    public float minSpawnTime;  //min and max SpawnTimes control
    public float maxSpawnTime;  //rate at which aliens will appear
    public int aliensPerSpawn;

    private int aliensOnScreen = 0; //tracks total number of aliens on screen
    private float generatedSpawnTime = 0;   //will track time between spawns, will be randomized
    private float currentSpawnTime = 0;     //will track milliseconds since last spawn

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawnTime += Time.deltaTime;     //accumulates time passed each frame

        if (currentSpawnTime > generatedSpawnTime)
        {
            currentSpawnTime = 0;   //resets timer after a spawn occurs
            //spawn-time randomizer
            generatedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            //preventative code to make sure there are some aliens but not more than total
            if (aliensPerSpawn > 0 && aliensOnScreen < totalAliens)
            {
                //array keeps track of where we spawn aliens each wave
                List<int> previousSpawnLocations = new List<int>();
                //limits number of aliens to the number of spawn points
                if (aliensPerSpawn > spawnPoints.Length)
                {
                    aliensPerSpawn = spawnPoints.Length - 1;
                }
                //more preventative code.if aliensperspawn exceeds the max, then reduce
                //the number of spawns. This prevents spawning more than the max configured
                aliensPerSpawn = (aliensPerSpawn > totalAliens) ? aliensPerSpawn - totalAliens : aliensPerSpawn;

                //actual spawning code, loop iterates once for each spawned alien
                for (int i = 0; i < aliensPerSpawn; i++)
                {
                    if (aliensOnScreen < maxAliensOnScreen)
                    {
                        aliensOnScreen += 1;
                        // the random generated spawn point number
                        //-1 means it hasn't been assigned a spawn point yet
                        int spawnPoint = -1;
                        // loop until it finds a spawn point number that hasn't
                        //been used already
                        while (spawnPoint == -1)
                        {
                            // produces a random possible spawn point
                            int randomNumber = Random.Range(0, spawnPoints.Length - 1);
                            // if random number doesn't match a previous spawnpoint
                            // then that number is added to the SpanLocations array
                            // and used as the SpawnPoint for that alien
                            if (!previousSpawnLocations.Contains(randomNumber))
                            {
                                previousSpawnLocations.Add(randomNumber);
                                spawnPoint = randomNumber;
                            }
                        }
                        //grabs the spawn location using the spawnpoint generated
                        //in the while loop
                        GameObject spawnLocation = spawnPoints[spawnPoint];
                        //create an instance of the alien using the prefab
                        GameObject newAlien = Instantiate(alien) as GameObject;
                        //this positions the alien at the spawnpoint
                        newAlien.transform.position = spawnLocation.transform.position;
                    }
                }
            }
        }
    }
}
