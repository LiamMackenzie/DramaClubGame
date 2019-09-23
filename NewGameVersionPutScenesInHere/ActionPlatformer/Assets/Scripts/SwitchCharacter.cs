using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
   
    public GameObject character1;
    public GameObject character2;
    public GameObject characterInPlay;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
			{
				Switch1();
			}

        if(Input.GetKeyDown(KeyCode.E))
        {
            Switch2();
        }
    }

    void Switch1()
    {
        character1.SetActive(true);
        

        character1.transform.position = characterInPlay.transform.position;
        characterInPlay.SetActive(false);



    }

    void Switch2()
    {
          character2.SetActive(true);
       

        character2.transform.position = characterInPlay.transform.position;
        characterInPlay.SetActive(false);
    }
}
