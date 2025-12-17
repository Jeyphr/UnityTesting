using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Properties
    //floats

    #endregion



    #region Main Methods
    // Unity Methods
    void Update()
    {
        
    }
    void Start()
    {
        
    }
    #endregion



    #region Update Methods
    // Custom Update Methods

    #endregion



    #region Events and Delegates
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
    // --------------------------------------
    public delegate void LogDetails(string message);
    public event LogDetails onLogDetails;
    
    #endregion
}
