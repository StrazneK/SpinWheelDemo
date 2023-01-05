using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinButton : MonoBehaviour
{
	GameManager gameManager;
    private void Start()
    {
		gameManager = GameManager.instance;
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(ButtonClicked); //Button click event with code.
	}

	public void ButtonClicked()
	{
		if (gameManager.gameState == GameManager.GameState.Resume) //We prevent the button from being pressed while the game is stopped
		{
			Spin.instance.StartSpin();
			gameManager.gameState = GameManager.GameState.Pause;
		}
	}
}
