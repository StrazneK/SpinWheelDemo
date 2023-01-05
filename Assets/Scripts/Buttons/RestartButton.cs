using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
	private void Start()
	{
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(ButtonClicked); //Button click event with code.
	}

	void ButtonClicked()
	{
		GameManager.instance.RestartGame();
	}
}
