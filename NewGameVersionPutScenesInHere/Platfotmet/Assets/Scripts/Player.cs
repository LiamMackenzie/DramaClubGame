using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed;
	public float jumpHeight;
	private float movement;
	
	private bool faceright = true;
	private Rigidbody2D rb2d;
	
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
	public bool  knockFromright;



	// Use this for initialization
	void Start () {
		moreJump = moreJumpVal;
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		onground = Physics2D.OverlapCircle(floorCheck.position, checkRadius, whatGround);

		movement = Input.GetAxisRaw("Horizontal");
		if(knockBackcount <= 0)
		{
			rb2d.velocity = new Vector2(movement * speed, rb2d.velocity.y);
		}
		else
		{
			if(knockFromright)
			{
				rb2d.velocity = new Vector2 (-knockBack, knockBack);
			}
			if(!knockFromright)
			{
				rb2d.velocity = new Vector2 (knockBack, knockBack);
				knockBackcount -= Time.deltaTime;
			}
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
			rb2d.velocity = Vector2.up * jumpHeight;
			moreJump--;
		}
		else if(Input.GetKeyDown(KeyCode.Space) && moreJump == 0 && onground == true)
		{
			rb2d.velocity = Vector2.up * jumpHeight;
		}
		
	
		
	}
	

	
	
}
