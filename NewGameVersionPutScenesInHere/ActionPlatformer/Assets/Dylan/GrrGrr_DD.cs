using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrrGrr_DD : MonoBehaviour
{  
    public float gr_MoveSpeed;
    public float gr_AttackingDistance;

    [HideInInspector]
    public LayerMask groundMask;
    private Rigidbody2D rigid2D;

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
    public float gr_AttackRate = 1.0f;

    public Slider healthBar;
    public float maxHealth;
    public float currentHealth;

    public bool onGround = false;
   
    Animator anim;
    private SpriteRenderer gr_SpriteRenderer;
    private PControl pctarget;
    private Enemy myEnemyScript;

    //private Vector3 dir;
    //private Vector3 gDist;
    //private float dDist;
    //private bool isFalling;
    //public float downForce = 1f;
    //public float mass = 1f;
    //public Transform rayShooter;

    /* ===================================================================================================================================================================== */

    void Awake()
    {
        groundMask = LayerMask.GetMask("Ground");
    }

    void Start()
    {
        myEnemyScript = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        gr_SpriteRenderer = GetComponent<SpriteRenderer>();
        gr_ProjOffset = new Vector3(0.5f, 0, 0);
        anim.SetBool("isHit", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isJumping", false);
        anim.SetBool("isDying", false);
        anim.SetBool("isGrounded", false);
        currentHealth = myEnemyScript.health;
        healthBar.value = CalculateHealth();
        //rigid2D.mass = mass;
    }

    void Update()
    {
        pctarget = GameObject.FindObjectOfType<PControl>();
        //CheckIfFalling();
        //if (isFalling == true)
        //{
            //Debug.Log("adding down force");

            //rigid2D.velocity = Vector2.down;
        //}




    }

    void FixedUpdate()
    {

        //Debug.DrawRay(rayShooter.transform.position, Vector3.down, Color.green);
        //RaycastHit2D hit = Physics2D.Raycast(rayShooter.transform.position, -Vector2.up, 1000, groundMask);
        //dir = (pctarget.transform.position - rigid2D.transform.position).normalized;
        //gDist = (hit.point - new Vector2(rigid2D.transform.position.x, rigid2D.transform.position.y));
        //dDist = Mathf.Abs(gDist.y);
        //Debug.Log(dDist);

        //if (isFalling == false) 
        //{
            MoveAndAttack();
        //}
        
        CheckIfHit();
        
    }

    void LateUpdate()
    {
        FaceDirection();
        
        
            


        //else
        //{
        //rigid2D.AddForce(transform.up * downForce);
        //}


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        {
            //isFalling = false;
            anim.SetBool("isGrounded", true);
            anim.SetBool("isJumping", false);

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("isGrounded", false);

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "High")
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isGrounded", false);
            if (gr_SpriteRenderer.flipX == false)
            { 
                rigid2D.velocity = new Vector2(-jumpForwardsForce, jumpH);
            }
            if (gr_SpriteRenderer.flipX == true)
            { 
                rigid2D.velocity = new Vector2(jumpForwardsForce, jumpH);
            }
        }
        if (other.tag == "Low")
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isGrounded", false);
            if (gr_SpriteRenderer.flipX == false)
            {
                rigid2D.velocity = new Vector2(-jumpForwardsForce, jumpL);
                
            }

            if (gr_SpriteRenderer.flipX == true)
            {
                rigid2D.velocity = new Vector2(jumpForwardsForce, jumpL);
            }

        }
        if (other.tag == "Bounce")
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isGrounded", false);
            Debug.Log("mushroom");
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
            //rigid2D.MovePosition(rigid2D.transform.position + dir * gr_MoveSpeed * Time.fixedDeltaTime);
            transform.position = Vector2.MoveTowards(transform.position, pctarget.transform.position, gr_MoveSpeed * Time.deltaTime); //need to change to rigid body movement
        }
        if (Vector2.Distance(transform.position, pctarget.transform.position) < gr_AttackingDistance)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);

            if (Time.time > nextAttack)
            {
                if (gr_SpriteRenderer.flipX == false)
                {
                    Instantiate(gr_Projectile, (transform.position - gr_ProjOffset), Quaternion.identity);
                    nextAttack = Time.time + gr_AttackRate;
                       
                }
                if (gr_SpriteRenderer.flipX == true)
                {
                    Instantiate(gr_Projectile, (transform.position + gr_ProjOffset), Quaternion.identity);
                    nextAttack = Time.time + gr_AttackRate;
                    
                }
            }
        }
    }

    public void CheckIfHit()
    {
        if (myEnemyScript.takeDmg == true)
        {
            gr_MoveSpeed = 0;
            anim.SetBool("isHit", true);
            myEnemyScript.ResetHitAnim();
        }
        else
        {
            anim.SetBool("isHit", false);
        }
    }

    /*void CheckIfFalling()
    {
        if (dDist >= 0.05f)
        {
            isFalling = true;
            //Debug.Log(isFalling);
        }
        else
        {
            isFalling = false;
    
        }
    }*/

    float CalculateHealth()
    {
        return currentHealth / myEnemyScript.health;
    }
}