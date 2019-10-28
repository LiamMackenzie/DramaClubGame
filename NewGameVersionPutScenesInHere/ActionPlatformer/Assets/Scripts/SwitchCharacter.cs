using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    public PControl pControl;

    public int numberOfCharacters; 
    List<GameObject> characters;

    [SerializeField]
    private GameObject character1;
    [SerializeField]
    private GameObject character2;

    private int currentIndex;
    private GameObject currentCharacter;

    public GameObject characterInPlay;
    public CameraFollowMe cam;

    private void Start() 
    {
        characters = new List<GameObject>();
        characters.Add (character1);
        characters.Add (character2);
        currentIndex = -1;
        pControl = GetComponent<PControl>();
    }
    

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
        cam.ChangeTargets(currentCharacter);
        

        //set pos
        currentCharacter.transform.position = characterInPlay.transform.position;
        //turn off old character
        characterInPlay.SetActive(false);
        //switch them
        characterInPlay = currentCharacter;
        //turn on the new one
        characterInPlay.SetActive(true);
    }

}
