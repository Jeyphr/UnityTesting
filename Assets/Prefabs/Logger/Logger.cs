using UnityEngine;

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
    public void Log(string message)
    {
        Debug.Log(message);
    }

    // ------------------------------------------------------
    #region Delegates and Events
    public delegate void LogEventHandler(string message);
    public event LogEventHandler OnLog;
    #endregion

    
}
