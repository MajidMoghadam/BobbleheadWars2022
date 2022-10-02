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
        
    }
}
