using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static int score = 0;
    static Text scoreText;

    static Text ballsLeftText;
    static int ballsLeft;

    LastBallLost lastBallLost;

    public int Score
    {
        get { return score; }
    }


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();

        ballsLeft = ConfigurationUtils.BallsPerGame;
        ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeft").GetComponent<Text>();
        ballsLeftText.text = "Balls Left: " + ballsLeft;

        EventManager.AddPointsAddedListener(AddPoints);
        EventManager.AddBallsLostListener(ReduceBallsLeft);

        lastBallLost = new LastBallLost();
        EventManager.AddLastBallLostInvoker(this);
    }

    void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }

    void ReduceBallsLeft()
    {
        ballsLeft--;
        ballsLeftText.text = "Balls Left: " + ballsLeft.ToString();
        if (ballsLeft == 0)
        {
            lastBallLost.Invoke();
        }
    }


    public void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLost.AddListener(listener);
    }
}
