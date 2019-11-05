using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRate = 1.0f;
    private float nextAttack;
    public Transform attackPosition;
    public float attackRange;

    public LayerMask whatIsEnemies;

    public int damage;
    

    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && Time.time > nextAttack) //nextAttack = Time.time + attackRate;
        {
                //GetComponent<AudioSource>().Play();
            animator.SetBool("isAttacking", true);
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
                nextAttack = Time.time + attackRate;
        }
        else
        {
            //timeBetweenAttack -= Time.deltaTime;
            animator.SetBool("isAttacking", false);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }

}

