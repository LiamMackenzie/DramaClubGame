using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int hp = 100;
	public GameObject deathEffect;
	
		void Start ()
		{
		
		}

		public void DamageDealt (int damage)
		{
			hp -= damage;
			if (hp <= 0)
			{
				KillMe();
			}
		}

		void KillMe()
		{
			Instantiate(deathEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

}