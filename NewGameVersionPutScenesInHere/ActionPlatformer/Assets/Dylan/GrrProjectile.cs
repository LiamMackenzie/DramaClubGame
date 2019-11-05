using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrrProjectile : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 moveDirection;
    PControl target;
    Animator anim;



    public float gr_ProjSpeed = 5f;
    public float gr_ProjDamage = 5f;
    public float gr_ProjDestroyAfterTime = 3f;

    bool m_Hit;

    
    
    void Start()
    {
        m_Hit = false;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PControl>();
        moveDirection = (target.transform.position - transform.position).normalized * gr_ProjSpeed;
        rb2d.velocity = new Vector2 (moveDirection.x, moveDirection.y);
        m_Hit = false;
        Destroy (gameObject, gr_ProjDestroyAfterTime);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            anim.SetBool("isHit", true);
            Debug.Log("truehit");
            Destroy(gameObject, 0.25f);
            
        }
    }




}
