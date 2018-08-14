using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] waveWaypoints;
    [SerializeField] Transform startingWayPoint;  // dont need to have this here
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 10;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public Transform[] GetWayPoints()  { return waveWaypoints; } // TODO remove

    public Transform GetStartingWayPoint() { return startingWayPoint; }  // not needed

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetSpawnRandomFactor() { return spawnRandomFactor; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }
}
