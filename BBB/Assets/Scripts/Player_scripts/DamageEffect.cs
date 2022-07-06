 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{

    private ParticleSystem damageEffect;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        damageEffect = GetComponent<ParticleSystem>();
        damageEffect.Pause();

    }

    void OnTriggerEnter(Collider other)
    {
        // if player collects a health pickup, do not play the damage effect
        // similarly, do not display the damage effect when hitting the box colliders in the tutorial level
        if (other.gameObject.CompareTag("Health_Pickup") || other.gameObject.CompareTag("Trip_Shot_Pickup")
            || other.gameObject.CompareTag("Big_Shot_Pickup") || other.gameObject.CompareTag("Life_Pickup")
            || other.gameObject.CompareTag("Tut_Movement") || other.gameObject.CompareTag("Tut_Attack")
            || other.gameObject.CompareTag("Tut_AttackAdvice") || other.gameObject.CompareTag("Tut_DismissAttackAdvice")
            || other.gameObject.CompareTag("Tut_BounceAdvice") || other.gameObject.CompareTag("Tut_DismissBounceAdvice")
            || other.gameObject.CompareTag("Tut_Dodge1") || other.gameObject.CompareTag("Tut_Dodge2")
            || other.gameObject.CompareTag("Tut_Dodge3") || other.gameObject.CompareTag("Tut_Dodge4")
            || other.gameObject.CompareTag("Tut_HealthPickups")
            || other.gameObject.CompareTag("Tut_WeaponPickups1") || other.gameObject.CompareTag("Tut_WeaponPickups2")
            || other.gameObject.CompareTag("Tut_ExtraLifePickups") || other.gameObject.CompareTag("Obstacle"))
        {
            damageEffect.Pause();
        }

        else
        {
            if (!Bank.inBarrelRoll)
            {
                damageEffect.Play();
            }

        }
        //damageEffect.Play();
    }

}
