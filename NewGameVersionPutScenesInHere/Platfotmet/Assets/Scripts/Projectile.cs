using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    
    float moveSpeed = 7f;
    public Animation anim;
    Player target;
    Rigidbody2D rb2d;

    Vector2 moveDirection;

    

    //Vector2 playerPos;
    void Start()
    {
        
        anim = GetComponent<Animation>();
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb2d.velocity = new Vector2 (moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name.Equals("Player"))
        {
            Debug.Log("Hit!");

            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
