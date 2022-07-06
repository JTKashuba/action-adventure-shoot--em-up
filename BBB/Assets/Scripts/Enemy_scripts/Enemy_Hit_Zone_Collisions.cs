using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Enemy_Hit_Zone_Collisions : MonoBehaviour
{
    public static int enemiesDefeated;
    public TextMeshProUGUI EnemiesDefeatedText;
    

    void Start()
    {
        enemiesDefeated = 0;
        SetEnemiesDefeatedText();
    }

    void SetEnemiesDefeatedText()
    {
        EnemiesDefeatedText.text = "Enemies Defeated: " + enemiesDefeated.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player_bullet"))
        {
            FindObjectOfType<AudioManager>().Play("EnemyDefeat");
            gameObject.SetActive(false);
            enemiesDefeated += 1;
            SetEnemiesDefeatedText();

        }
    }
}
