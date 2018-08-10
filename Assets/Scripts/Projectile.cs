using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	[SerializeField] float damage = 100f;
    [SerializeField] GameObject laserHitVFX;


    public float GetDamage()
    {
		return damage;
	}
	
	public void Hit()
    {
        PlayHitEffect();
        Destroy(gameObject);
	}

    public void PlayHitEffect()
    {
        GameObject hitImpact = Instantiate(laserHitVFX, transform.position, transform.rotation);
        Destroy(hitImpact, 0.5f);
    }

}