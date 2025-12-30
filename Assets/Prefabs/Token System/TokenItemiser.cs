using UnityEditor.VersionControl;
using UnityEngine;

public class TokenItemiser : MonoBehaviour
{
    /// <summary>
    /// Singleton class to manage and manipulate Token objects.
    /// </summary>


    #region Properties
    [SerializeField] public bool enableLogging = false;
    #endregion



    #region Object References
    [SerializeField] private static TokenItemiser _instance;
    [SerializeField] private Logger logger;
    #endregion



    #region Singleton Instance
    public static TokenItemiser Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject tokenItemiserObject = new GameObject("TokenItemiser");
                _instance = tokenItemiserObject.AddComponent<TokenItemiser>();
                DontDestroyOnLoad(tokenItemiserObject);
            }
            return _instance;
        }
    }
    #endregion



    #region Methods
    // --------------------------------------------------------------------------------------------------------
    // Sort tokens by priority (ascending)
    public Token[] sortTokensByPriority(Token[] tokens)
    {
        System.Array.Sort(tokens, (a, b) => a.GetPriority().CompareTo(b.GetPriority()));

        //logging
        if (enableLogging)
        {
            string tokenList = "Tokens sorted by priority:\n";
            foreach (Token token in tokens)
            {
                tokenList += token.ToString() + "\n";
            }
            onLogDetails?.Invoke(tokenList);
        }

        return tokens;
    }

    // --------------------------------------------------------------------------------------------------------
    // Calculate the total value of all the tokens
    public double countTokenValue(Token[] tokens)
    {
        double totalValue = 0.0;
        foreach (Token token in tokens)
        {
            totalValue += token.GetValue();
        }

        //logging
        if (enableLogging)
        {
            onLogDetails?.Invoke($"Total token value calculated: {totalValue}");
        }

        return totalValue;
    }

    // --------------------------------------------------------------------------------------------------------
    // Get the token with the highest priority
    public Token getHighestPriorityToken(Token[] tokens)
    {
        if (tokens.Length == 0) return null;
        Token highestPriorityToken = tokens[0];
        foreach (Token token in tokens)
        {
            if (token.GetPriority() > highestPriorityToken.GetPriority())
            {
                highestPriorityToken = token;
            }
        }

        //logging
        if (enableLogging)
        {
            onLogDetails?.Invoke($"Highest priority token retrieved: {highestPriorityToken.ToString()}");
        }

        return highestPriorityToken;
    }

    // --------------------------------------------------------------------------------------------------------
    // Get the value of the token with the highest priority
    public double getHighestPriorityTokenValue(Token[] tokens)
    {
        Token highestPriorityToken = getHighestPriorityToken(tokens);

        //logging
        if (enableLogging)
        {
            onLogDetails?.Invoke($"Highest priority token value retrieved: {highestPriorityToken.GetValue()}");
        }

        return highestPriorityToken != null ? highestPriorityToken.GetValue() : 0.0;
    }

    // --------------------------------------------------------------------------------------------------------
    // Add a new token to the array and sort by priority
    public void AddToken(ref Token[] tokens, Token newToken)
    {
        System.Array.Resize(ref tokens, tokens.Length + 1);
        tokens[tokens.Length - 1] = newToken;
        sortTokensByPriority(tokens);

        //logging
        if (enableLogging)
        {
            onLogDetails?.Invoke($"Token '{newToken.GetName()}' added. New token count: {tokens.Length}");
        }
    }

    // --------------------------------------------------------------------------------------------------------
    // Remove a token at a specific index
    public void RemoveTokenAtIndex(ref Token[] tokens, int index)
    {
        if (index < 0 || index >= tokens.Length) return;
        for (int i = index; i < tokens.Length - 1; i++)
        {
            tokens[i] = tokens[i + 1];
        }
        System.Array.Resize(ref tokens, tokens.Length - 1);
        
        //logging
        if (enableLogging)
        {
            onLogDetails?.Invoke($"Token at index {index} removed. New token count: {tokens.Length}");
        }
    }

    // --------------------------------------------------------------------------------------------------------
    // Get token at specific index
    public void getTokenAtIndex(Token[] tokens, int index, out Token token)
    {
        token = null;
        if (index < 0 || index >= tokens.Length) return;
        token = tokens[index];

        //logging
        if (enableLogging)
        {
            onLogDetails?.Invoke($"Token at index {index} retrieved: {token.ToString()}");
        }
    }

    // --------------------------------------------------------------------------------------------------------
    // Clear all tokens
    public void ClearTokens(ref Token[] tokens)
    {
        tokens = new Token[0];

        //logging
        if (enableLogging)
        {
            onLogDetails?.Invoke("All tokens cleared.");
        }
    }
    #endregion



    #region Events and Delegates
    // --------------------------------------------------------------------------------------------------------
    // Logging delegate and event
    public delegate void LogDetails(string message);
    public event LogDetails onLogDetails;

    // --------------------------------------------------------------------------------------------------------
    // Enable and disable events
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    #endregion
}
