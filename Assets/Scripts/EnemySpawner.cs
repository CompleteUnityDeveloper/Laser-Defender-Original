using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs; // start with EnemyWave[] 
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    IEnumerator Start()
    {
        do // for when we do things at least once
        {
            print("Spawning all waves...");
            yield return StartCoroutine(SpawnAllWaves()); // series co-routine
            print("Finshed spawing waves");
        }
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        // start with enemyWaves.Length, then change to list with enemyWaves.Count
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            print("> Spawing wave " + waveIndex);
            var waveConfig = waveConfigs[waveIndex]; // note this isn't null-safe
            yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfig));
            // Series co-routine: "yield return" so we wait before moving on.
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            print(">> Spawning enemy in wave");
            SpawnEnemy(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns()); // comes-back to for loop
        }
    }

    private static void SpawnEnemy(WaveConfig waveConfig)
    {
        var newEnemy = Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetWayPoints()[0].transform.position, // starting waypoint
            Quaternion.identity,
            Level.GetSpawnParent()
        );
        newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
    }
}

// NOTE remove print statements at the end