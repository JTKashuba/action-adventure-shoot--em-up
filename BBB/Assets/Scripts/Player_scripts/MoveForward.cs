using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10f;
    public float stop_dist = 15f;
    static public float boss_stop_dist;

    public GameObject Boss;

    private float zDiff;

    void Start()
    {
        boss_stop_dist = stop_dist;
    }

    // Update is called once per frame
    void Update()
    {
        // the player itself is not "moving", the plane is moving beneath
        zDiff = Boss.transform.position.z - transform.position.z;


        if (zDiff > boss_stop_dist)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            GameManager.inBossFight = true;
        }

    }
}
