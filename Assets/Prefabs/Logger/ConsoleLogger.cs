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
    //singleton instance
    private static ConsoleLogger _instance;
    public static ConsoleLogger Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject loggerObject = new GameObject("ConsoleLogger");
                _instance = loggerObject.AddComponent<ConsoleLogger>();
                DontDestroyOnLoad(loggerObject);
            }
            return _instance;
        }
    }



    #region Properties
    // ------------------------------------------------------
    [Header("Logger Settings")]
    [SerializeField] public bool enableLogging = true;

    [Header("Object References")]
    [SerializeField] private LogToken[] logTokens = new LogToken[0];
    
    // ------------------------------------------------------
    // Private Variables
    #endregion



    #region Methods
    // ------------------------------------------------------
    // Add a new Log token to the array
    public void AddLogToken(LogToken logToken)
    {
        Array.Resize(ref logTokens, logTokens.Length + 1);
        logTokens[logTokens.Length - 1] = logToken;
    }

    // ------------------------------------------------------
    // Log all tokens to the console
    public void LogAllTokens()
    {
        if (!enableLogging) return;
        if (logTokens.Length == 0 || logTokens == null) return;

        foreach (LogToken token in logTokens)
        {
            Debug.Log(token.ToString());
        }
    }
    #endregion
}
