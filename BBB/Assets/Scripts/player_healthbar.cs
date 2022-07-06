using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_healthbar : MonoBehaviour
{
    //cite -  http://gyanendushekhar.com/2019/11/17/create-health-bar-unity-3d/
    private static Image HealthBarImage;

    /// Initialize the variable
    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        SetHealthBarValue(1);
    }

    void Update()
    {
        SetHealthBarValue(Hit_Zone_Collisions.hp_percent_value);
    }

    /// Sets the health bar value
    public static void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
        if(HealthBarImage.fillAmount < 0.25f)
        {
            SetHealthBarColor(Color.red);
        }
        else if(HealthBarImage.fillAmount < 0.5f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
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
