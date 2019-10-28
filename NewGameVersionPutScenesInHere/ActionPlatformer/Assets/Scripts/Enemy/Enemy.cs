using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;
	public GameObject deathEffect;

	private Rigidbody2D rb;

	public float knockBack;
	public float knockBacklength;
	public float knockBackcount;
	private bool knockFromright;
	
		void Start ()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		public void DamageDealt (int damage)
		{
			health -= damage;
			if (health <= 0)
			{
				KillMe();
			}
		}

		public void TakeDamage(int damage)
		{
			health -= damage;
			if (health <= 0)
			{
				KillMe();
			}

			//=========================================================================
			//these just check if the player is getting hit from the Left or Right and moves them in the right way.
			//=========================================================================
			if(transform.position.x < transform.position.x)
			{
				rb.AddForce(new Vector2(knockBack, 0) * 2);
				knockFromright = true;
			}
			else
			{
				rb.AddForce(new Vector2(-knockBack, 0) * 2);
				knockFromright = false;
			}

		}

		void KillMe()
		{
			Instantiate(deathEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

}