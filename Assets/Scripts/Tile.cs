using UnityEngine;

// Script is based on the following YouTube video by samyam:
// https://youtu.be/jvUvUkYeE3k

namespace PianoRun {

public enum TileType {
    STRAIGHT,
    LEFT,
    RIGHT,
    SIDEWAYS
}

// Defines the attributes of a tile.
public class Tile : MonoBehaviour
{
    public TileType type;
    public Transform pivot;
}

}