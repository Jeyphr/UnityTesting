using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Properties
    //floats
    //Bools
    [SerializeField] public bool logInputDetails { get; set; }

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
        if(logInputDetails) {onLogDetails?.Invoke("InputHandler Enabled.");}
        
    }
    private void OnDisable()
    {
        
    }
    // --------------------------------------
    public delegate void LogDetails(string message);
    public event LogDetails onLogDetails;

    #endregion
}
