using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.InteropServices;
using UnityEngine.Experimental.GlobalIllumination;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 15;
    static float ballImpulseForce = 250;
    static float ballLifeTime = 15;
    static float minSpawnTime = 10;
    static float maxSpawnTime = 15;
    static int standardBlockPoints = 10;
    static int bonusBlockPoints = 20;
    static int pickupBlockPoints = 50;
    static float standardBlockProbability = 0.7f;
    static float bonusBlockProbability = 0.2f;
    static float freezerBlockProbability = 0.05f;
    static float speedupBlockProbability = 0.05f;
    static int ballsPerGame = 15;
    static float freezerEffectDuration = 2;
    static float speedupEffectFactor = 2;
    static float speedupEffectDuration = 3;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the lifetime of the ball to determine when will the ball destroy itself
    /// </summary>
    public float BallLifeTime
    {
        get { return ballLifeTime; }
    }

    /// <summary>
    /// min spawn time in seconds for the next ball
    /// </summary>
    public float MinSpawnTime 
    {
        get { return minSpawnTime; }
    }

    /// <summary>
    /// max spawn time in seconds for the next ball
    /// </summary>
    public float MaxSpawnTime
    {
        get { return maxSpawnTime; }
    }

    public int StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }

    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    public int PickupBlockPoints
    {
        get { return pickupBlockPoints; }
    }

    /// <summary>
    /// probability that a standard block will be added to the level
    /// </summary>
    public float StandardBlockProbability
    {
        get { return standardBlockProbability; }
    }

    /// <summary>
    /// probability that a bonus block will be added to the level
    /// </summary>
    public float BonusBlockProbability
    {
        get { return bonusBlockProbability; }
    }

    /// <summary>
    /// probability that a freezer block will be added to the level
    /// </summary>
    public float FreezerBlockProbability
    {
        get { return freezerBlockProbability; }
    }

    /// <summary>
    /// probability that a speedup block will be added to the level
    /// </summary>
    public float SpeedupBlockProbability
    {
        get { return speedupBlockProbability; }
    }

    public int BallsPerGame
    {
        get { return ballsPerGame; }
    }

    /// <summary>
    /// duration of the freezer effect(in seconds)
    /// </summary>
    public float FreezerEffectDuration 
    {
        get { return freezerEffectDuration; }
    }

    public float SpeedupEffectFactor
    {
        get { return speedupEffectFactor; }
    }

    public float SpeedupEffectDuration
    {
        get { return speedupEffectDuration; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader file = null;
        try
        {
            file = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            //read the data
            string names = file.ReadLine();
            string values = file.ReadLine();

            SetConfigurationDataFields(values);
        }
        catch(Exception)
        {}
        finally
        {
            if(file != null)
            {
                file.Close();
            }
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Sets the ConfigurationData fields
    /// </summary>
    /// <param name="csvValues"></param>
    void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeTime = float.Parse(values[2]);
        minSpawnTime = float.Parse(values[3]);
        maxSpawnTime = float.Parse(values[4]);
        standardBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
        pickupBlockPoints = int.Parse(values[7]);
        standardBlockProbability = float.Parse(values[8]) / 100;
        bonusBlockProbability = float.Parse(values[9]) / 100;
        freezerBlockProbability = float.Parse(values[10]) / 100;
        speedupBlockProbability = float.Parse(values[11]) / 100;
        ballsPerGame = int.Parse(values[12]);
        freezerEffectDuration = float.Parse(values[13]);
        speedupEffectFactor = float.Parse(values[14]) - 0.5f; //not an appropriate solution FIX THIS
        speedupEffectDuration = float.Parse(values[15]);
    }

    #endregion
}
