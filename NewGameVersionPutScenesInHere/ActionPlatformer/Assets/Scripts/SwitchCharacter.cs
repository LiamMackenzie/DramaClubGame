using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchCharacter : MonoBehaviour
{
    PControl pControl;

    public int numberOfCharacters; 
    List<GameObject> characters;

    [SerializeField]
    private GameObject character1;
    [SerializeField]
    private GameObject character2;
    [SerializeField]
    private GameObject character3;

    private int currentIndex;
    private GameObject currentCharacter;

    public GameObject characterInPlay;
    public CameraFollowMe cam;

    private bool characterChangeCooldown = false;


    private int deathCounter = 0;

    private void Start() 
    {
        characters = new List<GameObject>();
        characters.Add (character1);
        characters.Add (character2);
        characters.Add (character3);
        currentIndex = -1;
        pControl = GetComponentInChildren<PControl>();

    }
    

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && characterChangeCooldown == false)
		{
			Switch();
            pControl = GetComponentInChildren<PControl>();
            Invoke("ResetCooldown", 1.0f);
            characterChangeCooldown = true;


		} 

        if (pControl.currentHealth <= 0)
        {
            Switch();
            pControl = GetComponentInChildren<PControl>();
            deathCounter++;
        }

        if(deathCounter >= 3)
        {
            SceneManager.LoadScene("BossDD");
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
    void ResetCooldown()
    {
        characterChangeCooldown = false;
    }

}
