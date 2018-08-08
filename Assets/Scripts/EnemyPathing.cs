using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float spawnDelaySeconds = 1f;
    [SerializeField] GameObject enemyPatherPrefab;

    int waypointIndex = 0;

	// Use this for initialization
	void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
  //      SpawnUntilFull();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //void SpawnUntilFull()
    //{
    //    Transform freePos = NextFreePosition();
    //    GameObject enemy = Instantiate(enemyPatherPrefab, freePos.position, Quaternion.identity) as GameObject;
    //    enemy.transform.parent = freePos;
    //    if (FreePositionExists())
    //    {
    //        Invoke("SpawnUntilFull", spawnDelaySeconds);
    //    }
    //}

    //bool FreePositionExists()
    //{
    //    foreach (Transform position in transform)
    //    {
    //        if (position.childCount <= 0)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //Transform NextFreePosition()
    //{
    //    foreach (Transform position in transform)
    //    {
    //        if (position.childCount <= 0)
    //        {
    //            return position;
    //        }
    //    }
    //    return null;
    //}

    //bool AllMembersAreDead()
    //{
    //    foreach (Transform position in transform)
    //    {
    //        if (position.childCount > 0)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}


}
