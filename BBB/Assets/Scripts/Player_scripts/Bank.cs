using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    //Script for barrel rolls

    public float barrelRoll_duration = 0.25f;

    private float bankAxis;
    //private Quaternion originalRotation;
    //private Quaternion goalRotation;
    private float t;

    private Vector3 initialRotation;
    private Vector3 goalRotation;
    private Vector3 currentRotation;

    //public barrel roll state
    public static bool inBarrelRoll;

    void Start()
    {
        inBarrelRoll = false;
    }

    void Update()
    {
        if (!inBarrelRoll)
        {
          bankAxis = Input.GetAxis("Bank");


          if(bankAxis < 0.0f)
          {
              //barrelRollEffect.Play();
              StartCoroutine("BarrelRollLeft");
          }
          else if(bankAxis > 0.0f)
          {
              //barrelRollEffect.Play();
              StartCoroutine("BarrelRollRight");
          }

        }
    }

    IEnumerator BarrelRollLeft()
    {
        inBarrelRoll = true;

        t = 0.0f;
        initialRotation = transform.localRotation.eulerAngles;
        goalRotation = initialRotation;
        goalRotation.z += 180.0f;

        currentRotation = initialRotation;

        while(t < barrelRoll_duration/2.0f)
        {
            currentRotation.z = Mathf.Lerp(initialRotation.z,goalRotation.z,t/(barrelRoll_duration/2.0f));
            transform.localRotation = Quaternion.Euler(currentRotation);
            t += Time.deltaTime;
            yield return null;
        }

        t = 0.0f;
        initialRotation = transform.localRotation.eulerAngles;
        goalRotation = initialRotation;
        goalRotation.z += 180.0f ;

        while(t < barrelRoll_duration/2.0f)
        {
            currentRotation.z = Mathf.Lerp(initialRotation.z,goalRotation.z,t/(barrelRoll_duration/2.0f));
            transform.localRotation = Quaternion.Euler(currentRotation);
            t += Time.deltaTime;
            yield return null;
        }

        inBarrelRoll = false;

        transform.localRotation = Quaternion.identity;
    }

    IEnumerator BarrelRollRight()
    {
        inBarrelRoll = true;


        t = 0.0f;
        initialRotation = transform.localRotation.eulerAngles;
        goalRotation = initialRotation;
        goalRotation.z -= 180.0f;

        currentRotation = initialRotation;

        while(t < barrelRoll_duration/2.0f)
        {
            currentRotation.z = Mathf.Lerp(initialRotation.z,goalRotation.z,t/(barrelRoll_duration/2.0f));
            transform.localRotation = Quaternion.Euler(currentRotation);
            t += Time.deltaTime;
            yield return null;
        }

        t = 0.0f;
        initialRotation = transform.localRotation.eulerAngles;
        goalRotation = initialRotation;
        goalRotation.z -= 180.0f ;

        while(t < barrelRoll_duration/2.0f)
        {
            currentRotation.z = Mathf.Lerp(initialRotation.z,goalRotation.z,t/(barrelRoll_duration/2.0f));
            transform.localRotation = Quaternion.Euler(currentRotation);
            t += Time.deltaTime;
            yield return null;
        }

        inBarrelRoll = false;

        transform.localRotation = Quaternion.identity;
    }
}
