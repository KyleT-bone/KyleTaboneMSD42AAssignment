using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // A list of waveConfigs
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool looping = false;

    // We always start from Wave 0
    int startingWave = 0;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            // Start coroutine that spawns all waves
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); // while (looping == true)
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When calling coroutine, specify which Wave we need to spawn enemies from 
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveToSpawn)
    {
        // Loop to spawn all enemies in wave
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberOfEnemies(); enemyCount++)
        {
            // Spawn the enemy from waveConfig at the position specified by waveConfig waypoints
            var newEnemy = Instantiate(waveToSpawn.GetEnemyPrefab(),
                        waveToSpawn.GetWaypoints()[startingWave].transform.position,
                        Quaternion.identity);

            // The wave will be selected from here and the enemy will be applied to it
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveToSpawn);

            // Wait timeBetweenSpawns before spawning another enemy
            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
        
    }

    private IEnumerator SpawnAllWaves()
    {
        // Loop all waves
        foreach (WaveConfig currentWave in waveConfigList)
        {
            // Wait for all enemies to spawn before going into the next wave 
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
