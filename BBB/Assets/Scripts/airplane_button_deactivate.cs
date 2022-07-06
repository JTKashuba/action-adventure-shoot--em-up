using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class airplane_button_deactivate : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
        GetComponent<Button>().interactable = GameManager.planeUnlocked;
  }
}
