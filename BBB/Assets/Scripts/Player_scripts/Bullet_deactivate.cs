using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_deactivate : MonoBehaviour
{
  void Start()
  {
      StartCoroutine(DeactivateInTime());
  }

  IEnumerator DeactivateInTime()
  {
      yield return new WaitForSeconds(1.5f);
      Destroy(gameObject);
  }

  private void OnTriggerEnter(Collider other)
  {
      Destroy(gameObject);
  }
}
