using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{

    public static bool GamePause = false;

    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
         SceneManager.LoadScene("MainMenu");
    }

    public void hubLoad()
    {
        SceneManager.LoadScene("MainHub");
    }

    public void quitting()
    {
        Debug.Log("quitting game sir");
        Application.Quit();
    }

    public void resuming()
    {
        pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GamePause = false;
    }
    
}
