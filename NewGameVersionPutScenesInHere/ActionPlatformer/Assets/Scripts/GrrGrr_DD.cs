using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrrGrr_DD : MonoBehaviour
{
float dirX;

	[SerializeField]
	float moveSpeed = 3f;

    [SerializeField]
	float smallJumpForce = 300f;

    [SerializeField]
	float bigJumpForce = 500f;

	Rigidbody2D rb;

	bool facingRight = false;

	//Vector3 localScale;
	private float movement;

    //public Transform target;
	public GameObject target;
	//private int targetIndex = 0;
	private Vector2 targetPos;


    //public float stoppingDistance = 10f;

	// Use this for initialization
	void Start () {
		//localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D> ();
		//dirX = -1f;

        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
        //targetChange();
	}

	void FixedUpdate()
	{
        //rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);
		targetPos = new Vector2(target.transform.position.x,
         transform.position.y);
		 CheckWhereToFace(movement);

        transform.position = Vector2.MoveTowards(transform.position, 
        targetPos, moveSpeed * Time.deltaTime);

	}

	void LateUpdate()
	{
		//CheckWhereToFace ();
	}

	void CheckWhereToFace(float movement)
	{
		//if (dirX > 0)
			//facingRight = true;
		//else if (dirX < 0)
			//facingRight = false;
			

	//	if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			//localScale.x *= -1;

		//transform.localScale = localScale;

		if(movement > 0 && !facingRight || movement < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector2 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		switch (col.tag) {

		case "GrrJump":
			rb.AddForce (Vector2.up * smallJumpForce);
			break;

        case "GrrJumpBig":
			rb.AddForce (Vector2.up * bigJumpForce);
			break;

		case "WallLeft":
			dirX = 1f;
			break;

		case "WallRight":
			dirX = -1f;
			break;
		}	
	}
		//void ChangeTargets()
	//	{
		//	targetIndex += 1;
		//	if (targetIndex >= potentialTargets.Length)
		//	{
		//		targetIndex = 0;
		//	}
		//	target = potentialTargets[targetIndex];
	//	}
//
	//	   	void targetChange()
	//	{
		//	if(Input.GetKeyDown(KeyCode.Q))
	//	{
	//			ChangeTargets();
	//		}	
	//	}

}
