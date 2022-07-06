using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public GameObject[] player_objects;
    private GameObject player;
    public GameObject plane;
    bool m_IsPlayerInRange;
    private Vector3 _angles;
    public float rotateSpeed = .5f;
    private float zDiff;

    void Start()
    {
        // Reuse rather than creating this every update.
        _angles = new Vector3(0.0f, 1.0f, 0.0f);

        player = player_objects[MainMenu.playerobject_number];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // the player itself is not "moving", the plane is moving beneath
        zDiff = plane.transform.position.z - transform.position.z;
        Vector3 d = player.transform.position - transform.position;

        // -50f is arbitrary, balance adjust needed
        m_IsPlayerInRange = zDiff > -100.0f && zDiff < 0;

        // if player is in range, enemy will face to shoot at player
        if (m_IsPlayerInRange)
        {
            //transform.LookAt(player.transform);
            d.Normalize();
            d = d * -1;

            // using Dot Product to determine the angle
            float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(Vector3.forward, d));

            // Textbook, but *not* most efficient solution.
            Vector3 cross = Vector3.Cross(Vector3.forward, d);
            if (cross.y < 0.0f) {
                angle = -angle;
            }

            _angles.y = angle;
            transform.eulerAngles = _angles;

            // using Dot Product to cause the spider to face the player at all times
            transform.Rotate (_angles * rotateSpeed * Time.deltaTime);
        }

    }

}
