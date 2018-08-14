using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    // configuration parameters, consider SO
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float health = 150f;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = .2f;
    [SerializeField] float maxTimeBetweenShots = 5f;
    [SerializeField] int scoreValue = 150;
    [SerializeField] AudioClip fireSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] GameObject deathVFX;


    // messages, then public methods, then private methods... 
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
		GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity,
            Level.GetSpawnParent()
        ) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
    private void OnTriggerEnter2D(Collider2D other)
    {
        Projectile missile = other.gameObject.GetComponent<Projectile>();
        if(missile)
        {
            missile.Hit();
            ProcessHit(missile.GetDamage());
        }
    }

    private void ProcessHit(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
        PlayDeathVFX(); 
        FindObjectOfType<Game>().Score(scoreValue);
		Destroy(gameObject);
	}

    private void PlayDeathVFX()
    {
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }
}
