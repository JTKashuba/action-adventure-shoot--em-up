using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayAgainGameOver : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Level_1");
    }
}
