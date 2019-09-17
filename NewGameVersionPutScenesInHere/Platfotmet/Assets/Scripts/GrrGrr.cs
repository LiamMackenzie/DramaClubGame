using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrrGrr : MonoBehaviour
{

   
    Animation anim;
    public float speed;
    private float distance = 10f;
    public Transform groundDetection;

    [SerializeField]
    GameObject projectile;

    public float fireRate;
    float nextFire;
    Collider2D other;
    private bool movingRight = true;
    LayerMask ground;

    SpriteRenderer sprite;

    //Rigidbody2D rigidBody2D;


    void Start() 
    {
       anim = GetComponent<Animation>();
       sprite = GetComponent<SpriteRenderer>();
       other = GetComponent<Collider2D>();
       ground = LayerMask.GetMask("Ground");
       //rigidBody2D = GetComponent<Rigidbody2D>();

       fireRate = 1f;
       nextFire = Time.time;
       speed = 2.5f;

        
       
       
    }

     
     

     void Update()
     {
         Move();
     }
     
     void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, ground);

        if(groundInfo == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3 (0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3 (0, 0, 0);
                movingRight = true;
            }
        }
        

    }
   
     void OnTriggerStay2D(Collider2D other)
    {
        if((other.gameObject.name == "Player") && other.transform.position.x < transform.position.x)
        {
            
            
            Debug.Log("Collided with player");
            //transform.Translate(0,0,0);
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
            
            Shoot();
                      
        }

        if((other.gameObject.name == "Player") && other.transform.position.x > transform.position.x)
        {
            Debug.Log("Collided with player");
            //transform.Translate(0,0,0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
            
            Shoot();
                      
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            Debug.Log("Bye felicia");
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            //transform.eulerAngles = new Vector3(0, -180, 0);
           // movingRight = false;
           Move();
        }
            
            //speed = 2f;
            
            
    }

    void Shoot()
    {
        //Stop the enemy moving
        speed = 0f;
        Debug.Log("Shoot was called");


        if(Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
        


        
        
        //Animator. Do things!
    }  
}
