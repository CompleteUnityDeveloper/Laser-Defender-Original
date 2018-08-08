using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWave")]
public class EnemyWaves : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] waveWaypoints;
    [SerializeField] float enemySpeed;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] int numberOfEnemies;

}
