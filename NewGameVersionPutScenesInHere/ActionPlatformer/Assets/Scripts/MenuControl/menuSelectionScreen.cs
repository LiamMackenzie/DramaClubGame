using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuSelectionScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startingUp()
    {
         SceneManager.LoadScene("MainHubJasonUpdate");
    }

    public void loadgame()
    {
        Debug.Log("Loading");
         Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSengUghf2Nb6ibKJD506w8S1h7ryGGxXqN-IwwDRKboUKbkoA/viewform?usp=sf_link");
    }

    public void quit()
    {
        Debug.Log("quitting game sir");
        Application.Quit();
    }
}
