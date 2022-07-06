using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Hit_Zone_Collisions : MonoBehaviour
{
    public GameObject WelcomeText;
    public GameObject MovementText;
    public GameObject AttackText;
    public GameObject AttackAdviceText;
    public GameObject BounceAdviceText;
    public GameObject Dodge1Text;
    public GameObject Dodge2Text;
    public GameObject Dodge3Text;
    public GameObject Dodge4Text;
    public GameObject HealthPickupsText;
    public GameObject WeaponPickups1Text;
    public GameObject WeaponPickups2Text;
    public GameObject BigShotText;
    public GameObject ExtraLifePickupsText;
    public GameObject EndText;
    public GameObject EnemiesDefeatedText;

    // Start is called before the first frame update
    void Start()
    {
        WelcomeText.SetActive(true);
        MovementText.SetActive(false);
        AttackText.SetActive(false);
        AttackAdviceText.SetActive(false);
        BounceAdviceText.SetActive(false);
        Dodge1Text.SetActive(false);
        Dodge2Text.SetActive(false);
        Dodge3Text.SetActive(false);
        Dodge4Text.SetActive(false);
        HealthPickupsText.SetActive(false);
        WeaponPickups1Text.SetActive(false);
        WeaponPickups2Text.SetActive(false);
        BigShotText.SetActive(false);
        ExtraLifePickupsText.SetActive(false);
        EndText.SetActive(false);
        EnemiesDefeatedText.SetActive(false);

        Hit_Zone_Collisions.trip_shot_hp = 0;
        Hit_Zone_Collisions.big_shot_hp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Update_triple_shot()
    {
        if (Hit_Zone_Collisions.trip_shot_hp <= 10)
        {
            Hit_Zone_Collisions.trip_shot_hp = 0;
        }
        else
        {
            Hit_Zone_Collisions.trip_shot_hp -= 10;
        }
    }

    private void Update_big_shot()
    {
        if (Hit_Zone_Collisions.big_shot_hp <= 10)
        {
            Hit_Zone_Collisions.big_shot_hp = 0;
        }
        else
        {
            Hit_Zone_Collisions.big_shot_hp -= 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tut_Movement"))
        {
            WelcomeText.SetActive(false);
            MovementText.SetActive(true);
        }

        if (other.gameObject.CompareTag("Tut_Attack"))
        {
            MovementText.SetActive(false);
            AttackText.SetActive(true);
        }

        if (other.gameObject.CompareTag("Tut_AttackAdvice"))
        {
            AttackText.SetActive(false);
            AttackAdviceText.SetActive(true);
        }

        if (other.gameObject.CompareTag("Tut_DismissAttackAdvice"))
        {
            AttackAdviceText.SetActive(false);
        }

        if (other.gameObject.CompareTag("Tut_BounceAdvice"))
        {
            BounceAdviceText.SetActive(true);
        }
        
        if (other.gameObject.CompareTag("Tut_DismissBounceAdvice"))
        {
            BounceAdviceText.SetActive(false);
        }

        if (other.gameObject.CompareTag("Tut_Dodge1"))
        {
            Dodge1Text.SetActive(true);
        }

        if (other.gameObject.CompareTag("Tut_Dodge2"))
        {
            Dodge1Text.SetActive(false);
            Dodge2Text.SetActive(true);
        }

        if (other.gameObject.CompareTag("Tut_Dodge3"))
        {
            Dodge2Text.SetActive(false);
            Dodge3Text.SetActive(true);
        }

        if (other.gameObject.CompareTag("Tut_Dodge4"))
        {
            Dodge3Text.SetActive(false);
            Dodge4Text.SetActive(true);
        }

        if (other.gameObject.CompareTag("Tut_HealthPickups"))
        {
            Dodge4Text.SetActive(false);
            HealthPickupsText.SetActive(true);
        }

        if (other.gameObject.CompareTag("Tut_WeaponPickups1"))
        {
            HealthPickupsText.SetActive(false);
            WeaponPickups1Text.SetActive(true);    
        }

        if (other.gameObject.CompareTag("Tut_WeaponPickups2"))
        {
            WeaponPickups1Text.SetActive(false);
            WeaponPickups2Text.SetActive(true);    
        }

        if (other.gameObject.CompareTag("Tut_BigShot"))
        {
            WeaponPickups2Text.SetActive(false);
            BigShotText.SetActive(true);    
        }

        if (other.gameObject.CompareTag("Tut_ExtraLifePickups"))
        {
            BigShotText.SetActive(false);
            ExtraLifePickupsText.SetActive(true);
        }

        if (other.gameObject.CompareTag("Tut_End"))
        {
            ExtraLifePickupsText.SetActive(false);
            EndText.SetActive(true);
            //GameManager.tutComplete = true;
            FindObjectOfType<GameManager>().Tut_Complete_1();
        }

        if (other.gameObject.CompareTag("Health_Pickup"))
        {
            FindObjectOfType<AudioManager>().PlayOneShot("yum");
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Life_Pickup"))
        {
            FindObjectOfType<AudioManager>().PlayOneShot("OhYeah!");
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Enemy_bullet"))
        {
            if (!Bank.inBarrelRoll)
            {
                FindObjectOfType<AudioManager>().PlayOneShot("Ouch");

                Update_triple_shot();
                Update_big_shot();
            }
        }

        if (other.gameObject.CompareTag("Trip_Shot_Pickup"))
        {
            FindObjectOfType<AudioManager>().PlayOneShot("Woo!");
            other.gameObject.SetActive(false);

            Hit_Zone_Collisions.trip_shot_hp = 30;
            Hit_Zone_Collisions.big_shot_hp = 0;
        }

        if (other.gameObject.CompareTag("Big_Shot_Pickup"))
        {
            FindObjectOfType<AudioManager>().PlayOneShot("Woo!");
            other.gameObject.SetActive(false);

            Hit_Zone_Collisions.trip_shot_hp = 0;
            Hit_Zone_Collisions.big_shot_hp = 30;
        }

        if (other.gameObject.CompareTag("Life_Pickup"))
        {
            FindObjectOfType<AudioManager>().PlayOneShot("OhYeah!");
            other.gameObject.SetActive(false);
        }
    }
    
}