using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game manager
/// </summary>
public class WackyBreakout : MonoBehaviour
{
    void Start()
    {
        EventManager.AddLastBallLostListener(HandleLastBallLost);
        EventManager.AddLastBlockDestroyedListener(HandleLastBlockDestroyed);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // pause game on escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    void HandleLastBallLost()
    {
        //AudioManager.Play(AudioClipName.GameLost);
        GameOver();
    }

    void HandleLastBlockDestroyed()
    {
        Destroy(GameObject.FindGameObjectWithTag("Block"));
        GameOver();
    }

    void GameOver()
    {
        // instantiate prefab and set score
        GameObject gameOverMessage = Instantiate(Resources.Load("GameOverMessage")) as GameObject;
        GameOverMessage gameOverMessageScript = gameOverMessage.GetComponent<GameOverMessage>();
        GameObject hud = GameObject.FindGameObjectWithTag("HUD");
        HUD hudScript = hud.GetComponent<HUD>();
        gameOverMessageScript.SetScore(hudScript.Score);
    }
}
