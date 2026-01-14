using UnityEngine;

#region Enums
public enum NodeType
{
    Start,
    Intermediate,
    End,
    DeadEnd

}
#endregion

/// <summary>
/// Nodes represents rooms, connections between nodes represent pathways.
/// There will be a fixed number of intermediate nodes between a start and end node.
/// From this "path" will generate branches of dead ends and loops.
/// </summary>
public class Node
{
    #region Properties
    [Header("Node Settings")]
    public int nodeID;
    public string nodeName;
    public Node[] connections;
    public NodeType nodeType;
    #endregion
}
