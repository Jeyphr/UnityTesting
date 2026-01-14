using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Maps are made of cells. These cells can be grouped into rooms.
/// Cells can either exist or not exist. If they exist, they have floor and ceiling heights.
/// Walls are defined per cell side (north, south, east, west) and can be interior walls, exterior walls, doors, or windows.
/// 
/// </summary>
public class Map2D : MonoBehaviour
{
    #region Properties
    [Header("Map Properties")]
    [SerializeField] private int mapSizeX;
    [SerializeField] private int mapSizeY;
    [SerializeField] private float gridOffset;
    [SerializeField] private float roomCeilingHeight;
    [SerializeField] private float roomFloorHeight;

    [Header("Object References")]
    [SerializeField] private GameObject mapContainer;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Cell2D[,] cellsInMap;



    // Private Fields
    #endregion



    #region Unity Methods
    private void Start()
    {
        GenerateGrid();
    }
    #endregion



    #region Methods
    // ----------------------------------------------------------
    // Instantiate the grid of cells that make up the map
    public void GenerateGrid()
    {
        Debug.Log($"Generating a grid of size {mapSizeX} x {mapSizeY} with cell size.");
        cellsInMap = new Cell2D[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                Vector3 cellPosition = new Vector3(x * gridOffset, 0, y * gridOffset);
                GameObject newCellObject = Instantiate(cellPrefab, cellPosition, Quaternion.identity, mapContainer.transform);
                newCellObject.name = $"Cell ({x},{y})";
                Cell2D newCell = newCellObject.GetComponent<Cell2D>();
                // Initialize cell properties here if needed

                cellsInMap[x, y] = newCell;
            }
        }
        
    }
    #endregion
    
}
