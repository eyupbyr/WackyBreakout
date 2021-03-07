using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked);
        Application.Quit();
    }

    public void HandleHelpButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked);
        MenuManager.GoToMenu(MenuName.Help);
    }

    public void HandlePlayButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked);
        SceneManager.LoadScene("Gameplay");
    }
}
