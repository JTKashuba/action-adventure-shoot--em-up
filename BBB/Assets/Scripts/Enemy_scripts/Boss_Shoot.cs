using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Shoot : MonoBehaviour
{
    public Rigidbody bullet;
    public float bullet_speed = 5f;

    public GameObject plane;
    public GameObject[] player_objects;
    private GameObject player;
    bool m_IsPlayerInRange;
    private float zDiff;
    private float shoot_dist;

    //variables for controling rate of fire
    private float last_shot = 0f;
    public float rate_of_fire = 1.0f;

    void Start()
    {
        player = player_objects[MainMenu.playerobject_number];
        shoot_dist = -MoveForward.boss_stop_dist;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate vector from a game objectto player.
        Vector3 d = player.transform.position - transform.position;
        //d.y += 1;

        // d.x = d.x * bullet_speed;
        // d.y = d.y * bullet_speed;
        // d.z = d.z * (bullet_speed);
        d = d * bullet_speed;

        d.Normalize();

        // the player itself is not "moving", the plane is moving beneath
        zDiff = plane.transform.position.z - transform.position.z;

        // if player is in range, enemy will face to shoot at player
        if (GameManager.inBossFight == true)
        {
            //check to control rate of enemy fire
            if (!GameManager.levelWon)
            {
                if (Time.time > last_shot + rate_of_fire){
                  last_shot = Time.time;

                  //set up newbullet
                  Rigidbody newbullet = Instantiate(bullet, transform.position, transform.rotation);
                  //make new bullet instently be moving at the desired speed
                  newbullet.AddForce(d * bullet_speed, ForceMode.VelocityChange);
                }
            }
        }
    }
}
