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

public class ConsoleLogger : MonoBehaviour
{
    // ------------------------------------------------------
    // Singleton Instance
    private static ConsoleLogger _instance;
    public static ConsoleLogger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<ConsoleLogger>();
                if (_instance == null)
                {
                    GameObject loggerObject = new GameObject("ConsoleLogger");
                    _instance = loggerObject.AddComponent<ConsoleLogger>();
                }
            }
            return _instance;
        }
    }

    #region Properties
    // ------------------------------------------------------
    [Header("Logger Settings")]
    [SerializeField] public bool enableLogging = true;

    [Header("Object References")]
    [SerializeField] private ObjectLogger[] oLoggers;
    
    // ------------------------------------------------------
    // Private Variables
    private int logCount = 1;
    #endregion



    #region Unity Methods    
    // ------------------------------------------------------
    private void Start()
    {
        RegisterObjectLoggers();
    }
    #endregion



    #region Methods
    // ------------------------------------------------------
    // Log a message to the console
    public void LogMessage(string message)
    {
        if (!enableLogging) return;
        Debug.Log($"[Log] #{logCount}: {message}");
        logCount++;
    }

    // ------------------------------------------------------
    // Register all ologgers in the scene
    public void RegisterObjectLoggers()
    {
        if (oLoggers.Length == 0 || oLoggers == null) Debug.LogWarning("No ObjectLoggers found to register.");

        foreach (var oLogger in oLoggers)
        {
            oLogger.onLogDetails += LogMessage;
            LogMessage($"Registered {oLogger.gameObject.name}");
        }
    }

    // ------------------------------------------------------
    // Unregister all ologgers in the scene
    public void UnregisterObjectLoggers()
    {
        if (oLoggers.Length == 0 || oLoggers == null) Debug.LogWarning("No ObjectLoggers found to unregister.");

        foreach (var oLogger in oLoggers)
        {
            oLogger.onLogDetails -= LogMessage;
            LogMessage($"Unregistered {oLogger.gameObject.name}");
        }
    }
    #endregion
}
