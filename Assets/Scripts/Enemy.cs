using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    // configuration parameters, consider SO
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float health = 150f;
    [SerializeField] float shotsPerSecond = 0.5f;
    [SerializeField] int scoreValue = 150;
    [SerializeField] AudioClip fireSound;
    [SerializeField] AudioClip deathSound;
	
    // instance variables for state
    // todo consdier a level play time

    // cached references for readability
	ScoreKeeper scoreKeeper;
	
    // messages, then public methods, then private methods... 
    void Start()
    {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
        
	void Update()
    {
        float probabilityOfShotThisFrame = shotsPerSecond * Time.deltaTime;
		if(Random.value < probabilityOfShotThisFrame)
        {
			Fire ();
		}
	}
	
	void Fire()
    {
		GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
    void OnTriggerEnter2D(Collider2D other)
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
		scoreKeeper.Score(scoreValue);
		Destroy(gameObject);
	}
}
