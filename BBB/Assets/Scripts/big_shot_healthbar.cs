using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class big_shot_healthbar : MonoBehaviour
{
    //cite -  http://gyanendushekhar.com/2019/11/17/create-health-bar-unity-3d/
    private static Image HealthBarImage;

    /// Initialize the variable
    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        SetHealthBarValue(0);
    }

    void Update()
    {
        SetHealthBarValue(Hit_Zone_Collisions.big_shot_percent);
    }

    /// Sets the health bar value
    void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
    }

}
