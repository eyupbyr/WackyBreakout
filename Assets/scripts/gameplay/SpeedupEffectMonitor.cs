using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    Timer speedupTimer;
    float speedupFactor;

    public bool IsSpeedUpEffectActive
    {
        get
        {
            return speedupTimer.Running;
        }
    }

    public float SpeedupEffectSecondsLeft
    {
        get
        {
            return speedupTimer.SecondsLeft;
        }
    }

    public float SpeedupFactor
    {
        get
        {
            return speedupFactor;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        speedupTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedupEffectListener(HandleSpeedupEffectActivatedEvent);
    }

    // Update is called once per frame
    void Update()
    {
        if (speedupTimer.Finished)
        {
            speedupTimer.Stop();
            speedupFactor = 1;
        }
    }

    void HandleSpeedupEffectActivatedEvent(float duration, float speedupFactor)
    {
        if (!speedupTimer.Running)
        {
            this.speedupFactor = speedupFactor;
            speedupTimer.Duration = duration;
            speedupTimer.Run();
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }
}
