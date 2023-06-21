using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script is based on the following YouTube video by samyam:
// https://youtu.be/jvUvUkYeE3k

namespace PianoRun
{

public class TileSpawner : MonoBehaviour
{
   [SerializeField]
   private int tileStartCount = 10;
   [SerializeField]
   private int minimunStraightTile = 3;
   [SerializeField]
   private int maximumStraightTile = 15; 

   [SerializeField]
   private List<GameObject> startingTile;

   [SerializeField]
   private List<GameObject> turnTiles;
   [SerializeField]
   private Vector3 currentTileLocation = Vector3.zero;
   private Vector3 currentTileDirection = Vector3.forward;
   private GameObject prevTile;

   private List<GameObject> currentTiles;
   
   private void Start()
   {
    currentTiles = new List<GameObject>();

    Random.InitState(System.DateTime.Now.Millisecond); 

    for (int i = 0; i < tileStartCount; ++i)
    {
                //SpawnTile(SelectRandomGameObjectFromList(startingTile).GetComponent<Tile>());
                SpawnTile(startingTile[0].GetComponent<Tile>());
    }

    SpawnTile(SelectRandomGameObjectFromList(turnTiles).GetComponent<Tile>());
   }

    private void SpawnTile(Tile tile)
    {
        Quaternion newTileRotation = tile.gameObject.transform.rotation * 
        Quaternion.LookRotation(currentTileDirection, Vector3.up);

        prevTile = GameObject.Instantiate(tile.gameObject, currentTileLocation, newTileRotation);
        currentTiles.Add(prevTile);

        if(tile.type == TileType.STRAIGHT)
        currentTileLocation += Vector3.Scale(prevTile.GetComponent<Renderer>().bounds.size, 
        currentTileDirection);
    }

    private void DeletePreviousTile()
    {
        while(currentTiles.Count != 1)
        {
                GameObject tile = currentTiles[0];
                currentTiles.RemoveAt(0);
                Destroy(tile);
        }
    }

    public void AddNewDirection(Vector3 direction)
    {
        currentTileDirection = direction;
        DeletePreviousTile();

        Vector3 tilePlacementScale;
        if(prevTile.GetComponent<Tile>().type == TileType.SIDEWAYS)
        {
            tilePlacementScale = Vector3.Scale(prevTile.GetComponent<Renderer>().bounds.size / 2 + 
            (Vector3.one * SelectRandomGameObjectFromList(startingTile).GetComponent<BoxCollider>().size.z / 2), 
            currentTileDirection);

        } 
        else 
        {
            // left or right tiles
            tilePlacementScale = Vector3.Scale((prevTile.GetComponent<Renderer>().bounds.size - 
            (Vector3.one * 2)) + (Vector3.one * 
            SelectRandomGameObjectFromList(startingTile).GetComponent<BoxCollider>().size.z / 2),
            currentTileDirection);
        }

        currentTileLocation += tilePlacementScale;

        int currentPathLength = Random.Range(minimunStraightTile, maximumStraightTile);
        for (int  i = 0; i < currentPathLength; ++i)
        {
            SpawnTile(SelectRandomGameObjectFromList(startingTile).GetComponent<Tile>());
        }

        SpawnTile(SelectRandomGameObjectFromList(turnTiles).GetComponent<Tile>());

    }
    private GameObject SelectRandomGameObjectFromList(List<GameObject> list)
    {
        if(list.Count == 0) return null;

        return list[Random.Range(0, list.Count)];
    }

}
}