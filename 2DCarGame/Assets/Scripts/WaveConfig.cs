using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveConfig : ScriptableObject
{
    // The enemy that will spawn in this wave
    [SerializeField] GameObject enemyPrefab;

    // The path that the wave will follow
    [SerializeField] GameObject pathPrefab;

    // Time between each enemy Spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    // Random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    // number of enemies in the Wave
    [SerializeField] int numberOfEnemies = 5;

    // The speed of the enemy
    [SerializeField] float enemyMoveSpeed = 2f;
    

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        // Each wave can have different waypoints
        var waveWaypoints = new List<Transform>();

        // Access pathPrefab and for each child, add it to the List waveWaypoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
