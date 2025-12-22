using UnityEditor.VersionControl;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    #region Properties
    //floats
    [Header("Movement / Camera Statistics")]
    [SerializeField] public float movementSpeed = 5f;
    [SerializeField] public float jumpHeight    = 2f;
    [SerializeField] public float horizontalLookSensitivity = 2f;
    [SerializeField] public float verticalLookSensitivity   = 2f;

    //bools
    [Header("Settings")]
    [SerializeField] public bool updateMovement = true;
    [SerializeField] public bool updateCamera = true;
    [SerializeField] public bool logMovementDetails;

    //constants
    private const float gravity = 9.82f;
    private const float interactionRange = 4f;


    //object references
    [Header("Object References")]
    [SerializeField] public CharacterController playerController;
    [SerializeField] public Camera playerCamera;
    [SerializeField] public InputHandler inputHandler;
    private Vector3 movementDirection;

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
    public void Awake()
    {
        // Logging
        if (logMovementDetails) {onLogDetails?.Invoke("MovementHandler Awake called.");}
        LockMouse(true);
    }
    
    #endregion


    // ------------------------------------------------------
    #region Update Methods
    public void UpdateMovement()
    {
        if (!updateMovement) return;

        Vector3 move = new Vector3(InputHandler.Instance.MoveInput.x, 0, InputHandler.Instance.MoveInput.y);
        move = playerCamera.transform.TransformDirection(move);
        move.y = 0f;
        move.Normalize();
        playerController.Move(move * movementSpeed * Time.deltaTime);
    }

    public void UpdateCamera()
    {
        if (!updateCamera) return;

        float mouseX = inputHandler.LookInput.x * horizontalLookSensitivity;
        float mouseY = inputHandler.LookInput.y * verticalLookSensitivity;

        // Rotate the player horizontally
        transform.Rotate(0, mouseX, 0);

        // Rotate the camera vertically
        float desiredCameraXRotation = playerCamera.transform.localEulerAngles.x - mouseY;
        if (desiredCameraXRotation > 180) desiredCameraXRotation -= 360; // Convert to -180 to 180 range
        desiredCameraXRotation = Mathf.Clamp(desiredCameraXRotation, -90f, 90f);
        playerCamera.transform.localEulerAngles = new Vector3(desiredCameraXRotation, 0, 0);
    }

    public void UpdateJumping()
    {
        if (!updateMovement) return;
        if (playerController.isGrounded)
        {
            // Reset vertical movement when grounded
            movementDirection.y = -0.5f;
            if (inputHandler.IsJumping)
            {
                movementDirection.y = jumpHeight;
                
                // Logging
                if (logMovementDetails) {onLogDetails?.Invoke("Player jumped.");}
            }
        }
        else
        {
            // Apply gravity when not grounded
            movementDirection.y -= gravity * Time.deltaTime;
        }
        playerController.Move(movementDirection * Time.deltaTime);
    }
    public void UpdateInteraction()
    {
        if (!updateMovement) return;
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            if(logMovementDetails) {onLogDetails?.Invoke("Interacting with " + hit.collider.name); }

        }

    }
    #endregion


    // ------------------------------------------------------
    #region Mouse Control
    public void LockMouse(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
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
