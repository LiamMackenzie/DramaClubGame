using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attackPossition;
    public float attackRange;

    public LayerMask whatIsEnemies;

    public int damage;

    public Animator animator;
 

   private bool isAttacking;

    void Update()
    {
        if(timeBetweenAttack <= 0)
        {
            //then you can attack
            if(Input.GetKey(KeyCode.K))
            {
                animator.SetBool("isAttacking", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPossition.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                timeBetweenAttack = startTimeBetweenAttack;
            }
            
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
         animator.SetBool("isAttacking", false);

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPossition.position, attackRange);
    }

}

