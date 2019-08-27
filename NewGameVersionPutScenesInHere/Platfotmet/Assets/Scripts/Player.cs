using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
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

	// Use this for initialization
	void Start () {
		moreJump = moreJumpVal;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		onground = Physics2D.OverlapCircle(floorCheck.position, checkRadius, whatGround);

		movement = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(movement * speed, rb.velocity.y);
	
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
	

	
	
}
