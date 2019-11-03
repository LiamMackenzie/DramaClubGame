using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PControl : MonoBehaviour {

	Animator animator;

	//========
	//Movement
	//========
	public float speed;
	public float jumpHeight;
	private float movement;
	
	private bool faceRight;
	private Rigidbody2D rb;
	
	private bool onground;
	public Transform floorCheck;
	public float checkRadius;
	public LayerMask whatGround;

	private int moreJump;
	public int moreJumpVal;
	private bool isJumping = false;

	//=========
	//KnockBack
	//=========
	public float knockBack;
	public float knockBacklength;
	public float knockBackcount;
	private bool  knockFromright;

	//======
	//Health
	//======
	public float maxHealth;
    public float currentHealth;
    public Slider healthBar;
	public bool isDead = false;


	

	
	void Start() {
		moreJump = moreJumpVal;
		rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
		faceRight = true;

		currentHealth = maxHealth;
        healthBar.value = CalculateHealth();

		
	}
	
	
	void FixedUpdate () {
		onground = Physics2D.OverlapCircle(floorCheck.position, checkRadius, whatGround);

		float movement = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(movement * speed, rb.velocity.y);

		Flip(movement);

		animator.SetFloat("Speed", Mathf.Abs(movement));

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
		//====================
			jump();
		//====================

		
	}
	void Update()
	{
		if(isJumping == true)
		{
			animator.SetBool("Jumping", true);
		}
		if(isJumping == false)
		{
			animator.SetBool("Jumping", false);
		}
	}

	float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

	//=========================================================================
	//Checks which way the player is facing and flips them.
	// if the players Is facing right there x Scale will be postive if you turn the character the function will times the character x scale by -1 thus flipping
	// if the player isn't facing right the fuction will times the x scale by -1 which will equal a positve thus flipping.
	//=========================================================================

	private void Flip(float movement)
	{
		if(movement > 0 && !faceRight || movement < 0 && faceRight)
		{
			faceRight = !faceRight;

			Vector2 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;
		}
	}

	//=========================================================================
	// Jumping stuff
	//=========================================================================

	public void jump()
	{
		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false)
		{
			rb.AddForce((Vector2.up * jumpHeight) * 100);
			isJumping = true;
		}
	}



	void OnCollisionEnter2D(Collision2D col)
    {
		//=========================================================================
		//checks if the collision is an enemy
		//checks if the player is getting hit from the left or right
		//=========================================================================
        if(col.gameObject.tag == "Enemy")
        {

			currentHealth -= col.gameObject.GetComponent<EnemyDamge>().enemyDamgeVaule;
			healthBar.value = CalculateHealth();

			//=========================================================================
			//these just check if the player is getting hit from the Left or Right and moves them in the right way.
			//=========================================================================
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
		if(col.gameObject.tag == "Ground")
		{
			isJumping = false;
		}

    }
	

	
	
}
