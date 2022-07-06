using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy_trip_shot : MonoBehaviour
{
    public Rigidbody bullet;
    public float bullet_speed = 25f;
    public float shoot_dist = -75.0f;

    public GameObject plane;
    public GameObject[] player_objects;
    private GameObject player;
    bool m_IsPlayerInRange;
    private float zDiff;

    private Vector3 left_vector;
    private Vector3 mid_vector;
    private Vector3 right_vector;

    //variables for controling rate of fire
    private float next_fire = 0f;
    public float rate_of_fire = 1.0f;

    void Start()
    {
        player = player_objects[MainMenu.playerobject_number];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate vector from a game objectto player.
        Vector3 d = player.transform.position - transform.position;
        //d.y += 1;

        d.x = d.x * bullet_speed;
        d.y = d.y * bullet_speed;
        if (SceneManager.GetActiveScene().name == "Level_2")
        {
            d.z = d.z * (bullet_speed - 10f);
        }
        else
        {
            d.z = d.z * (bullet_speed - 7.5f);
        }

        d.Normalize();

        // the player itself is not "moving", the plane is moving beneath
        zDiff = plane.transform.position.z - transform.position.z;

        m_IsPlayerInRange = zDiff > shoot_dist && zDiff < 0;

        // if player is in range, enemy will face to shoot at player
        if (m_IsPlayerInRange)
        {
            //check to control rate of enemy fire
            if (Time.time > next_fire)
            {
                next_fire = Time.time + rate_of_fire;

                // //set up newbullet
                // Rigidbody newbullet = Instantiate(bullet, transform.position, transform.rotation);
                // //make new bullet instently be moving at the desired speed
                // newbullet.AddForce(d * bullet_speed, ForceMode.VelocityChange);

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
        }
    }
}
