using UnityEngine;

public class Token
{
    #region Properties
    [Header("Token Properties")]
    [SerializeField] private string tokenName { get; set; }
    [SerializeField] private double tokenValue { get; set; }
    [SerializeField] private int tokenPriority { get; set; }
    #endregion



    #region Constructors
    public Token(string name = "DevToken", double value = 0.0, int priority = 0)
    {
        tokenName = name;
        tokenValue = value;
        tokenPriority = priority;
    }
    #endregion



    #region Methods
    //getters
    public string GetName()
    {
        return tokenName;
    }
    public double GetValue()
    {
        return tokenValue;
    }
    public int GetPriority()
    {
        return tokenPriority;
    }

    //setters
    public void SetValue(double value)
    {
        tokenValue = value;
    }
    public void SetPriority(int priority)
    {
        tokenPriority = priority;
    }
    #endregion



    #region Overrides
    public override string ToString()
    {
        return $"{tokenPriority} : {tokenName}\t: {tokenValue}";
    }
    #endregion



    #region Events and Delegates
    public delegate void LogDetails(string message);
    public event LogDetails onLogDetails;

    #endregion
}
