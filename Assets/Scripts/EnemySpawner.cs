using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] EnemyWaves startingWave;  // change to an array of allWaves. 

    EnemyWaves currentWave;
    int spawnCounter;

    // Use this for initialization
    void Start() {
        currentWave = startingWave;
        spawnCounter = currentWave.GetNumberOfEnemies();
        print(spawnCounter);
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
            print(currentWave.name);
        }
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate
            (currentWave.GetEnemyPrefab(),
            currentWave.GetStartingWayPoint().transform.position, 
            Quaternion.identity) as GameObject;

        print(spawnCounter);

//        float randomFactor = currentWave.GetSpawnRandomFactor();
        Invoke("SpawnWaves", 0.5f);
        
//      Invoke("ManageWaves", currentWave.GetTimeBetweenSpawns() + Random.Range(-randomFactor, randomFactor));
    }

}
