using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnDelaySeconds = .5f;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Transform startingWaypoint;

    // Use this for initialization
    void Start () {
        SpawnEnemy();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, startingWaypoint.transform.position, Quaternion.identity) as GameObject;
        Invoke("SpawnEnemy", spawnDelaySeconds);
    }

}
