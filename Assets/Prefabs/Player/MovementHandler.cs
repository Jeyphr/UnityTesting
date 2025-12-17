using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    #region Properties
    //floats
    [SerializeField] public float movementSpeed { get; set; }
    [SerializeField] public float jumpHeight { get; set; }
    [SerializeField] public float horizontalLookSensitivity { get; set; }
    [SerializeField] public float verticalLookSensitivity { get; set; }

    //bools
    [SerializeField] public bool updateMovement { get; set; }
    [SerializeField] public bool updateCamera { get; set; }
    [SerializeField] public bool logMovementDetails { get; set; }

    //constants
    private const float gravity = 9.82f;
    private const float interactionRange = 4f;


    //object references
    [SerializeField] public CharacterController playerController;
    [SerializeField] public Camera playerCamera;
     public Vector3 movementDirection;

    #endregion


    // ------------------------------------------------------
    #region Constructors
    public MovementHandler
    (
        CharacterController controller, 
        Camera camera, 
        float moveSpeed = 5f,
        float horizLookSens = 2f, 
        float vertLookSens = 2f
    )
    {
        this.playerController = controller;
        this.playerCamera = camera;
        this.movementSpeed = moveSpeed;
        this.horizontalLookSensitivity = horizLookSens;
        this.verticalLookSensitivity = vertLookSens;
        this.updateMovement = true;
        this.updateCamera = true;

        // Logging
        if (logMovementDetails) {onLogDetails?.Invoke("MovementHandler initialized.");}
    }
    #endregion


    // ------------------------------------------------------
    #region Main Methods
    // Update is called once per frame
    public void Update()
    {
        UpdateMovement();
        UpdateCamera();
        UpdateJumping();
        UpdateInteraction();
    }
    
    #endregion


    // ------------------------------------------------------
    #region Update Methods
    public void UpdateMovement()
    {
        if (!updateMovement) return;
        
    }
    public void UpdateCamera()
    {
        if (!updateCamera) return;
    }
    public void UpdateJumping()
    {
        if (!updateMovement) return;
        if (playerController.isGrounded)
        {
            // Reset vertical movement when grounded
            movementDirection.y = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                movementDirection.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
                
                // Logging
                if (logMovementDetails) {onLogDetails?.Invoke("Player jumped.");}
            }
        }
        else
        {
            // Apply gravity when not grounded
            movementDirection.y -= gravity * Time.deltaTime;
        }
    }
    public void UpdateInteraction()
    {
        if (!updateMovement) return;
    }
    #endregion


    // ------------------------------------------------------
    #region Events and Delegates
    // Use this to both subscribe and unsubscribe from events, and add events to change movement settings
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    // ------------------------------------------------------
    public delegate void LogDetails(string message);
    public event LogDetails onLogDetails;

    #endregion
}
