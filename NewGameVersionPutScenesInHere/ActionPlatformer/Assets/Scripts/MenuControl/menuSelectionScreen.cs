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
         SceneManager.LoadScene("MainHub");
    }

    public void loadgame()
    {
        Debug.Log("Loading");
    }

    public void quit()
    {
        Debug.Log("quitting game sir");
        Application.Quit();
    }
}
