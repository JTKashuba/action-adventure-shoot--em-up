using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
	public Text buttonText;

	public void NewText()
	{
		buttonText.text = "W Key: Up  -  S Key: Down";
	}
}
