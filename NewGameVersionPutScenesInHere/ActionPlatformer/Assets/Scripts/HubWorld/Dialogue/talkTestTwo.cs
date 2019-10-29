using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkTestTwo : MonoBehaviour
{
    public static bool Dialogue = false;

    public GameObject DialogueBox;
    public GameObject MatthewBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
     
    }
    public void Resume()
	{
		DialogueBox.SetActive(false);
		Time.timeScale = 1f;
		Dialogue = false;
	}

	void Pause()
	{
		DialogueBox.SetActive(true);
		Time.timeScale = 0f;
		Dialogue = true;
	}

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GrrGrr")
        {
            Debug.Log("YEET");
         
            if(Dialogue == false)
                {
                DialogueBox.SetActive(true);
                Dialogue = true;

                }
           
            }
            else if(collision.gameObject.tag == "Matthew")
            {
                Debug.Log("Sugoi");
                if(Dialogue == false)
                {
                    MatthewBox.SetActive(true);
                    Dialogue = true;
                }
            }
            
        }

    void OnCollisionExit2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "GrrGrr")
        {
            if(Dialogue == true)
            {
                DialogueBox.SetActive(false);
                Dialogue = false;
            }
        }
        else if(collision.gameObject.tag == "Matthew")
        {
            MatthewBox.SetActive(false);
            {
                Dialogue = false;
            }
        }
    }

    
    }
	
