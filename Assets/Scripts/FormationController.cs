using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour
{
    // configuration parameters, consdier SO
	[SerializeField] GameObject enemyPrefab;
	[SerializeField] float width = 10;
	[SerializeField] float height = 5;
	[SerializeField] float speed = 5.0f;
	[SerializeField] float padding = 1;
	[SerializeField] float spawnDelaySeconds = 1f;

    // private instance variables for state
	float boundaryRightEdge, boundaryLeftEdge;
    float panDirection = 1; // start panning right

    // messages, then public methods, then private methods...
	void Start ()
    {
		SpawnUntilFull();
	}
	
	void OnDrawGizmos()
    {
		float xmin,xmax,ymin,ymax;
		xmin = transform.position.x - 0.5f * width;
		xmax = transform.position.x + 0.5f * width;
		ymin = transform.position.y - 0.5f * height;
		ymax = transform.position.y + 0.5f * height;
		Gizmos.DrawLine(new Vector3(xmin,ymin,0), new Vector3(xmin,ymax));
		Gizmos.DrawLine(new Vector3(xmin,ymax,0), new Vector3(xmax,ymax));
		Gizmos.DrawLine(new Vector3(xmax,ymax,0), new Vector3(xmax,ymin));
		Gizmos.DrawLine(new Vector3(xmax,ymin,0), new Vector3(xmin,ymin));
	}
	
	// Update is called once per frame
	void Update ()
    {
        CalculateBoundaryEdges();
        PanFormationLeftAndRight();
        if (AllMembersAreDead()) { SpawnUntilFull(); }
    }

    private void CalculateBoundaryEdges()
    {
        Camera mainCamera = Camera.main;
        float distance = transform.position.z - mainCamera.transform.position.z;
        boundaryLeftEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + padding;
        boundaryRightEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, distance)).x - padding;
    }

    private void PanFormationLeftAndRight()
    {
        float formationRightEdge = transform.position.x + 0.5f * width;
        float formationLeftEdge = transform.position.x - 0.5f * width;

        if (formationRightEdge > boundaryRightEdge)
        {
            panDirection = -1;
        }
        if (formationLeftEdge < boundaryLeftEdge)
        {
            panDirection = 1;
        }

        transform.position += new Vector3(panDirection * speed * Time.deltaTime, 0, 0);
    }

    void SpawnUntilFull()
    {
		Transform freePos = NextFreePosition();
		GameObject enemy = Instantiate(enemyPrefab, freePos.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = freePos;
		if(FreePositionExists())
        {
			Invoke("SpawnUntilFull", spawnDelaySeconds);
		}
	}
	
	bool FreePositionExists(){
		foreach(Transform position in transform)
        {
			if(position.childCount <= 0)
            {
				return true;
			}
		}
		return false;
	}
	
	Transform NextFreePosition()
    {
		foreach(Transform position in transform)
        {
			if(position.childCount <= 0)
            {
				return position;
			}
		}
        print("stuff here");
		return null;
	}

	bool AllMembersAreDead()
    {
		foreach(Transform position in transform)
        {
			if(position.childCount > 0)
            {
				return false;
			}
		}
		return true;
	}
}
