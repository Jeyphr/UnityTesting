using UnityEngine;

[CreateAssetMenu(fileName = "Tokens", menuName = "Tokens/New Token", order = 1)]
public class Token : ScriptableObject
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
