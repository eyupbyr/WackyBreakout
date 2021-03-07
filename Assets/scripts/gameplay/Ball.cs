using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    Timer deathTimer;
    Timer moveTimer;

    //speedup effect support
    Rigidbody2D rgbd2D;
    Timer speedupTimer;
    float speedupFactor;

    //ball lost support
    BallLost ballLost;

    // Start is called before the first frame update
    void Start()
    {
        ballLost = new BallLost();
        EventManager.AddBallsLostInvoker(this);

        //give 1 second to player to prepare for the next ball
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();

        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeTime;
        deathTimer.Run();

        // speedup effect support
        speedupTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedupEffectListener(HandleSpeedupEffectActivatedEvent);
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathTimer.Finished)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }

        if (moveTimer.Finished)
        {
            moveTimer.Stop();
            MoveBall();
            /*
            float angle = -90 * Mathf.Deg2Rad;
            Vector2 force = new Vector2(
                ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
                ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
            GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);*/
        }

        if (speedupTimer.Finished)
        {
            speedupTimer.Stop();
            rgbd2D.velocity *= 1 / speedupFactor;
        }
    }

    /// <summary>
    /// Starts the ball moving
    /// </summary>
    void MoveBall()
    {
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
                                    ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));

        //change force if speedup effect is active
        if (EffectUtils.SpeedupEffectActive)
        {
            this.speedupFactor = EffectUtils.SpeedupFactor;
            speedupTimer.Duration = EffectUtils.SpeedupEffectSecondsLeft;
            speedupTimer.Run();
            force *= speedupFactor;
        }

        GetComponent<Rigidbody2D>().AddForce(force);
    }

    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        float speed = rb2D.velocity.magnitude;
        rb2D.velocity = direction * speed;
    }

    void OnBecameInvisible()
    {
        if (!deathTimer.Finished)
        {
            //spawn a new ball if the ball is below screen (this is to prevent spawning a ball when we stop the game)
            float halfColliderHeight =
                gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom)
                Camera.main.GetComponent<BallSpawner>().SpawnBall();
           
            Destroy(gameObject);
            ballLost.Invoke();
        }
    }

    /// <summary>
    /// Handles the speedup effect activated event
    /// </summary>
    void HandleSpeedupEffectActivatedEvent(float duration, float speedupFactor)
    {
        if (!speedupTimer.Running)
        {
            this.speedupFactor = speedupFactor;
            speedupTimer.Duration = duration;
            speedupTimer.Run();
            rgbd2D.velocity *= speedupFactor;
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }

    public void AddBallsLostListener(UnityAction listener)
    {
        ballLost.AddListener(listener);
    }
}
