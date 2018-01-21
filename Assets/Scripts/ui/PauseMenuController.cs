using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;
	
	// Update is called once per frame
	void Update () {	
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
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
		GameIsPaused = false;
	}
	void Pause()
	{
		pauseMenuUI.SetActive(true);
		GameIsPaused = true;
	}

	public void QuitGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		GameIsPaused = false;
	}
}