using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;
    public float maxVertical = 3.5f;
    public float maxHorizontal = 6.5f;

    private Vector3 m_Movement;

    private Vector3 finalDirection;

    private float horizontal;
    private float vertical;
    private float initial_y;

    //Negative 1 for inverted controls positive for not
    public static int invert = 1;

    void Start()
    {
      initial_y = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      //get user inputs
      horizontal = Input.GetAxis("Horizontal");
      vertical = Input.GetAxis("Vertical") * invert;

      finalDirection.Set(horizontal, vertical, 0.5f);

      //limit movement to be inside view of camera
      if (Mathf.Abs(transform.position.x + horizontal) > maxHorizontal){
        horizontal = 0;
      }
      if (Mathf.Abs(transform.position.y + vertical - initial_y) > maxVertical){
        vertical = 0;
      }

      //create movement vector
      m_Movement.Set(horizontal, vertical, 0f);

      //move player object position
      transform.position += (m_Movement * movementSpeed * Time.deltaTime);


      //rotate the player as they move
      transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDirection), Mathf.Deg2Rad * 50f);
    }
}
