using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The game over message
/// </summary>
public class GameOverMessage : MonoBehaviour
{
    [SerializeField] Text messageText;

	void Start()
	{
        // pause the game when added to the scene
        Time.timeScale = 0;
    }

    public void SetScore(int score)
    {
        messageText.text = "GAME OVER!\n\nYOUR SCORE: " + score;
    }

    public void HandleQuitButtonClicked()
    {
        // unpause game, destroy menu, and go to main menu
        AudioManager.Play(AudioClipName.ButtonClicked);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
