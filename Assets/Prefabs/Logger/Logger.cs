using Unity.VisualScripting;
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
    // ------------------------------------------------------
    #region Properties
    [SerializeField] public bool enableLogging = true;

    // Object References
    [SerializeField] public Vitality Vitality;
    [SerializeField] public VitalityUIManager VitalityUIManager;
    [SerializeField] public InputHandler InputHandler;
    [SerializeField] public MovementHandler MovementHandler;
    [SerializeField] public TokenItemiser TokenItemiser;
    
    // ------------------------------------------------------
    // Private Variables
    private int logCount = 1;
    #endregion



    // ------------------------------------------------------
    #region Methods
    private void Log(string message)
    {
        if (!enableLogging) return;
        Debug.Log($"[Log #{logCount}]: {message}");
        logCount++;
    }   
    #endregion

    // ------------------------------------------------------
    #region Delegates and Events
    void OnEnable()
    {
        if (!enableLogging) return;
        Log("Logger Enabled.");

        if (Vitality == null) { Debug.LogError("Vitality component is null in Logger"); return; }
        Vitality.onLogDetails += Log;

        if (VitalityUIManager == null) { Debug.LogError("VitalityUIManager component is null in Logger"); return; }
        VitalityUIManager.onLogDetails += Log;

        if (InputHandler == null) { Debug.LogError("InputHandler component is null in Logger"); return; }
        InputHandler.onLogDetails += Log;

        if (MovementHandler == null) { Debug.LogError("MovementHandler component is null in Logger"); return; }
        MovementHandler.onLogDetails += Log;

        if (TokenItemiser == null) { Debug.LogError("TokenItemiser component is null in Logger"); return; }
        TokenItemiser.onLogDetails += Log;
    }
    #endregion


}
