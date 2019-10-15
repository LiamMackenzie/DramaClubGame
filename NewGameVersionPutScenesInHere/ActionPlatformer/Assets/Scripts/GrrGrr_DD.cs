using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrrGrr_DD : MonoBehaviour
{

public float gr_MoveSpeed;
public float gr_AttackingDistance;

Rigidbody2D rigid2D;

[SerializeField]
GameObject gr_Projectile;

private Vector3 gr_ProjOffset;
[SerializeField]
private float jumpH;
[SerializeField]
private float jumpL;

public float jumpForwardsForce = 2f;

private float nextAttack;

[Header("Higher is Slower")]
public float attackRate = 1.0f;

//private Transform target;
public Transform target;
public Transform[] potentialTargets;
private int targetIndex = 0;
private Animator anim;
private SpriteRenderer gr_SpriteRenderer;
/* ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */
void Start() 
{
	rigid2D = GetComponent<Rigidbody2D>();
	target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	gr_SpriteRenderer = GetComponent<SpriteRenderer>();
	//gr_Projectile = GetComponent<GameObject>();
	gr_ProjOffset = new Vector3(2, 0, 0);

}

void Update() 
{
	TargetChange();
	MoveAndAttack();
}

void LateUpdate() 
{
	FaceDirection();
}


void OnTriggerEnter2D(Collider2D other)
{
	if(other.gameObject.name.Equals ("High"))
	{
		if(gr_SpriteRenderer.flipX == false)
		{
		rigid2D.velocity = new Vector2(-jumpForwardsForce, jumpH);
		}

		if(gr_SpriteRenderer.flipX == true)
		{
			rigid2D.velocity = new Vector2(jumpForwardsForce, jumpH);
		}
	}

	if(other.gameObject.name.Equals ("Low"))
	{
		if(gr_SpriteRenderer.flipX == false)
		{
			rigid2D.velocity = new Vector2(-jumpForwardsForce, jumpL);
		}

		if(gr_SpriteRenderer.flipX == true)
		{
			rigid2D.velocity = new Vector2(jumpForwardsForce, jumpL);
		}
		
	}
}

void FaceDirection() //Assuming player is on left of grrgrr at start
{
	if (transform.position.x - target.position.x < 0f)
	{
		gr_SpriteRenderer.flipX = true;
	}
	else
	{
		gr_SpriteRenderer.flipX = false;
	}
}

void MoveAndAttack()
{
	if(Vector2.Distance(transform.position, target.position) > gr_AttackingDistance)
	{
		transform.position = Vector2.MoveTowards(transform.position, target.position, gr_MoveSpeed * Time.deltaTime);
	}
	if(Vector2.Distance(transform.position, target.position) < gr_AttackingDistance)
	{
		if(Time.time > nextAttack)
        {
            
			if(gr_SpriteRenderer.flipX == false)
			{
			Instantiate (gr_Projectile, (transform.position - gr_ProjOffset), Quaternion.identity);
			nextAttack = Time.time + attackRate;
			}
			if(gr_SpriteRenderer.flipX == true)
			{
			Instantiate (gr_Projectile, (transform.position + gr_ProjOffset), Quaternion.identity);
			nextAttack = Time.time + attackRate;
			}

			//anim.SetBool("isAttacking", true);
			
			
		}
		//Debug.Log("Attacking");
	}
}

void TargetChange()
		{
			if(Input.GetKeyDown(KeyCode.Q))
			{
				ChangeTargets();
			}	
		}

void ChangeTargets()
{
	targetIndex += 1;
	if (targetIndex >= potentialTargets.Length)
	{
		targetIndex = 0;
	}
	
	target = potentialTargets[targetIndex];
}



}