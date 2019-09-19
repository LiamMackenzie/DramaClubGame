using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour
{
    public float timer;
    public float timerReset;
    private Rigidbody2D rb;
    public bool moving;
    public float verticalHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
      
        moving = true;

        
    }

    // Update is called once per frame
    void Update()
    {
         timer -= Time.deltaTime;
    

         if(timer <= 0)
         {
             if(moving == true)
             {
                   rb.velocity = -Vector2.up * verticalHeight;
                   moving = false;
                   timer = timerReset;
             }
             
             else if(moving == false)
             {
                  rb.velocity = Vector2.up * verticalHeight;
                   moving = true;
                   timer = timerReset;
             }
         }
         
    

    
    }
}
