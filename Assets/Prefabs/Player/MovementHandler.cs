using UnityEngine;


public class MovementHandler : MonoBehaviour
{
    #region Properties
    //floats
    private float movementSpeed { get; set; }
    private float horizontalLookSensitivity { get; set; }
    private float verticalLookSensitivity { get; set; }

    //bools
    private bool updateMovement { get; set; }
    private bool updateCamera { get; set; }

    //constants
    private const float gravity = 9.82f;
    private const float interactionRange = 4f;


    //object references
    private CharacterController playerController;
    private Camera playerCamera;

    #endregion



    #region Main Methods
    // Update is called once per frame
    public void Update()
    {
        UpdateMovement();
        UpdateCamera();
        UpdateGravity();
        UpdateInteraction();
    }
    #endregion



    #region Update Methods
    public void UpdateMovement()
    {
        if (!updateMovement) return;
    }
    public void UpdateCamera()
    {
        if (!updateCamera) return;
    }
    public void UpdateGravity()
    {
        if (!updateMovement) return;
    }
    public void UpdateInteraction()
    {
        if (!updateMovement) return;
    }
    #endregion



    #region Events and Delegates
    // Use this to both subscribe and unsubscribe from events, and add events to change movement settings
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
