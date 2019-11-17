using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRate = 1.0f;
    private float nextAttack;
    public Transform attackPosition;
    public float attackRange;

    [HideInInspector]
    public LayerMask enemyMask;
    public int damage;

    
    

    private Animator animator;

    void Awake()
    {
        enemyMask = LayerMask.GetMask("Enemy");
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        //Debug.Log(LayerMask.LayerToName(12));
        
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && Time.time > nextAttack) //nextAttack = Time.time + attackRate;
        {
            //GetComponent<AudioSource>().Play();
            animator.SetBool("isAttacking", true);
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemyMask);
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

