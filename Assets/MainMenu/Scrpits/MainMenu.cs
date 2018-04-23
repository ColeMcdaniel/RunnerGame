using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public int LevelToLoad;

	public void ClickedStartButton()
	{
		SceneManager.LoadScene (1);
	}

	public void doquit () 
	{
		Debug.Log ("Has quit Game");
		Application.Quit(); 
	}

}
