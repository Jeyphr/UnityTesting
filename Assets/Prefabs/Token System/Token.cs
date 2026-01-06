using UnityEngine;

/// <summary>
/// Tokens represent discrete pieces of information within the game system.
/// Each token has a name and a priority level that indicates its importance.
/// Higher priority tokens should be processed or addressed before lower priority ones.
/// 
/// Tokens can be extended to represent specific types of data, such as Injury Tokens for injuries,
/// which include additional properties like injury type, severity level, and affected limb.
/// 
/// Tokens are iterated and managed by the TokenItemiser singleton class, which provides functionality
/// to sort and manipulate collections of tokens based on their properties, as well as 
/// add and remove tokens from various systems.
/// </summary>

public class Token
{
    #region Properties
    [Header("Token Properties")]
    [SerializeField] public string tokenName { get; set; }
    [SerializeField] public int tokenPriority { get; set; }
    #endregion



    #region Constructors
    public Token(string name = "DevToken", int priority = 0)
    {
        tokenName = name;
        tokenPriority = priority;
    }
    #endregion



    #region Methods
    //getters
    public string GetName()
    {
        return tokenName;
    }
    public int GetPriority()
    {
        return tokenPriority;
    }

    //setters
    public void SetPriority(int priority)
    {
        tokenPriority = priority;
    }
    #endregion



    #region Overrides
    public override string ToString()
    {
        return $"{tokenPriority} : {tokenName}\t";
    }
    #endregion



    #region Events and Delegates
    public delegate void LogDetails(string message);
    public event LogDetails onLogDetails;

    #endregion
}
