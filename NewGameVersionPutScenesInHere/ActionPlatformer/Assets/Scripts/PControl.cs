using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PControl : MonoBehaviour {
	public float speed;
	public float jumpHeight;
	private float movement;
	
	private bool faceright = true;
	private Rigidbody2D rb;
	
	private bool onground;
	public Transform floorCheck;
	public float checkRadius;
	public LayerMask whatGround;

	private int moreJump;
	public int moreJumpVal;

	//KnockBack
	public float knockBack;
	public float knockBacklength;
	public float knockBackcount;
	private bool  knockFromright;

	//Health
	public float maxHealth;
    public float currentHealth;
    public Slider healthBar;
	

	// Use this for initialization
	void Start () {
		moreJump = moreJumpVal;
		rb = GetComponent<Rigidbody2D>();

		currentHealth = maxHealth;
        healthBar.value = CalculateHealth();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		onground = Physics2D.OverlapCircle(floorCheck.position, checkRadius, whatGround);

		movement = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(movement * speed, rb.velocity.y);

		if(knockBackcount <= 0)
		{
			rb.velocity = new Vector2(movement * speed, rb.velocity.y);
		}
		else
		{
			if(knockFromright)
			{
				rb.velocity = new Vector2(-knockBack, knockBack);
			}
			if(!knockFromright)
			{
				rb.velocity = new Vector2(knockBack, knockBack);
				
			}
			knockBackcount -= Time.deltaTime;
		}
	
	}
	void Update()
	{
		if(faceright == true)
		{
			if (Input.GetKeyDown(KeyCode.A))
				{
					transform.Rotate(0f, 180f, 0f);
					faceright = false;
				}
		}
		else if(faceright == false)
			{
				if(Input.GetKeyDown(KeyCode.A))
					{
						transform.Rotate(0f, 0f, 0f);
					}
			}

		if(faceright == false)
		{
			if (Input.GetKeyDown(KeyCode.D))
				{
					transform.Rotate(0f, 180f, 0f);
					faceright = true;
				}
				
		}
		

		if(onground == true)
		{
			moreJump = moreJumpVal;
		}

		if(Input.GetKeyDown(KeyCode.Space) && moreJump > 0)
		{
			rb.velocity = Vector2.up * jumpHeight;
			moreJump--;
		}
		else if(Input.GetKeyDown(KeyCode.Space) && moreJump == 0 && onground == true)
		{
			rb.velocity = Vector2.up * jumpHeight;
		}
		
	
		
	}

	float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

	void OnCollisionEnter2D(Collision2D col)
    {

		//checks if the collision is an enemy
		//checks if the player is getting hit from the left or right
        if(col.gameObject.tag == "Enemy")
        {

			currentHealth -= col.gameObject.GetComponent<EnemyDamge>().enemyDamgeVaule;
			healthBar.value = CalculateHealth();

			//these just check if the player is getting hit from the Left or Right and moves them in the right way.
			if(col.transform.position.x < transform.position.x)
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
    }
	

	
	
}
