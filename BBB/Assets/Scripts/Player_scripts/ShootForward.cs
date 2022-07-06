using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootForward : MonoBehaviour
{
  public Rigidbody bullet;
  public float bullet_speed = 100f;
  public float fire_rate = 1f;

  private bool canShoot;
  private float last_shot = 0.0f;

  private Vector3 left_vector;
  private Vector3 mid_vector;
  private Vector3 right_vector;

  // Update is called once per frame
  void Update()
  {
      if(Input.GetKeyDown("space"))
      {
        Fire();
      }
  }

  void Fire()
  {
    if (!Bank.inBarrelRoll && Time.time > fire_rate + last_shot)
    {

        //check if player has the triple shot effect
        if (Hit_Zone_Collisions.trip_shot_hp > 0)
        {
          //set up newbullet
          Rigidbody left_bullet = Instantiate(bullet, transform.position, transform.rotation);
          Rigidbody mid_bullet = Instantiate(bullet, transform.position, transform.rotation);
          Rigidbody right_bullet = Instantiate(bullet, transform.position, transform.rotation);

          mid_vector = transform.forward;

          left_vector = mid_vector;
          left_vector.x -= 0.1f;

          right_vector = mid_vector;
          right_vector.x += 0.1f;

          //make new bullet instently be moving at the desired speed
          left_bullet.AddForce(left_vector * bullet_speed, ForceMode.VelocityChange);
          mid_bullet.AddForce(mid_vector * bullet_speed, ForceMode.VelocityChange);
          right_bullet.AddForce(right_vector * bullet_speed, ForceMode.VelocityChange);
          FindObjectOfType<AudioManager>().PlayOneShot("trippew");
        }

        else if (Hit_Zone_Collisions.big_shot_hp > 0)
        {
            print("Shooting BIG");
            //set up newbullet
            Rigidbody newbullet = Instantiate(bullet, transform.position, transform.rotation);

            //make new bullet instently be moving at the desired speed
            newbullet.AddForce(transform.forward * bullet_speed, ForceMode.VelocityChange);

            newbullet.gameObject.transform.localScale *= 4.0f;
            FindObjectOfType<AudioManager>().PlayOneShot("bigpew");
        }

        else
        {
            //set up newbullet
            Rigidbody newbullet = Instantiate(bullet, transform.position, transform.rotation);
            //make new bullet instently be moving at the desired speed
            newbullet.AddForce(transform.forward * bullet_speed, ForceMode.VelocityChange);
            FindObjectOfType<AudioManager>().PlayOneShot("pew");
        }

        last_shot = Time.time;
    }
  }
}
