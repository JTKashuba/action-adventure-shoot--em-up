using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Hit_Zone_Collisions : MonoBehaviour
{

    private Rigidbody rb;
    public int max_hp = 100;
    private int hp;
    public static float hp_percent_value;
    public static int numLives = 4;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI NumLivesText;
    public GameObject LifeLostText;
    //public static GameObject VictoryText;

    // temp var as hack-y solution to the following problem:
    // # of lives wasn't being updated until the scene restarts, which meant the Game Over screen (EndGame();) wasn't
    // being loaded at the proper time. Might be able to find a more elegant solution later but this works for now.
    private int temp;

    //variables for trip shot
    public static int trip_shot_hp;
    public static int big_shot_hp;
    public static float trip_shot_percent;
    public static float big_shot_percent;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = max_hp;
        hp_percent_value = 1.0f;

        SetNumLivesText();
        LifeLostText.SetActive(false);
        //VictoryText.SetActive(false);

        trip_shot_hp = 0;
        big_shot_hp = 0;
        trip_shot_percent = trip_shot_hp / 30.0f;
        big_shot_percent = big_shot_hp / 30.0f;
    }

    // update HP in UI
    void SetHPText()
    {
        hp_percent_value = hp / (float)max_hp;
        //HPText.text = "HP: " + hp.ToString();
    }

    // update Number of Lives in UI
    void SetNumLivesText()
    {
        temp = numLives - 1;
        NumLivesText.text = "Lives Remaining: " + temp.ToString();
    }

    void Update()
    {
        SetHPText();
        if (hp == 0)
        {
            if (temp == 1)
            {
                //Game Over
                LifeLostText.SetActive(true);
                FindObjectOfType<GameManager>().EndGame();
            }
            // else, lose a life and restart level
            else if (temp > 1)
            {
                LifeLostText.SetActive(true);
                FindObjectOfType<GameManager>().LoseLife();
            }
        }
    }

    private void Update_triple_shot()
    {
        if (trip_shot_hp <= 10)
        {
            trip_shot_hp = 0;
        }
        else
        {
            trip_shot_hp -= 10;
        }
        trip_shot_percent = trip_shot_hp / 30.0f;
    }

    private void Update_big_shot()
    {
        if (big_shot_hp <= 10)
        {
            big_shot_hp = 0;
        }
        else
        {
            big_shot_hp -= 10;
        }
        big_shot_percent = big_shot_hp / 30.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Health_Pickup"))
        {
            FindObjectOfType<AudioManager>().PlayOneShot("yum");
            other.gameObject.SetActive(false);
            // dummy values just to get it working, can adjust for balance later
            if (hp > max_hp - 20)
            {
                hp = max_hp;
            }
            else { hp += 20; }

            // this is where the HP value in the UI will update
            // (enemies defeated still need to be called somewhere)
            SetHPText();
        }

        if (other.gameObject.CompareTag("Life_Pickup"))
        {
            FindObjectOfType<AudioManager>().PlayOneShot("OhYeah!");
            other.gameObject.SetActive(false);

            numLives++;
            SetNumLivesText();
        }

        if (other.gameObject.CompareTag("Trip_Shot_Pickup"))
        {
            FindObjectOfType<AudioManager>().PlayOneShot("Woo!");
            other.gameObject.SetActive(false);

            trip_shot_hp = 30;
            big_shot_hp = 0;
            trip_shot_percent = trip_shot_hp / 30.0f;
            big_shot_percent = big_shot_hp / 30.0f;
        }

        if (other.gameObject.CompareTag("Big_Shot_Pickup"))
        {
            FindObjectOfType<AudioManager>().PlayOneShot("Woo!");
            other.gameObject.SetActive(false);

            trip_shot_hp = 0;
            big_shot_hp = 30;
            trip_shot_percent = trip_shot_hp / 30.0f;
            big_shot_percent = big_shot_hp / 30.0f;
        }

        // if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Enemy"))
        if (other.gameObject.CompareTag("Enemy"))
        {
            // add Game Over event after creating game over screen
            //if (hp <= 10)
            //{

            //}
            FindObjectOfType<AudioManager>().PlayOneShot("Ouch");
            if (hp <= 10)
            {
                hp = 0;
            }
            else
            {
                hp -= 10;
            }
            SetHPText();

            Update_triple_shot();
            Update_big_shot();
        }

        if (other.gameObject.CompareTag("Enemy_bullet"))
        {
            //check that player isn't in the barrel roll animation
            if (!Bank.inBarrelRoll)
            {
                FindObjectOfType<AudioManager>().PlayOneShot("Ouch");
                if (hp < 15) { hp = 0; }
                else { hp -= 15; }
                SetHPText();

                Update_triple_shot();
                Update_big_shot();
            }
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            //pass
        }
    }
}
