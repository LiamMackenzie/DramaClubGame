using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool GamePause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if(GamePause)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
		
	}

    void Resume()
    {
        PauseMenu.SetActive(false);
        GamePause = false;
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        GamePause = true;
    }
}
