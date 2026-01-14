using UnityEngine;

#region Enums
public enum RoomStyle
{
    Office,
    Lounge,
    ConferenceRoom,
    Cafeteria,
    StorageRoom,
    Administration
}

public enum RoomShape
{
    Rectangle,
    Cutout,         //Rectangular room with a portion removed
    Split,          //Rectangular room split in two with interior walls.
    Irregular       //Rectangular room with multiple cutouts and splits.
}
#endregion

/// <summary>
/// Represents a room composed of multiple cells in a 2D map.
/// </summary>
public class Room2D : MonoBehaviour
{
    #region Properties
    [Header("Room2D Properties")]
    [SerializeField] public RoomStyle roomStyle;        // Determines how the cells in the room are decorated
    [SerializeField] public Vector2 roomPosition;       // Bottom-left position of the room in the map
    [SerializeField] public int xSizeInCells;
    [SerializeField] public int ySizeInCells;

    [Header("Object References")]
    [SerializeField] public Cell2D[] cellsInRoom;

    // Private Fields
    private int roomID = 1;
    #endregion



    #region Methods
    // ----------------------------------------------------------
    // Create room
    public void CreateRoom(int xSize, int ySize, Vector2 position, RoomStyle style, RoomShape shape)
    {
        // Room creation logic would go here

        // Create the flat that will be the room
        BuildFlat(position, xSize, ySize);
        // Carve the flat depending on room shape
        // Build walls based on room style
        // Decorate room based on style
        // done.
    }

    // ----------------------------------------------------------
    // A flat is a simple representation of a room with no walls or decorations.
    // It is just a grid of cells.
    public void BuildFlat(Vector2 position, int xSize, int ySize)
    {
        Debug.Log($"Building a flat at position {position} with size {xSize} x {ySize} cells.");
        
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                // Create and initialize Cell2D instances here
                Vector2 cellPosition = new Vector2(position.x + (x * 1), position.y + (y * 1)); // Assuming cell size of 1 for simplicity
                Cell2D newCell = new Cell2D(cellPosition, 1f, 3f); // Example floor and ceiling heights
                // Additional cell setup can be done here
            }
        }
    }

    // ----------------------------------------------------------
    // Carve the flat to create the desired room shape
    public void CarveRoomShape(RoomShape shape)
    {
        // Room carving logic would go here
        Debug.Log($"Carving room shape: {shape}");
    }

    // ----------------------------------------------------------
    // Decorate the room based on its style
    public void DecorateRoom(RoomStyle style)
    {
        // Room decoration logic would go here
        Debug.Log($"Decorating room with style: {style}");
    }

    // ----------------------------------------------------------
    // Build walls for the room
    public void BuildWalls()
    {
        // Wall building logic would go here
        Debug.Log("Building walls for the room.");
    }
    #endregion
}
