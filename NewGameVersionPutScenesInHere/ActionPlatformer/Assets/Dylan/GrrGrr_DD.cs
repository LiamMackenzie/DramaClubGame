using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrrGrr_DD : MonoBehaviour
{
    Enemy myEnemyScript;
    public float gr_MoveSpeed;
    public float gr_AttackingDistance;
    bool isGrounded = false;

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

    //private Animator anim;

    [Header("Higher is Slower")]
    public float attackRate = 1.0f;
    private Vector2 moveDirection;

    ////////////////
    //HealthBar
    /////////////////
    public Slider healthBar;
    public float maxHealth;
    public float currentHealth;
    
    //private Transform target;
    //[SerializeField]
    //public Transform[] target;
    //public Transform[] potentialTargets;
    //private int targetIndex = 0;
    Animator anim;
    private SpriteRenderer gr_SpriteRenderer;

    private PControl pctarget;
    /* ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */
    void Start()
    {
        myEnemyScript = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gr_SpriteRenderer = GetComponent<SpriteRenderer>();
        gr_ProjOffset = new Vector3(0.5f, 0, 0);
        anim.SetBool("isHit", false);

        currentHealth = myEnemyScript.health;
        healthBar.value = CalculateHealth();
        

    }

    void Update()
    {
        //TargetChange();
        //if(isGrounded)
        pctarget = GameObject.FindObjectOfType<PControl>();
        moveDirection = (pctarget.transform.position - transform.position).normalized * gr_MoveSpeed;
        MoveAndAttack();

        if(myEnemyScript.takedmgWasCalled == true)
        {
            CalculateHealth();
            Debug.Log("I got hit");
            anim.SetBool("isHit", true);
            //anim.SetBool("isWalking", false);
        }
    }

    void LateUpdate()
    {
        FaceDirection();
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isWalking", true);
            isGrounded = true;


            Debug.Log("Ground");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        

        if (other.tag == "High")
        {
            isGrounded = false;
            if (gr_SpriteRenderer.flipX == false)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", false);
                rigid2D.velocity = new Vector2(-jumpForwardsForce, jumpH);
                isGrounded = false;



            }

            if (gr_SpriteRenderer.flipX == true)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", false);
                rigid2D.velocity = new Vector2(jumpForwardsForce, jumpH);
                //isGrounded = false;



            }
        }

        if (other.tag == "Low")
        {
            isGrounded = false;
            if (gr_SpriteRenderer.flipX == false)
            {
                rigid2D.velocity = new Vector2(-jumpForwardsForce, jumpL);
                anim.SetBool("isJumping", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);


            }

            if (gr_SpriteRenderer.flipX == true)
            {
                rigid2D.velocity = new Vector2(jumpForwardsForce, jumpL);
                anim.SetBool("isjJumping", true);
                anim.SetBool("isWalking", false);
                
                //isGrounded = false;

            }

        }

        

        if (other.tag == "Bounce")
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", true);
            isGrounded = false;
        }
    }

    void FaceDirection() //Assuming player is on left of grrgrr at start
    {
        if (transform.position.x - pctarget.transform.position.x < 0f)
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
        if (Vector2.Distance(transform.position, pctarget.transform.position) > gr_AttackingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, pctarget.transform.position, gr_MoveSpeed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, pctarget.transform.position) < gr_AttackingDistance)
        {
            if (Time.time > nextAttack)
            {
                

                if (gr_SpriteRenderer.flipX == false)
                {

                    Instantiate(gr_Projectile, (transform.position - gr_ProjOffset), Quaternion.identity);
                    nextAttack = Time.time + attackRate;
                    anim.SetBool("isAttacking", true);
                    anim.SetBool("isWalking", false);

                }
                if (gr_SpriteRenderer.flipX == true)
                {

                    Instantiate(gr_Projectile, (transform.position + gr_ProjOffset), Quaternion.identity);
                    nextAttack = Time.time + attackRate;
                    anim.SetBool("isAttacking", true);
                    anim.SetBool("isWalking", false);

                }
                



            }
            
            //Debug.Log("Attacking");

        }
    }
    float CalculateHealth()
    {
        return currentHealth / myEnemyScript.health;
    }

}