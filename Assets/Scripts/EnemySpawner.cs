using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemyWave> enemyWaves;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    void Start()
    {
        do
        {
            StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < enemyWaves.Count; waveIndex++)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(enemyWaves[waveIndex]));
            // "yield return" so we wait before moving on. Series co-routine
        }
    }

    IEnumerator SpawnAllEnemiesInWave(EnemyWave wave)
    {
        for (int enemyCount = 0; enemyCount < wave.GetNumberOfEnemies(); enemyCount++)
        {
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