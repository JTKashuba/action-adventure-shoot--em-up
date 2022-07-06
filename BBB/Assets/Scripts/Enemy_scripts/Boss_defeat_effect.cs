using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_defeat_effect : MonoBehaviour
{
    private ParticleSystem defeatEffect;

    // Start is called before the first frame update
    void Start()
    {
        defeatEffect = GetComponent<ParticleSystem>();
        defeatEffect.Pause();

    }

    void FixedUpdate()
    {
        //print("level won = " + GameManager.levelWon + "hits = " + GameManager.bossHits);
        if (GameManager.levelWon)
        {
            defeatEffect.Play();
            FindObjectOfType<GameManager>().Level_1_Victory();
        }
    }
}
