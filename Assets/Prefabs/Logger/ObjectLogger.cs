using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

/// <summary>
/// This is the logger that speaks to the console logger whenever a script
/// wants to log something about itself.
/// </summary>
public class ObjectLogger : MonoBehaviour
{
    #region Properties
    // ----------------------------------------------------------
    // Object References
    private ConsoleLogger clogger;
    #endregion


    #region Unity Methods
    // ----------------------------------------------------------
    // Find the ConsoleLogger in the scene
    private void Awake()
    {
        clogger = FindFirstObjectByType<ConsoleLogger>();
    }
    #endregion



    #region Methods
    // ----------------------------------------------------------
    // Push message to Console Logger
    

    #endregion



    #region Events and Delegates
    // ----------------------------------------------------------
    // Delegate for logging details
    public delegate void LogDetails(string message);
    public event LogDetails onLogDetails;
    #endregion
}