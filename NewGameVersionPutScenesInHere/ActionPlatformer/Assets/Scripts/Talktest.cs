using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talktest : MonoBehaviour
{
    public static bool Dialogue = false;

    public GameObject DialogueBox;
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
        if (collision.gameObject.tag == "Amanda")
        {
            Debug.Log("YEET");
         
            if(Dialogue == false)
                {
                DialogueBox.SetActive(true);
                Dialogue = true;

                }
           
            }
            
        }

    void OnCollisionExit2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Amanda")
        {
            if(Dialogue == true)
            {
                DialogueBox.SetActive(false);
                Dialogue = false;
            }
        }
    }
    }
	
	

