using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    [SerializeField] Sprite freezerSprite;
    [SerializeField] Sprite speedupSprite;

    PickupEffect effect;
    float effectDuration;

    FreezerEffectActivated freezerEffectActivated;

    float speedupFactor;
    SpeedupEffectActivated speedupEffectActivated;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        points = ConfigurationUtils.PickupBlockPoints;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override protected void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            if(effect == PickupEffect.Freezer)
            {
                freezerEffectActivated.Invoke(effectDuration);
            }
            else if (effect == PickupEffect.Speedup)
            {
                speedupEffectActivated.Invoke(effectDuration, speedupFactor);
            }
            base.OnCollisionEnter2D(coll);
        }
    }

    /// <summary>
    /// Sets the effect for the pickup block
    /// </summary>
    public PickupEffect Effect
    {
        set
        {
            effect = value;
            
            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == PickupEffect.Freezer)
            {
                spriteRenderer.sprite = freezerSprite;
                effectDuration = ConfigurationUtils.FreezerEffectDuration;
                freezerEffectActivated = new FreezerEffectActivated();
                EventManager.AddFreezerEffectInvoker(this);
            }
            else
            {
                spriteRenderer.sprite = speedupSprite;
                effectDuration = ConfigurationUtils.SpeedupEffectDuration;
                speedupFactor = ConfigurationUtils.SpeedupEffectFactor;
                speedupEffectActivated = new SpeedupEffectActivated();
                EventManager.AddSpeedupEffectInvoker(this);
            }
        }
    }

    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivated.AddListener(listener);
    }

    public void AddSpeedupEffectListener(UnityAction<float,float> listener)
    {
        speedupEffectActivated.AddListener(listener);
    }
    
}
