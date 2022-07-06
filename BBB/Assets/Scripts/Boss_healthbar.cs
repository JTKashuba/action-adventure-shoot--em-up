using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss_healthbar : MonoBehaviour
{
    //cite -  http://gyanendushekhar.com/2019/11/17/create-health-bar-unity-3d/
    private static Image HealthBarImage;

    /// Initialize the variable
    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        SetHealthBarValue(0f);
    }

    void Update()
    {
        if (GameManager.inBossFight == true)
        {
            if (SceneManager.GetActiveScene().name == "Level_1")
            {
                SetHealthBarValue(Boss_Hit_Zone_Collisions.boss_hp);
            }

            if (SceneManager.GetActiveScene().name == "Level_2")
            {
                SetHealthBarValue(Boss2_hit_zone.boss2_hp);
            }

            if (SceneManager.GetActiveScene().name == "Level_3")
            {
                SetHealthBarValue(Boss_3_hit_zone.boss3_hp);
            }
        }
    }

    /// Sets the health bar value
    public static void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
        // if(HealthBarImage.fillAmount < 0.2f)
        // {
        //     SetHealthBarColor(Color.red);
        // }
        // else if(HealthBarImage.fillAmount < 0.4f)
        // {
        //     SetHealthBarColor(Color.yellow);
        // }
        // else
        // {
        //     SetHealthBarColor(Color.green);
        // }
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }

    /// Sets the health bar color
    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }
}
