using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    int waypointIndex = 0;
    WaveConfig waveConfig;
    List<Transform> wayPoints;

	// Use this for initialization
	void Start ()
    {
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
	}

    // mention we could use a "constructor" but now for now
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointIndex <= wayPoints.Count - 1)  // Need to actually count at run-time (not just get length)
        {
            var targetPosition = wayPoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == wayPoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
