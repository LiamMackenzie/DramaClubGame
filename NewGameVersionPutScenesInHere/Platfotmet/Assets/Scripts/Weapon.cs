using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Transform shootPosition;
	public GameObject bulletPre;
	public float cooldown;
	public float cooldownReset;
	
	// Update is called once per frame
	void Update () 
	{
		cooldown -= Time.deltaTime;
		if(cooldown <= 0)
		{
		if (Input.GetKeyDown(KeyCode.J))
			{
				Shoot();
			}
		}
	}

	void Shoot()
		{
			Instantiate(bulletPre,
			 shootPosition.position, shootPosition.rotation);
			 cooldown = cooldownReset;

		}
}


