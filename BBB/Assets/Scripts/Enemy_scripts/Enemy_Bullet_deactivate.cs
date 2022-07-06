using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_deactivate : MonoBehaviour
{
  void FixedUpdate()
  {
      //destroy if boss is defeated
      if (GameManager.levelWon)
      {
          Destroy(gameObject);
      }
  }
  private void OnTriggerEnter(Collider other)
  {
    //destory on collision with player
    if (other.gameObject.CompareTag("Player"))
    {
        Destroy(gameObject);
    }

  }
}
