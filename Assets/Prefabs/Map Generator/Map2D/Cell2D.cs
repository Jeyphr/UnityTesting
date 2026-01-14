using UnityEngine;


/// <summary>
/// Cells are perfect squares in a grid layout.
/// </summary>
#region Enums
public enum cellWallType2D
{
    None,
    InteriorWall,
    ExteriorWall,
    Door,
    Window
}

public enum cellType2D
{
    Generic,
    Exit,
}
#endregion



/// <summary>
/// Cells are made of floor, ceiling, and walls.
/// Cells are perfect squares in a grid layout.
/// Cells can either exist or not exist. If they exist, they have floor and ceiling heights.
/// Walls are defined per cell side (north, south, east, west) and can be interior walls, exterior walls, doors, or windows.
/// </summary>
public class Cell2D : MonoBehaviour
{
    #region Properties
    [Header("Cell2D Properties")]
    [SerializeField] private Vector2 cellPosition;
    [SerializeField] private cellType2D cellType;   // We may have different types of cells in the future
    [SerializeField] private float cellSize;        // Cell size is based on prefab scale
    [SerializeField] private bool exists;
    [SerializeField] private float floorHeight;     // Assume ground level is 0, any positive value is above ground, negative is below ground
    [SerializeField] private float ceilingHeight;   // Height from ground level to ceiling

    // ----------------------------------------------------------
    [Header("Object References")]
    [SerializeField] private GameObject Cell { get; set; }
    [SerializeField] private GameObject[] walls;    // Array to hold wall GameObjects

    // ----------------------------------------------------------
    [Header("Cell Walls")]
    public cellWallType2D northWall;
    public cellWallType2D southWall;
    public cellWallType2D eastWall;
    public cellWallType2D westWall;

    // ----------------------------------------------------------
    // Private Fields
    private int cellID;
    #endregion



    #region Constructors
    // ----------------------------------------------------------
    public Cell2D(Vector2 position, float floorHeight, float ceilingHeight)
    {
        this.cellPosition = position;
        this.cellSize = 1f;                     // Default size, can be modified later
        this.exists = true;
        this.floorHeight = floorHeight;
        this.ceilingHeight = ceilingHeight;

        // Default wall types
        this.northWall = cellWallType2D.None;
        this.southWall = cellWallType2D.None;
        this.eastWall = cellWallType2D.None;
        this.westWall = cellWallType2D.None;
    }
    #endregion

}


