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

	Vector3 localScale;

    //public Transform target;


    //public float stoppingDistance = 10f;

	// Use this for initialization
	void Start () {
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D> ();
		dirX = -1f;

        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

	void FixedUpdate()
	{
        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);

	}

	void LateUpdate()
	{
		CheckWhereToFace ();
	}

	void CheckWhereToFace()
	{
		if (dirX > 0)
			facingRight = true;
		else if (dirX < 0)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;
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


}
