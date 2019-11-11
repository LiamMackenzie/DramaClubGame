using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkTestTwo : MonoBehaviour
{
    public static bool Dialogue = false;

    public GameObject DialogueBox;
    public GameObject MatthewBox;
    public GameObject ChairBox;
    public GameObject WindowBox;
    public GameObject TrashBox;
    public GameObject DylanBox;
    public GameObject PaintBox;
    public GameObject StageBox;
    public GameObject BunnyBox;
    public GameObject MicroBox;
    public AudioSource walls;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The game has started friend");
        walls= GetComponent<AudioSource>();
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
            else if(collision.gameObject.tag == "Chairs")
            {
                Debug.Log ("ChairMan");
                if(Dialogue == false)
                {
                    ChairBox.SetActive(true);
                    Dialogue = true;
                }
            }

            else if(collision.gameObject.tag == "Window")
            {
                Debug.Log("to the window");
                if(Dialogue == false)
                {
                    WindowBox.SetActive(true);
                    Dialogue = true;
                }
            }

            else if(collision.gameObject.tag == "Trash")
            {
                Debug.Log("Me");
                
                    if(Dialogue == false)
                    {
                        TrashBox.SetActive(true);
                        Dialogue = true;
                    }
            }
            

            else if(collision.gameObject.name == "Dylan")
            {
                Debug.Log("Hi");
                if(Dialogue == false)
                {
                    DylanBox.SetActive(true);
                    Dialogue = true;
                }

            }

            else if(collision.gameObject.tag == "Painting")
            {
                if(Dialogue == false)
                {
                    PaintBox.SetActive(true);
                    Dialogue = true;
                }
            }
            else if(collision.gameObject.name == "Stage")
            {
                if(Dialogue == false)
                {
                    StageBox.SetActive(true);
                    Dialogue = true;
                }
            }

            else if(collision.gameObject.name == "Bunny")
            {
                if(Dialogue == false)
                {
                    BunnyBox.SetActive(true);
                    Dialogue = true;
                }
            }

            else if(collision.gameObject.name == "microphone")
            {
                if(Dialogue == false)
                {
                    MicroBox.SetActive(true);
                    Dialogue = true;
                }
            }

            else if(collision.gameObject.tag == "Walls")
            {
                walls.Play();
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

        else if(collision.gameObject.tag == "Chairs")
        {
            ChairBox.SetActive(false);
            Dialogue = false;
        }

        else if(collision.gameObject.tag == "Window")
        {
            if(Dialogue == true)
            {
                WindowBox.SetActive(false);
                Dialogue = false;
            }
        }

        else if(collision.gameObject.tag == "Trash")
        {
            if(Dialogue = true)
            {
                TrashBox.SetActive(false);
                Dialogue = false;
            }
        }

        else if(collision.gameObject.name == "Dylan")
        {
            if(Dialogue = true)
            {
                DylanBox.SetActive(false);
                Dialogue = false;
            }
        }
        else if(collision.gameObject.tag == "Painting")
        {
            if(Dialogue = true)
            {
                PaintBox.SetActive(false);
                Dialogue = false;
            }
        }

        else if(collision.gameObject.name == "Stage")
        {
            if(Dialogue = true)
            {
                StageBox.SetActive(false);
                Dialogue = false;
            }
        }

        else if(collision.gameObject.name == "Bunny")
        {
            if(Dialogue = true)
            {
                BunnyBox.SetActive(false);
                Dialogue = false;
            }
        }

        else if(collision.gameObject.name == "microphone")
        {
            if(Dialogue = true)
            {
                MicroBox.SetActive(false);
                Dialogue = false;
            }
        }
    }

    
    }
	
