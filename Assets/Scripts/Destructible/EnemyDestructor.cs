using UnityEngine;

//a Destructor causes damage to a Destructible when they touch
public class EnemyDestructor : MonoBehaviour
{
	public float damageAmount = 1;
//	public AudioSource deathSound;

	public bool destroyOnCollision;




	//remember, Unity calls this whenever there is a collision
	public void OnCollisionEnter2D(Collision2D collision)
	{
		//this looks confusing. basically, this is how we can get the Destructible that we collided with
		Destructible hitDestructible = collision.collider.GetComponent<Destructible>();

		//it's possible that we don't have any Destructible at all, like if we hit something else
		if ( hitDestructible != null && collision.gameObject.layer == 11)
		{
			hitDestructible.TakeDamage( damageAmount );
//			deathSound.Play();

			if (destroyOnCollision) 
			{
				Object.Destroy (gameObject);
			}
		}
	}
}