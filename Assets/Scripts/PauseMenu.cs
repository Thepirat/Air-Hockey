using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    // Use this for initialization
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
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
        GamePaused = false;
        Time.timeScale = 1f;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Update();
        }
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GamePaused = true;
        Time.timeScale = 0f;
    }
    public void changeScene()
    {
        SceneManager.LoadScene("Menu");

    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("S-a iesit din program");
    }
}
