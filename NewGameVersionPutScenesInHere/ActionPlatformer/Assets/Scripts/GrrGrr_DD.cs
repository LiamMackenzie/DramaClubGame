using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrrGrr_DD : MonoBehaviour
{

public float gr_MoveSpeed;
public float gr_AttackingDistance;

private float nextAttack;
public float attackRate = 1.0f;

private Transform gr_Target;
private Animator anim;
private SpriteRenderer gr_SpriteRenderer;
/* ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */
void Start() 
{
	gr_Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	gr_SpriteRenderer = GetComponent<SpriteRenderer>();
	gr_MoveSpeed = 3f;
	gr_AttackingDistance = 10f;

}

void Update() 
{
	MoveAndAttack();
}

void LateUpdate() 
{
	FaceDirection();
}

void FaceDirection() //Assuming player is on left of grrgrr at start
{
	if (transform.position.x - gr_Target.position.x < 0f)
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
	if(Vector2.Distance(transform.position, gr_Target.position) > gr_AttackingDistance)
	{
		transform.position = Vector2.MoveTowards(transform.position, gr_Target.position, gr_MoveSpeed * Time.deltaTime);
	}
	if(Vector2.Distance(transform.position, gr_Target.position) < gr_AttackingDistance)
	{
		if(Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;

			anim.SetBool("isAttacking", true);
			
			//Instantiate(gr_Projectile
		}
		//Debug.Log("Attacking");
	}
}

}
