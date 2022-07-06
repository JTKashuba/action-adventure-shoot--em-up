using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float Delay = 3f;
    public float LevelEndDelay = 10f;
    bool lifeLost = false;
    bool gameHasEnded = false;

    //boss fight variables
    public static bool inBossFight = false;
    //public static bool tutComplete = false;
    public static bool levelWon = false;

    public static bool beeUnlocked = false;
    public static bool beetleUnlocked = false;
    public static bool planeUnlocked = false;

    private void Start()
    {
        beeUnlocked = false;
        beetleUnlocked = false;
        planeUnlocked = false;
    }


    public void LoseLife()
    {
        if (lifeLost == false)
        {
            lifeLost = true;
            Hit_Zone_Collisions.numLives--;
            Debug.Log("Lost a Life, restart level");
            Invoke("Restart", Delay);
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Hit_Zone_Collisions.numLives--;
            Debug.Log("Game Over");
            Invoke("LoseScreen", Delay);
        }
    }

    void Restart()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("ohno");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LoseScreen()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("gameover");
        Hit_Zone_Collisions.numLives = 4;
        SceneManager.LoadScene("GameOver");
    }

    public void Tut_Complete_1()
    {
        Debug.Log("Tutorial Complete!");
        Invoke("Tut_Complete_2", LevelEndDelay);
        // if (tutComplete == true)
        // {
        //     Debug.Log("Tutorial Complete!");
        //     Invoke("Tut_Complete_2", LevelEndDelay);
        // }
    }

    void Tut_Complete_2()
    {
        levelWon = false;
        SceneManager.LoadScene("Tutorial_Complete");
    }

    public void Level_1_Victory()
    {
        if (levelWon == true)
        {
            Debug.Log("Level 1: VICTORY!");
            Invoke("L1_Complete", LevelEndDelay);
        }
    }

    void L1_Complete()
    {
        inBossFight = false;
        levelWon = false;
        AudioManager.bossMusic = false;
        SceneManager.LoadScene("Level_1_Complete");
    }

    public void Level_2_Victory()
    {
        if (levelWon == true)
        {
            Debug.Log("Level 2: VICTORY!");
            Invoke("L2_Complete", LevelEndDelay);
        }
    }

    void L2_Complete()
    {
        inBossFight = false;
        levelWon = false;
        AudioManager.bossMusic = false;
        SceneManager.LoadScene("Level_2_Complete");
    }

    public void Level_3_Victory()
    {
        if (levelWon == true)
        {
            Debug.Log("Level 3: VICTORY!");
            Invoke("L3_Complete", LevelEndDelay);
        }
    }

    void L3_Complete()
    {
        inBossFight = false;
        levelWon = false;
        AudioManager.bossMusic = false;
        SceneManager.LoadScene("Level_3_Complete");
    }

}
