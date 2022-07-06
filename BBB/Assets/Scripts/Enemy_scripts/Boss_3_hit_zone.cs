using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss_3_hit_zone : MonoBehaviour
{
    public static int bossHits = 10;
    public static float boss3_hp;
    private int bossHits_initial;
    public GameObject VictoryText;
    public TextMeshProUGUI VictoryEnemDefText;
    void Start()
    {
        VictoryText.SetActive(false);
        bossHits_initial = bossHits;
        boss3_hp = bossHits / (float)bossHits_initial;
    }

    void SetVictoryEnemDefText()
    {
        if (Enemy_Hit_Zone_Collisions.enemiesDefeated >= 19)
        {
            GameManager.planeUnlocked = true;
            FindObjectOfType<AudioManager>().StopPlay("Boss_Theme");
            FindObjectOfType<AudioManager>().PlayOneShot("unlock");
            VictoryEnemDefText.text = "Congratulations! You've unlocked a new special character!";
        }
        else
        {
            VictoryEnemDefText.text = "Total Enemies Defeated: " + Enemy_Hit_Zone_Collisions.enemiesDefeated.ToString() + "\nDefeat at least 19 to unlock a new character!";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player_bullet"))
        {
            //only allow bosses "vulnerable points" to be hit once boss fight is engaged
            if (GameManager.inBossFight)
            {
                FindObjectOfType<AudioManager>().Play("HitBoss");
                bossHits -= 1;
                boss3_hp = bossHits / (float)bossHits_initial;
                if (bossHits == 0)
                {
                    FindObjectOfType<AudioManager>().Play("BossDefeated");
                    GameManager.levelWon = true;
                    SetVictoryEnemDefText();
                    VictoryText.SetActive(true);
                    FindObjectOfType<GameManager>().Level_3_Victory();
                }
            }
        }
    }
}
