using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float health = 150;

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Destroy(gameObject);
			}
		}
	}
}
