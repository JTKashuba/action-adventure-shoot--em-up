using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss2_hit_zone : MonoBehaviour
{
    public static int bossHits = 20;
    public static float boss2_hp;
    private int bossHits_initial;
    public GameObject VictoryText;
    public TextMeshProUGUI VictoryEnemDefText;
    void Start()
    {
        VictoryText.SetActive(false);
        bossHits_initial = bossHits;
        boss2_hp = bossHits / (float)bossHits_initial;
    }

    void SetVictoryEnemDefText()
    {
        if (Enemy_Hit_Zone_Collisions.enemiesDefeated == 16)
        {
            GameManager.beetleUnlocked = true;
            FindObjectOfType<AudioManager>().StopPlay("Boss_Theme");
            FindObjectOfType<AudioManager>().PlayOneShot("unlock");
            VictoryEnemDefText.text = "Congratulations! You've unlocked a new special character!";
        }
        else
        {
            VictoryEnemDefText.text = "Total Enemies Defeated: " + Enemy_Hit_Zone_Collisions.enemiesDefeated.ToString() + "\nDefeat all 16 to unlock a new character!";
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
                boss2_hp = bossHits / (float)bossHits_initial;
                if (bossHits == 0)
                {
                    FindObjectOfType<AudioManager>().Play("BossDefeated");
                    GameManager.levelWon = true;
                    SetVictoryEnemDefText();
                    VictoryText.SetActive(true);
                    FindObjectOfType<GameManager>().Level_2_Victory();
                }
            }
        }
    }
}
