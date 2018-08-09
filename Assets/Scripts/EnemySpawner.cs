using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    [SerializeField] EnemyWave startingWave;  // change to an array of allWaves. 

    // CACHE - e.g. references for readability
    Transform spawnedEnemyParent;

    // STATE - private instance (member) variables
    EnemyWave currentWave;
    int spawnCounter;

    // CONSTANTS - compile

    // messages, then public methods, then private methods...
    void Start()
    {
        spawnedEnemyParent = FindObjectOfType<EnemySpawner>().transform;
        currentWave = startingWave;
        spawnCounter = currentWave.GetNumberOfEnemies();
        SpawnWaves();
    }

    private void SpawnWaves()
    {
        SpawnEnemy();
        spawnCounter--;
        if (spawnCounter < 1)
        {
            currentWave = currentWave.GetNextWave();
            spawnCounter = currentWave.GetNumberOfEnemies();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(
            currentWave.GetEnemyPrefab(),
            currentWave.GetStartingWayPoint().transform.position,
            Quaternion.identity,
            spawnedEnemyParent
        );
        
//        float randomFactor = currentWave.GetSpawnRandomFactor();
        Invoke("SpawnWaves", 0.5f);
        
//      Invoke("ManageWaves", currentWave.GetTimeBetweenSpawns() + Random.Range(-randomFactor, randomFactor));
    }

}
