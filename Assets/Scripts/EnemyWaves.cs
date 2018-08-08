using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWave")]
public class EnemyWaves : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] waveWaypoints;
    [SerializeField] Transform startingWayPoint;  // dont need to have this here
    [SerializeField] float enemySpeed = 4f;  // TODO consider moving here, this is currently not used
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 10;
    [SerializeField] EnemyWaves nextWave;  // move up to higher level

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public Transform[] GetWayPoints()  { return waveWaypoints; }

    public Transform GetStartingWayPoint() { return startingWayPoint; }  // not needed

    public float GetEnemySpeed() { return enemySpeed; }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetSpawnRandomFactor() { return spawnRandomFactor; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public EnemyWaves GetNextWave() { return nextWave; }  // not needed
}
