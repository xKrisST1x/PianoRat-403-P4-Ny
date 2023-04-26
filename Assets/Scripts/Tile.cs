using UnityEngine;


namespace PianoRun {

public enum TileType {
    STRAIGHT,
    LEFT,
    RIGHT,
    SIDEWAYS
    //STRAIGHTJUMPTEST,
    //STRAIGHTSLIDETEST
}

/// <summary>
/// Defines the attributes of a tile.
/// </summary>
public class Tile : MonoBehaviour
{
    public TileType type;
    public Transform pivot;
}

}