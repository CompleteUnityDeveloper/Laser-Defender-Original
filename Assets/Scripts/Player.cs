using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // configuration parameters, consdier SO
    [Header("Projectile")]
	[SerializeField] GameObject laserPrefab;
	[SerializeField] float projectileSpeed = 10;
	[SerializeField] float projectileRepeatRate = 0.2f;
    [SerializeField] AudioClip fireSound;
	
    [Header("Player")]
	[SerializeField] float speed = 15.0f;
	[SerializeField] float padding = 1;
	[SerializeField] float health = 200;

    // cached references for readability

    // private instance variables for state
	float xmax = -5;
	float xmin = 5;
	
    // messages, then public methods, then private methods...
    void OnTriggerEnter2D(Collider2D other)
    {
		var projectile = other.gameObject.GetComponent<Projectile>();
		if(!projectile) { return; }  //project against null
        ProcessHit(projectile);
    }

    private void ProcessHit(Projectile projectile)
    {
        health -= projectile.GetDamage();
        projectile.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    void Start()
    {
        Camera mainCamera = Camera.main;
        float distance = transform.position.z - mainCamera.transform.position.z;
        xmin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + padding;
        xmax = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, distance)).x - padding;
    }

	void Update ()
    {
        Fire();
        Move();
    }

    private void Move()
    {
        float deltaX = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            deltaX = transform.position.x - speed * Time.deltaTime;
            MoveBy(deltaX);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            deltaX = transform.position.x + speed * Time.deltaTime;
            MoveBy(deltaX);
        }
    }

    private void MoveBy(float deltaX)
    {
        transform.position = new Vector3(
            Mathf.Clamp(deltaX, xmin, xmax),
            transform.position.y,
            transform.position.z
        );
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // TODO Ben consider using proper co-routines
            InvokeRepeating("FireSingleLaser", 0f, projectileRepeatRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("FireSingleLaser");
        }
    }

    private void FireSingleLaser()
    {
        GameObject laser = Instantiate(
            laserPrefab,
            transform.position,
            Quaternion.identity,
            Level.GetSpawnParent()
        ) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position); // note implicit instantiate
    }

    private void Die()
    {
        Level level = FindObjectOfType<Level>();
        level.LoadLevel("Win Screen");
        Destroy(gameObject);
    }
}
