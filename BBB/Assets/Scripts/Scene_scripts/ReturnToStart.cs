using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToStart : MonoBehaviour
{
    public void Return_To_Start()
    {
        SceneManager.LoadScene("Start Menu");
    }
}