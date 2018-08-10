using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	[SerializeField] int damage = 100;
    [SerializeField] GameObject laserHitVFX;


    public int GetDamage()
    {
		return damage;
	}
	
	public void Hit()
    {
        Destroy(gameObject);
        PlayHitEffect();
    }

    public void PlayHitEffect()
    {
        GameObject hitImpact = Instantiate(laserHitVFX, transform.position, transform.rotation);
        Destroy(hitImpact, 0.5f);
    }

}