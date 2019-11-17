using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrrBehaviour : MonoBehaviour
{
    /**************************************************************
    - Move towards the player : anim walk
    - Attack when at a certain distance : anim stop walk, attack
    - Jump when collide with a jump trigger : anim jump
    - Take Damage when collide with player weapon : anim get hit
    - Lose health
    - Die when health == 0 : anim play dying
    - Take no damage from sword until damaged by spell
    - then take no damage from spell for 3 seconds
    - Drop gum leaves on death
    ******************************************************************/


    Rigidbody2D rb2D;
    [SerializeField]
    PControl target;
    Animator anim;
    SpriteRenderer r;
    public Transform feet;
    Vector2 dir;
    Enemy myEnemyScript;
    Animator animator;
    bool isHit;
    [SerializeField]
    GameObject projectile;

    public float speed = 500f;
    public float attackRange = 25f;
    private Vector3 projOffset;
    [Header("Higher is Slower")]
    public float attackRate = 1.0f;
    private float nextAttack = 0;
 
    void Start()
    {
        //currentHealth = myEnemyScript.health;
        //healthBar.value = CalculateHealth();
        
        rb2D = GetComponent<Rigidbody2D>();
        r = GetComponent<SpriteRenderer>();
        projOffset = new Vector3(0.5f, 0, 0);
        myEnemyScript = GetComponent<Enemy>(); 
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        target = GameObject.FindObjectOfType<PControl>();
        if(isHit == true)
        {
            animator.SetBool("Hit", true);
        }
        else
        {
            animator.SetBool("Hit", false);
        }
    }

    void LateUpdate()
    {
        
        
        FaceDirection(transform.position.x, target.transform.position.x);
        //Move();

    }
    
    private void FixedUpdate() 
    {
        MoveAndAttack();
        //CheckIfHit();
    }

    void MoveAndAttack()
    {
        if(myEnemyScript.takeDmg == false)
        {
            isHit = false;
            if (Vector2.Distance(transform.position, target.transform.position) < attackRange)
            {
                if (Time.time > nextAttack)
                {
                    animator.SetBool("Attack", true);
                    animator.SetBool("Walk", false);
                    if (r.flipX == false)
                    {
                        Instantiate(projectile, (transform.position - projOffset), Quaternion.identity);
                        nextAttack = Time.time + attackRate;       
                    }
                    if (r.flipX == true)
                    {
                        Instantiate(projectile, (transform.position + projOffset), Quaternion.identity);
                        nextAttack = Time.time + attackRate;    
                    }
                }
                else
                {
                    animator.SetBool("Attack", false);
                }
            }
                else if(target.transform.position.y > (feet.position.y + 1f)) //If the target player is above my head
                {
                    animator.SetBool("Walk", true);
                    rb2D.velocity = dir * speed * Time.fixedDeltaTime; //Move right or left with no y-axis movement depending on it the player is on my left or right
                }
            else
            {
                
                speed = 500f;
                Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.fixedDeltaTime);
                animator.SetBool("Walk", true);
                // Vector.MoveTowards(my position, targets pos, speed * Time.fixedDeltaTime);
            }
        }
        else
        {
            
            isHit = true;
        }
         // if ( target.position.x-your.position.x)
    }

    public Vector2 FaceDirection(float myPos,float xPos) //Assuming player is on left of grrgrr at start
    {
        
        if (myPos - xPos < 0f)
        {
            dir = Vector2.right;
            r.flipX = true;
        }
        else
        {
            dir = Vector2.left;
            r.flipX = false;
        }
        return(dir);
    }

    public void Die()
    {
        animator.SetBool("Die", true);
        speed = 0;
        isHit = true;
        Invoke("KillMe", 2.5f);
    }

    void KillMe()
    {
        myEnemyScript.KillMe();
    }



}
