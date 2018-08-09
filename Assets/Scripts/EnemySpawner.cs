using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemyWave> enemyWaves; // start with EnemyWave[] 
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    void Start()
    {
        do
        {
            StartCoroutine(SpawnAllWaves());
            print("Spawing all waves");
        }
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        // start enemyWaves.Length, then change to list with enemyWaves.Count
        for (int waveIndex = startingWave; waveIndex < enemyWaves.Count; waveIndex++)
        {
            print("Spawing wave " + waveIndex);
            var currentWave = enemyWaves[waveIndex]; // note this isn't null-safe
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            // Series co-routine: "yield return" so we wait before moving on.
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(EnemyWave wave)
    {
        for (int enemyCount = 0; enemyCount < wave.GetNumberOfEnemies(); enemyCount++)
        {
            print("Spawning enemy in wave");
           Instantiate(
                wave.GetEnemyPrefab(),
                wave.GetStartingWayPoint().transform.position,
                Quaternion.identity,
                Level.GetSpawnParent()
            );
            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }
    }
}