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
    [SerializeField] public bool enableLogging = false;
    [SerializeField] public float totalBlood = 1000f; // Total blood volume
    [SerializeField] public float currentBlood = 1000f; // Current blood volume

    [Header("Object References")]
    [SerializeField] private InjuryToken[] injuryTokens;
    #endregion



    #region Unity Methods
    // ----------------------------------------------------------
    private void Start()
    {
        
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
