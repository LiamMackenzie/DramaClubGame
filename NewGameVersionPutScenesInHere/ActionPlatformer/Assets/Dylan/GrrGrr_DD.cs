/* using System.Collections;
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

    private Vector3 gr_ProjOffset;

    [Header("Higher is Slower")]
    public float gr_AttackRate = 1.0f;

    public Slider healthBar;
    public float maxHealth;
    public float currentHealth;
   
    Animator anim;
    private SpriteRenderer gr_SpriteRenderer;
    private PControl pctarget;
    private Enemy myEnemyScript;

     ===================================================================================================================================================================== 

    void Awake()
    {
        groundMask = LayerMask.GetMask("Ground");
        m_Ground = false;
    }

    void Start()
    {
        myEnemyScript = GetComponent<Enemy>();
        anim = gameObject.GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        gr_SpriteRenderer = GetComponent<SpriteRenderer>();
        gr_ProjOffset = new Vector3(0.5f, 0, 0);
        currentHealth = myEnemyScript.health;
        healthBar.value = CalculateHealth();



    }

    void Update()
    {
        pctarget = GameObject.FindObjectOfType<PControl>();
    }

    void FixedUpdate()
    {
        MoveAndAttack();
        CheckIfHit();   
    }

    void LateUpdate()
    {
        FaceDirection();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        { 
            m_Ground = true;
            m_Jump = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        {
            m_Ground = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "High")
        {
            m_Jump = true;
            m_Walk = false;
            m_Ground = false;

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
            m_Jump = true;
            m_Jump = false;
            m_Ground = false;
            if (gr_SpriteRenderer.flipX == false)
            {
                rigid2D.velocity = new Vector2(-jumpForwardsForce, jumpL);
                
            }

            if (gr_SpriteRenderer.flipX == true)
            {
                rigid2D.velocity = new Vector2(jumpForwardsForce, jumpL);
            }
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
            m_Walk = true;
            transform.position = Vector2.MoveTowards(transform.position, pctarget.transform.position, gr_MoveSpeed * Time.deltaTime); //need to change to rigid body movement
        }
        if (Vector2.Distance(transform.position, pctarget.transform.position) < gr_AttackingDistance)
        {
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
            m_Hit = true;
        }
        else
        {
            m_Hit = false;
        }
    }

    float CalculateHealth()
    {
        return currentHealth / myEnemyScript.health;
    }
} */ 