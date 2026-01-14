using UnityEngine;

/// <summary>
/// A simple ticker system that triggers events at regular intervals.
/// </summary>
public class Ticker : MonoBehaviour
{
    #region Properties
    [Header("Ticker Settings")]
    [SerializeField] public bool enableLogging;
    [SerializeField] public string tickerName = "DefaultTicker";
    [SerializeField] public float tickInterval = 1f; // Interval in seconds
    [SerializeField] private bool isRunning = false;

    // ----------------------------------------------------------
    // private fields
    private int tickCount = 0;
    #endregion



    #region Constructors
    // ----------------------------------------------------------
    public Ticker(string name = "<DefaultTicker>", float interval = 1, bool logging = false)
    {
        tickerName = name;
        tickInterval = interval;
        enableLogging = logging;
        tickCount = 0;
    }
    #endregion



    #region Coroutines
    // ----------------------------------------------------------
    private System.Collections.IEnumerator TickerCoroutine(float IntervalInSeconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(IntervalInSeconds);

            tickCount++;
            onTick?.Invoke();

            if (enableLogging)
            {
                onLogDetails?.Invoke($"{tickerName} ticked. #{tickCount}");
            }
        }
    }
    #endregion



    #region Methods
    // ----------------------------------------------------------
    // Example method to demonstrate ticker functionality
    public void Tick()
    {
        tickCount++;
        onTick?.Invoke();
    }

    // ----------------------------------------------------------
    // Start the ticker
    public void StartTicker()
    {
        if (!isRunning)
        {
            StartCoroutine(TickerCoroutine(tickInterval));
            isRunning = true;

            if (enableLogging)
            {
                onLogDetails?.Invoke($"{tickerName} started.");
            }
        }
    }

    // ----------------------------------------------------------
    // Stop the ticker
    public void StopTicker()
    {
        if (isRunning)
        {
            StopAllCoroutines();
            isRunning = false;

            if (enableLogging)
            {
                onLogDetails?.Invoke($"{tickerName} stopped.");
            }
        }
    }

    // ----------------------------------------------------------
    // Set tick interval, must be greater than zero
    public void SetTickInterval(float intervalInSeconds)
    {
        if (intervalInSeconds <= 0f) { Debug.LogWarning("Tick interval must be greater than zero."); return; }

        tickInterval = intervalInSeconds;

        //logging
        if (enableLogging) { onLogDetails?.Invoke($"{tickerName} tick interval set to {tickInterval} seconds."); }
    }
    #endregion



    #region Delegates & Events
    // ----------------------------------------------------------
    // Logging event
    public delegate void OnLogDetails(string details);
    public event OnLogDetails onLogDetails;

    // ----------------------------------------------------------
    // Ticker event
    public delegate void OnTick();
    public event OnTick onTick;

    // ----------------------------------------------------------
    // On Enable / Disable Events
    private void OnEnable()
    {
        if (enableLogging)
        {
            onLogDetails?.Invoke($"{tickerName} enabled.");
        }
    }
    private void OnDisable()
    {
        if (enableLogging)
        {
            onLogDetails?.Invoke($"{tickerName} disabled.");
        }
    }
    #endregion
}
