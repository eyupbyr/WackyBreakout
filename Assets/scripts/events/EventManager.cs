using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    //FreezerEffectActivated support
    static List<PickupBlock> freezerEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerEffectListeners = new List<UnityAction<float>>();

    //SpeedupEffectActivated support
    static List<PickupBlock> speedupEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float, float>> speedupEffectListeners = new List<UnityAction<float, float>>();

    //PointsAdded support
    static List<Block> pointsAddedInvokers = new List<Block>();
    static List<UnityAction<int>> pointsAddedListeners = new List<UnityAction<int>>();

    //BallLost support
    static List<Ball> ballsLostInvokers = new List<Ball>();
    static List<UnityAction> ballsLostListeners = new List<UnityAction>();

    // LastBallLost support
    static List<HUD> lastBallLostInvokers = new List<HUD>();
    static List<UnityAction> lastBallLostListeners = new List<UnityAction>();

    // BlockDestroyed support
    static List<Block> lastBlockDestroyedInvokers = new List<Block>();
    static List<UnityAction> lastBlockDestroyedListeners = new List<UnityAction>();

    #region Public methods

    // <summary>
    /// Adds the given script as a freezer effect invoker
    /// </summary>
    public static void AddFreezerEffectInvoker(PickupBlock invoker)
    {
        freezerEffectInvokers.Add(invoker);
        foreach(UnityAction<float> listener in freezerEffectListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a freezer effect listener
    /// </summary>
    public static void AddFrezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectListeners.Add(listener);
        foreach(PickupBlock invoker in freezerEffectInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a speedup effect invoker
    /// </summary>
    public static void AddSpeedupEffectInvoker(PickupBlock invoker)
    {
        // add invoker to list and add all listeners to invoker
        speedupEffectInvokers.Add(invoker);
        foreach (UnityAction<float, float> listener in speedupEffectListeners)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a speedup effect listener
    /// </summary>
    public static void AddSpeedupEffectListener(UnityAction<float, float> listener)
    {
        // add listener to list and to all invokers
        speedupEffectListeners.Add(listener);
        foreach (PickupBlock invoker in speedupEffectInvokers)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a points added invoker
    /// </summary>
    public static void AddPointsAddedInvoker(Block invoker)
    {
        pointsAddedInvokers.Add(invoker);
        foreach(UnityAction<int> listener in pointsAddedListeners)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a points added listener
    /// </summary>
    public static void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsAddedListeners.Add(listener);
        foreach(Block invoker in pointsAddedInvokers)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a balls lost invoker
    /// </summary>
    public static void AddBallsLostInvoker(Ball invoker)
    {
        ballsLostInvokers.Add(invoker);
        foreach(UnityAction listener in ballsLostListeners)
        {
            invoker.AddBallsLostListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a balls lost listener
    /// </summary>
    public static void AddBallsLostListener(UnityAction listener)
    {
        ballsLostListeners.Add(listener);
        foreach(Ball invoker in ballsLostInvokers)
        {
            invoker.AddBallsLostListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a last ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddLastBallLostInvoker(HUD invoker)
    {
        // add invoker to list and add all listeners to invoker
        lastBallLostInvokers.Add(invoker);
        foreach (UnityAction listener in lastBallLostListeners)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a last ball lost listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddLastBallLostListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        lastBallLostListeners.Add(listener);
        foreach (HUD invoker in lastBallLostInvokers)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a last block destroyed invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddLastBlockDestroyedInvoker(Block invoker)
    {
        // add invoker to list and add all listeners to invoker
        lastBlockDestroyedInvokers.Add(invoker);
        foreach (UnityAction listener in lastBlockDestroyedListeners)
        {
            invoker.AddLastBlockDestroyedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a last block destroyed listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddLastBlockDestroyedListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        lastBlockDestroyedListeners.Add(listener);
        foreach (Block invoker in lastBlockDestroyedInvokers)
        {
            invoker.AddLastBlockDestroyedListener(listener);
        }
    }


    #endregion
}
