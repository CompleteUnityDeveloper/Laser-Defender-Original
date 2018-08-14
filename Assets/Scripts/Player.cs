using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
    // configuration parameters, consdier SO
    [Header("Projectile")]
	[SerializeField] GameObject laserPrefab;
	[SerializeField] float projectileSpeed = 10;
	[SerializeField] float projectileFiringPeriod = 0.2f;
    [SerializeField] AudioClip fireSound;
	
    [Header("Player")]
	[SerializeField] float speed = 15.0f;
	[SerializeField] float padding = 1;
	[SerializeField] int health = 200;

    // cached references for readability

    // private instance variables for state
	float xmax = -5;
	float xmin = 5;
    Coroutine firingHandle;
	
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

    public int GetCurrentHealth()
    {
        return health;
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
        var deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var proposedXpos = transform.position.x + deltaX;
        transform.position = new Vector3(
            Mathf.Clamp(proposedXpos, xmin, xmax),
            transform.position.y,
            transform.position.z
        );
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))  // Only start coroutine once
        {
            firingHandle = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingHandle);
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)  // forever so we must stop the co-routine
        {
            GameObject laser = Instantiate(
                laserPrefab,
                transform.position,
                Quaternion.identity,
                Level.GetSpawnParent()
            ) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
            AudioSource.PlayClipAtPoint(fireSound, transform.position); // implicit instantiate, not easy to parent
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void Die()
    {
        Level level = FindObjectOfType<Level>();
        level.LoadNextScene();
        Destroy(gameObject);
    }
}
