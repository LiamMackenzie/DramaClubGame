using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
public float speed = 20f;
public int damage = 50;
public Rigidbody2D rb;
public GameObject shot;


	void Start () 
	{
		rb.velocity = transform.right * speed;
	}
	
	void OnTriggerEnter2D (Collider2D hitInfo)
		{
			Debug.Log(hitInfo.name); //gets info
			Enemy enemy = hitInfo.GetComponent<Enemy>();
			if (enemy != null)
				{
					enemy.DamageDealt(damage);
				}
			Destroy(gameObject);
			Instantiate(shot, transform.position, Quaternion.identity);
			
		}
		
	
}
