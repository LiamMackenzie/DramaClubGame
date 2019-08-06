﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

public static bool GamePause = false;

public GameObject pauseMenuUI;



	
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
	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GamePause = false;
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GamePause = true;
	}
	
	public void LoadMenu()
	{
		Debug.Log("Loading Menu...");
		SceneManager.LoadScene("Menu");
	}

	public void QuitGame()
	{
		Debug.Log("Quitting Game...");
		Application.Quit();
	}

	public void controls()
	{
		Debug.Log("Loading Controlss... Because someone didn't read them earlier and are now complaining");
	}

	public void LoadGame()
	{
		Debug.Log("Loading Load Screen...");
	}
}
