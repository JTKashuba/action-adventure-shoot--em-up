using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_3_movement : MonoBehaviour
{
    public GameObject[] waypoints;
    public float movement_speed = 2.5f;

    private int waypoint_idx;
    private GameObject next_loc;
    private float step;

    void Start ()
    {
        waypoint_idx = 0;
        next_loc = waypoints[waypoint_idx];
    }

    void Update ()
    {
        if (GameManager.levelWon == false)
        {
            if (transform.position != next_loc.transform.position){
              step = movement_speed * Time.deltaTime;
              transform.position = Vector3.MoveTowards(transform.position, next_loc.transform.position, step);
            }
            else{
              StartCoroutine(Pause_movement());
            }
        }
    }

    IEnumerator Pause_movement()
    {
        yield return new WaitForSeconds(1);
        waypoint_idx += 1;
        if (waypoint_idx >= waypoints.Length){
          waypoint_idx = 0;
        }
        next_loc = waypoints[waypoint_idx];
    }
}
