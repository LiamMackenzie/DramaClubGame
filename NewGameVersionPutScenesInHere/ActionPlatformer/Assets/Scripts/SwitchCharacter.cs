using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    PControl pControl;
    public int numberOfCharacters; 
    List<GameObject> characters;

    [SerializeField]
    private GameObject character1;
    [SerializeField]
    private GameObject character2;

    private int currentIndex;
    private GameObject currentCharacter;

    public GameObject characterInPlay;
     private void Start() 
    {
        characters = new List<GameObject>();
        characters.Add (character1);
        characters.Add (character2);
        currentIndex = -1;
    }
    

    
    void Update()
    {
        //foreach (GameObject c in characters )
        //{
            //Debug.Log(c);
        //}
    
        if (Input.GetKeyDown(KeyCode.Q))
			{
				Switch();
			}

        if(Input.GetKeyDown(KeyCode.E))
        {
            Switch();
        }
    }

     public void Switch()
    {
        currentIndex += 1;
        if (currentIndex >= characters.Count)
            currentIndex = 0;
        currentCharacter = characters[currentIndex];
        

        //set pos
        currentCharacter.transform.position = characterInPlay.transform.position;
        //turn off old character
        characterInPlay.SetActive(false);
        //switch them
        characterInPlay = currentCharacter;
        //turn on the new one
        characterInPlay.SetActive(true);
    }

    /*public void Switch2()
    {
          characters[1].SetActive(true);
       

        characters[1].transform.position = characterInPlay.transform.position;
        characterInPlay.SetActive(false);
    } */
}
