using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	public static bool IsGamePaused = false;
	public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {

    	if (Input.GetKeyDown(KeyCode.Escape))
    	{ 
    		if (IsGamePaused) {

        		Resume();

        	} else {

        		Pause();

        	}
    	}
  
    }

    public void Resume()
    {
  		pauseMenuUI.SetActive(false);
    	Time.timeScale = 1.0f;
    	IsGamePaused = false;
    }

    void Pause()
    {
    	pauseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	IsGamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
    	SceneManager.LoadScene("Start Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1.0f;
    	Debug.Log("Restarting Game...");
    }

    public void RestartGame_Level2()
    {
        SceneManager.LoadScene("Level_2");
        Time.timeScale = 1.0f;
        Debug.Log("Restarting Game...");
    }

    public void RestartGame_Level3()
    {
        SceneManager.LoadScene("Level_3");
        Time.timeScale = 1.0f;
        Debug.Log("Restarting Game...");
    }

    public void RestartGame_Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
        Time.timeScale = 1.0f;
        Debug.Log("Restarting Game...");
    }

    public void OptionsMenu() 
    {
        //SceneManager.LoadScene("");
        
    }

    public void InvertControls()
   {
        PlayerMovement.invert = -1;
   }

   public void NormalControls()
   {
        PlayerMovement.invert = 1;
   }

    public void Back() 
    {
        //SceneManager.LoadScene
    }
}
