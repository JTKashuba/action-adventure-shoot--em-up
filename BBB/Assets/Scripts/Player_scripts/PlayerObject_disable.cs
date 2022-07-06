using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject_disable : MonoBehaviour
{

  public GameObject[] playerobjects;
  private GameObject player;
  // Start is called before the first frame update
  void Start()
  {
      for (var i=0; i < 4; i++)
      {
          player = playerobjects[i];
          if (i == MainMenu.playerobject_number)
          {
              player.SetActive(true);
          }
          else
          {
              player.SetActive(false);
          }
      }
  }
}
