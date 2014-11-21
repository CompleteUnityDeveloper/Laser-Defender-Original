using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10;
	public float height = 5;
	public float speed = 5.0f;
	public float padding = 1;
	
	private int direction = 1;
	private float boundaryRightEdge, boundaryLeftEdge;
	
	// Use this for initialization
	void Start () {
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		boundaryLeftEdge = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		boundaryRightEdge = camera.ViewportToWorldPoint(new Vector3(1,1,distance)).x - padding;
		
		foreach( Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	void OnDrawGizmos(){
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
	void Update () {
		float formationRightEdge = transform.position.x + 0.5f * width;
		float formationLeftEdge = transform.position.x - 0.5f * width;
		if (formationRightEdge > boundaryRightEdge){
			direction = -1;
		}
		if (formationLeftEdge < boundaryLeftEdge){
			direction = 1;
		}
		transform.position += new Vector3(direction * speed * Time.deltaTime,0,0);
	}
}
