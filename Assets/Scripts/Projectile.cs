using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	[SerializeField] float damage = 100f;
	
	public float GetDamage()
    {
		return damage;
	}
	
	public void Hit()
    {
		Destroy(gameObject);
	}
}