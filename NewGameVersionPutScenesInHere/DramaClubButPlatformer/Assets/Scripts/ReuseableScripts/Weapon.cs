using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Transform shootPosition;
	public GameObject bulletPre;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.LeftControl))
			{
				Shoot();
			}
	}

	void Shoot()
		{
			Instantiate(bulletPre,
			 shootPosition.position, shootPosition.rotation);

		}
}


