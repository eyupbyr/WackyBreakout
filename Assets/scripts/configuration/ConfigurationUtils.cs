﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configurationData;

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallLifeTime
    {
        get { return configurationData.BallLifeTime;  }
    }

    public static float MinSpawnTime
    { 
        get { return configurationData.MinSpawnTime; } 
    }

    public static float MaxSpawnTime
    {
        get { return configurationData.MaxSpawnTime; }
    }

    public static int StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }

    public static int BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }

    public static int PickupBlockPoints
    {
        get { return configurationData.PickupBlockPoints; }
    }

    public static float StandardBlockProbability
    {
        get { return configurationData.StandardBlockProbability; }
    }

    public static float BonusBlockProbability
    {
        get { return configurationData.BonusBlockProbability; }
    }

    public static float FreezerBlockProbability
    {
        get { return configurationData.FreezerBlockProbability; }
    }

    public static float SpeedupBlockProbability
    {
        get { return configurationData.SpeedupBlockProbability; }
    }

    public static int BallsPerGame
    {
        get { return configurationData.BallsPerGame; }
    }

    public static float FreezerEffectDuration
    {
        get { return configurationData.FreezerEffectDuration; }
    }

    public static float SpeedupEffectFactor
    {
        get { return configurationData.SpeedupEffectFactor; }
    }

    public static float SpeedupEffectDuration
    {
        get { return configurationData.SpeedupEffectDuration; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
