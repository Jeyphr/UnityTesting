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
    private ConsoleLogger consoleLogger;
    #endregion


    #region Unity Methods
    // ----------------------------------------------------------
    private void Awake()
    {
        consoleLogger = FindFirstObjectByType<ConsoleLogger>();
    }
    #endregion

    #region Methods
    // ----------------------------------------------------------
    #endregion



    #region Events and Delegates
    public delegate void LogDetails(string message);
    public event LogDetails onLogDetails;
    #endregion
}