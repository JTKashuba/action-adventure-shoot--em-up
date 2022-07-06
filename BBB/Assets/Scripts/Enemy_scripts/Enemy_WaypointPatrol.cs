using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_WaypointPatrol : MonoBehaviour
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
        if (transform.position != next_loc.transform.position){
          step = movement_speed * Time.deltaTime;
          transform.position = Vector3.MoveTowards(transform.position, next_loc.transform.position, step);
        }
        else{
          waypoint_idx += 1;
          if (waypoint_idx >= waypoints.Length){
            waypoint_idx = 0;
          }

          next_loc = waypoints[waypoint_idx];
        }
    }
}
