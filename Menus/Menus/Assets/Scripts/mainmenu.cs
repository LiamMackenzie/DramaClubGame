using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void StartJourney ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void QUIT ()
	{
		Debug.Log("I love you, platonically don't get any wrong ideas");
		Application.Quit();
	}
	public void Sound ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
	}
}
