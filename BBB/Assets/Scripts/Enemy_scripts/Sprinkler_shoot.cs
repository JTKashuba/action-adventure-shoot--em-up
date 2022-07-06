using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkler_shoot : MonoBehaviour
{
    public Rigidbody bullet;
    public float bullet_speed = 100f;
    public float shot_angle;
    private Vector3 d;
    private float new_angle;

    //variables for controling rate of fire
    private float last_shot = 0f;
    public float rate_of_fire = 1.0f;


    // Update is called once per frame
    void FixedUpdate()
    {
        // new_angle = shot_angle + Random.Range(-1.0f, 1.0f);
        new_angle = shot_angle + Random.Range(-0.1f, 0.1f);
        d = new Vector3(Mathf.Cos(new_angle), Mathf.Sin(new_angle), 0);

        if (Time.time > last_shot + rate_of_fire){
            last_shot = Time.time;

            //set up newbullet
            Rigidbody newbullet = Instantiate(bullet, transform.position, transform.rotation);
            //make new bullet instently be moving at the desired speed
            newbullet.AddForce(d * bullet_speed, ForceMode.VelocityChange);
        }
    }
}
