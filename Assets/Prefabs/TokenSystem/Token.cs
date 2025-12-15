using UnityEngine;

public class Token
{
    #region Properties
    [SerializeField]private string tokenName { get; set; }
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



    #region Overrides
    public override string ToString()
    {
        return $"{tokenPriority} : {tokenName}\t: {tokenValue}";
    }
    #endregion
}
