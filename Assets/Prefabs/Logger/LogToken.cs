using UnityEngine;

/// <summary>
/// LogTokens are specialized Tokens used within the logging system of the game.
/// They inherit from the base Token class and can be extended with additional
/// properties or methods specific to logging functionality.
/// </summary>
public class LogToken : Token
{
    #region Properties
    [Header("Log Token Properties")]
    [SerializeField] public string message { get; private set; }

    // Private Fields
    private int logCount;
    #endregion



    #region Constructors
    // ----------------------------------------------------------
    public LogToken(string name = "DevLogToken", string message = "") : base(name)
    {
        logCount++;
        tokenPriority = logCount;
        
        tokenName = name;
        this.message = message;
    }
    #endregion



    #region Overrides
    // ----------------------------------------------------------
    public override string ToString()
    {
        return $"#{tokenPriority} : {tokenName} - {message}\t";
    }
    #endregion
}
