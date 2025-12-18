using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    #region Properties
    //Objects
    public static InputHandler Instance { get; private set; }
    public InputActionAsset playerControls;

    //Actions
    public string actionMapName = "Player";
    public string move = "Move";
    public string look = "Look";
    public string jump = "Jump";
    public string paused = "Pause";

    //InputActions
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction pauseAction;

    //Vectors
    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }


    //floats


    //Bools
    [SerializeField] public bool logInputDetails { get; set; }
    public bool IsJumping { get; private set; }

    #endregion



    #region Main Methods
    // Unity Methods
    void Update()
    {
        
    }
    void Awake()
    {
        if (logInputDetails)
        {
            onLogDetails?.Invoke("InputHandler Awake called.");
        }
        //Singleton Stuff
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        lookAction = playerControls.FindActionMap(actionMapName).FindAction(look);
        jumpAction = playerControls.FindActionMap(actionMapName).FindAction(jump);
        pauseAction = playerControls.FindActionMap(actionMapName).FindAction(paused);
        
        RegisterInputActions();
    }

    #endregion



    #region Register Methods
    // Custom Register Methods
    public void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;
        lookAction.canceled += context => LookInput = Vector2.zero;

        jumpAction.performed += context => IsJumping = true;
        pauseAction.performed += context => 
        {
            if (logInputDetails && onLogDetails != null)
            {
                onLogDetails.Invoke("Pause Pressed");
            }
        };

        jumpAction.canceled += context => IsJumping = false;
    }
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
