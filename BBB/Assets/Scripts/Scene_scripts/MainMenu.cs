using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int playerobject_number = 0;

    public void PlayGame ()
    {
     	  //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Tutorial");
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
     	  SceneManager.LoadScene("Start Menu");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void Butterfly_select()
    {
        playerobject_number = 0;
    }

    public void Bee_select()
    {
        if (GameManager.beeUnlocked)
        {
            playerobject_number = 1;
        }
    }

    public void Beetle_select()
    {
        if (GameManager.beetleUnlocked)
        {
            playerobject_number = 2;
        }
    }

    public void Airplane_select()
    {
        if (GameManager.planeUnlocked)
        {
            playerobject_number = 3;
        }
    }

   // void FixedUpdate()
   // {
   //   print(playerobject_number);
   // }
}
