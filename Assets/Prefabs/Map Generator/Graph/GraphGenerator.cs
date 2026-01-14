using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GraphGenerator : MonoBehaviour
{
    #region Properties
    [Header("Graph Generator Settings")]
    public int numberOfNodes = 10;

    #endregion



    #region Methods
    // ----------------------------------------------------------
    // Example method to generate a graph
    public void GenerateGraph()
    {
        // Graph generation logic would go here
        Debug.Log($"Generating graph with {numberOfNodes} nodes.");
    }
    #endregion


}
