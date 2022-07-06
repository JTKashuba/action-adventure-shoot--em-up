using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_3_shoot : MonoBehaviour
{
    public Rigidbody bullet;
    public float bullet_speed = 5f;

    public GameObject plane;
    public GameObject[] player_objects;
    private GameObject player;
    bool m_IsPlayerInRange;

    //variables for controling rate of fire
    private float last_shot = 0f;
    public float rate_of_fire = 1.0f;

    private int rand_value;
    private Vector3 left_vector;
    private Vector3 mid_vector;
    private Vector3 right_vector;

    void Start()
    {
        player = player_objects[MainMenu.playerobject_number];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate vector from a game objectto player.
        Vector3 d = player.transform.position - transform.position;
        d = d * bullet_speed;

        d.Normalize();

        // if player is in range, enemy will face to shoot at player
        if (GameManager.inBossFight == true)
        {
            //check to control rate of enemy fire
            if (!GameManager.levelWon)
            {
                if (Time.time > last_shot + rate_of_fire){
                  last_shot = Time.time;

                  rand_value = Random.Range(0, 3);

                  if(rand_value == 0)
                  {
                    //set up newbullet
                    Rigidbody left_bullet = Instantiate(bullet, transform.position, transform.rotation);
                    Rigidbody mid_bullet = Instantiate(bullet, transform.position, transform.rotation);
                    Rigidbody right_bullet = Instantiate(bullet, transform.position, transform.rotation);

                    mid_vector = d;

                    left_vector = mid_vector;
                    left_vector.x -= 0.1f;

                    right_vector = mid_vector;
                    right_vector.x += 0.1f;

                    //make new bullet instently be moving at the desired speed
                    left_bullet.AddForce(left_vector * bullet_speed, ForceMode.VelocityChange);
                    mid_bullet.AddForce(mid_vector * bullet_speed, ForceMode.VelocityChange);
                    right_bullet.AddForce(right_vector * bullet_speed, ForceMode.VelocityChange);
                  }
                  else if(rand_value == 1)
                  {
                    //set up newbullet
                    Rigidbody newbullet = Instantiate(bullet, transform.position, transform.rotation);
                    //make new bullet instently be moving at the desired speed
                    newbullet.AddForce(d * bullet_speed, ForceMode.VelocityChange);
                    newbullet.gameObject.transform.localScale *= 4.0f;
                  }
                  else
                  {
                    //set up newbullet
                    Rigidbody newbullet = Instantiate(bullet, transform.position, transform.rotation);
                    //make new bullet instently be moving at the desired speed
                    newbullet.AddForce(d * bullet_speed, ForceMode.VelocityChange);
                  }
                }
            }
        }
    }
}
