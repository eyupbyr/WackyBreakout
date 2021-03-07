using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void HandleBackButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
