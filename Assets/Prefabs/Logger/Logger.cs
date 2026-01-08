using System;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Singleton Logger class for managing and logging game events and states.
/// This class provides a centralized way to log messages and maintain references
/// to important game components.
/// 
/// There can be multiple of the same type of class that use the logger, but only one
/// Logger instance should exist at any time.
/// 
/// If a class is null, the logger should not attempt to log anything about it, other than
/// that it is null, but it should continue to log other classes that are not null.
/// </summary>

public class Logger : MonoBehaviour
{
    //singleton instance
    private static Logger _instance;
    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject loggerObject = new GameObject("Logger");
                _instance = loggerObject.AddComponent<Logger>();
                DontDestroyOnLoad(loggerObject);
            }
            return _instance;
        }
    }
    // ------------------------------------------------------
    #region Properties
    [SerializeField] public bool enableLogging = true;

    // Object References
    [Header("Singleton Object References")]
    [SerializeField] public VitalityUIManager VitalityUIManager;
    [SerializeField] public InputHandler InputHandler;
    [SerializeField] public MovementHandler MovementHandler;
    [SerializeField] public TokenItemiser TokenItemiser;

    [Header("--------------------------------")]
    [Header("Non-Singleton Object References")]
    [SerializeField] public Vitality[] classList;
    [SerializeField] public Ticker[] Tickers;
    [SerializeField] public Bloodloss[] BloodlossScripts;
    
    // ------------------------------------------------------
    // Private Variables
    private int logCount = 1;
    #endregion



    #region Methods
    // ------------------------------------------------------
    // Logging Method
    private void Log(string message)
    {
        if (!enableLogging) return;
        Debug.Log($"[Log #{logCount}]: {message}");
        logCount++;
    }

    // ------------------------------------------------------
    // find all objects of a given class in a scene
    [System.Obsolete]
    public T[] FindAllObjectsOfType<T>() where T : MonoBehaviour
    {
        return FindObjectsOfType<T>();
    }

    // ------------------------------------------------------
    /// <summary>
    /// There are going to be multiple of the same class that use the logger, but only one
    /// Logger instance should exist at any time.
    /// 
    /// If a class is null, the logger should not attempt to log anything about it, other than
    /// that it is null, but it should continue to log other classes that are not null
    /// 
    /// This method should find all instances of the same class and subscribe their "onLogDetails"
    /// method to the logger's log event.
    /// 
    /// If the class is null, it should log that the class is null and continue.
    /// </summary>
    [System.Obsolete]
    public void RegisterLoggers(Type classType)
    {
        if (!enableLogging) return;

        // Vitality Loggers
        
        foreach (var classObject in classList)
        {
            if (classObject != null)
            {
                classObject.onLogDetails += Log;
                Log($"Registered {classObject.GetType().Name} Logger for {classObject.gameObject.name}");
            }
            else
            {
                Log("Vitality instance is null, skipping registration.");
            }
        }
    }


    #endregion

    // ------------------------------------------------------
    #region Delegates and Events
    void OnEnable()
    {
        if (!enableLogging) return;
        Log("Logger Enabled.");

        
    }
    #endregion
}
