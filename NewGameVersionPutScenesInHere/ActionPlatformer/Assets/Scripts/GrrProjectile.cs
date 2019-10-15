using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrrProjectile : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 moveDirection;
    PControl target; 


    public float gr_ProjSpeed = 5f;
    public float gr_ProjDamage = 5f;
    public float gr_ProjDestroyAfterTime = 3f;

    
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PControl>();
        moveDirection = (target.transform.position - transform.position).normalized * gr_ProjSpeed;
        rb2d.velocity = new Vector2 (moveDirection.x, moveDirection.y);
        Destroy (gameObject, gr_ProjDestroyAfterTime);
    }

    


}
