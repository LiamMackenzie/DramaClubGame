using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float currentHealth;
	
	public GameObject deathEffect;

	public GrrBehaviour grrControl;

	private Rigidbody2D rb;
    public bool takeDmg = false;
	public float knockBack;
	public float knockBacklength;
	public float knockBackcount;
	private bool knockFromright;

	
    public float maxHealth;
    public Slider healthBar;
	public bool isDead = false;

    
	
	void Start ()
	{
	    rb = GetComponent<Rigidbody2D>();
		currentHealth = maxHealth;
        healthBar.value = CalculateHealth();
    }


    public void DamageDealt (int damage)
	{
	    currentHealth -= damage;
	    if (currentHealth <= 0)
	    {
		    
			KillMe();
	    }
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		//healthBar.value = CalculateHealth();
	}

	public void TakeDamage(int damage)
	{
		
		takeDmg = true;
		Debug.Log("enemy Got Hit");
		currentHealth -= damage;

		healthBar.value = CalculateHealth();

            
        if (currentHealth <= 0)
		{
			takeDmg = true;
			grrControl.Die();
			KillMe();
		}

			//=========================================================================
			//these just check if the player is getting hit from the Left or Right and moves them in the right way.
			//=========================================================================
		if(transform.position.x < transform.position.x)
		{
			rb.AddForce(new Vector2(knockBack, 0) * 2);
        }
		else
		{
			rb.AddForce(new Vector2(-knockBack, 0) * 2);             
        }
		Invoke("ResetHitAnim", 3);
        
    }

	float CalculateHealth()
    {
        return currentHealth / maxHealth;
		
    }

	public void KillMe()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

    public void ResetHitAnim()
    {
        takeDmg = false;
    }

}