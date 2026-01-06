using UnityEngine;

public class Bloodloss : MonoBehaviour
{
    /// <summary>
    /// Imagine the player's health bar as a large plastic bag, filled with red liquid (representing blood).
    /// When the player gets injured, it's like poking holes in that bag. The bigger the injury, the bigger 
    /// the hole, and the faster the red liquid leaks out. If too much liquid leaks out, the player dies.
    /// 
    /// The bag can have many holes at once, each representing a different injury. Some holes might be small 
    /// and leak slowly, while others are large and leak quickly. The total blood loss rate is the sum of all 
    /// these leaks.
    /// 
    /// Injury Tokens represent these holes. Each token has a severity level, which determines how big the hole is 
    /// and how fast it leaks blood. More severe injuries cause faster blood loss.
    /// </summary>

    #region Properties
    //----------------------------------------------------------
    [Header("Bloodloss Settings")]
    [SerializeField] public bool enableLogging;
    [SerializeField] public float maxBlood = 1000f; // Maximum Blood volume
    [SerializeField] public float currentBlood = 1000f; // Current Blood volume

    [Header("Object References")]
    [SerializeField] public Ticker bloodlossTicker;
    
    // Private Fields
    private InjuryToken[] injuryTokens = new InjuryToken[0];
    private MovementHandler movementHandler;
    #endregion



    #region Unity Methods
    // ----------------------------------------------------------
    private void Awake()
    {
        movementHandler = FindFirstObjectByType<MovementHandler>();
    }

    // ----------------------------------------------------------
    private void Start()
    {
        bloodlossTicker.onTick += LoseBlood;
        
        Ouch(new InjuryToken("Laceration", InjuryType.Cut, Limb.Arm, 8f, 0.3f));
        Ouch(new InjuryToken("Puncture Wound", InjuryType.Puncture, Limb.Leg, 10f, 1.5f));
        Ouch(new InjuryToken("Deep Cut", InjuryType.Cut, Limb.Leg, 6f, 2.0f));

        bloodlossTicker.StartTicker();
    }

    // ----------------------------------------------------------
    private void Update()
    {
        
    }
    #endregion



    #region Methods
    // ----------------------------------------------------------
    // Calculate total blood loss rate based on active injury tokens
    private double CalculateBloodLossRate()
    {
        double totalLossRate = 0f;

        //check to see if there are injury tokens
        if (injuryTokens == null || injuryTokens.Length == 0) { return totalLossRate; }

        foreach (InjuryToken token in injuryTokens)
        {
            totalLossRate += (token.lossAmount * token.injuryLevel);
        }

        if (enableLogging)
        {
            onLogDetails?.Invoke($"Total Blood Loss Rate calculated: {totalLossRate} units/sec");
        }

        return totalLossRate;
    }

    // ----------------------------------------------------------
    // Apply blood loss over time
    private void LoseBlood()
    {
        double lossRate = CalculateBloodLossRate();
        currentBlood -= (float)(lossRate * bloodlossTicker.tickInterval);
        currentBlood = Mathf.Clamp(currentBlood, 0, maxBlood);

        //current blood should be rounded to smallest whole number for readability
        currentBlood = Mathf.Round(currentBlood);

        if (enableLogging)
        {
            onLogDetails?.Invoke($"Blood Lost: {lossRate * bloodlossTicker.tickInterval} units. {currentBlood}/{maxBlood}");
        }

        if (currentBlood <= 0)
        {
            DieFromBloodLoss();
        }
    }

    // ----------------------------------------------------------
    // Death due to blood loss
    private void DieFromBloodLoss()
    {
        // disable the ticker, stop movement, show death screen, etc.
        bloodlossTicker.StopTicker();

        // temp code will fix later
        movementHandler.updateMovement = false;
        movementHandler.updateCamera = false;


        if (enableLogging)
        {
            onLogDetails?.Invoke("Player has died due to blood loss.");
        }
    }

    // ----------------------------------------------------------
    public void Ouch(InjuryToken injury)
    {
        Debug.Log($"Size of the array: {injuryTokens.Length}");

        // Add the injury token to the list
        System.Array.Resize(ref injuryTokens, injuryTokens.Length + 1);
        injuryTokens[injuryTokens.Length - 1] = injury;

        Debug.Log($"Size of the array: {injuryTokens.Length}");
        

        if (enableLogging)
        {
            onLogDetails?.Invoke($"Ouch! You just got a : {injury.tokenName}. Level: {injury.injuryLevel}, Loss Amount: {injury.lossAmount}");
        }
    }

    #endregion



    #region Delegates & Events
    // ----------------------------------------------------------
    // Logging event
    public delegate void OnLogDetails(string details);
    public event OnLogDetails onLogDetails;

    // ----------------------------------------------------------
    // Enable and Disable
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    #endregion
}
