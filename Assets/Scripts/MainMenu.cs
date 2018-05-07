using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public int LevelToLoad;

	public void ClickedStartButton()
	{
		SceneManager.LoadScene ("Runner");
	}

	public void HowToPlayButton()
	{
		SceneManager.LoadScene ("HowToPlay");
	}

	public void CreditsButton()
	{
		SceneManager.LoadScene ("Credits");
	}

	public void BackToMainMenu ()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void doquit () 
	{
		Debug.Log ("Has quit Game");
		Application.Quit(); 
	}

}