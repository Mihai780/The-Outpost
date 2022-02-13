using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapTerrainGenerator : MonoBehaviour
{
    public Tilemap tm;
    public TileBase tile1, tile3;
    public GameObject prefab1, prefab3;
    
    void Start()
    {
        foreach(var tile in tm.cellBounds.allPositionsWithin)
        {
            if(tm.GetTile(tile) == tile1)
            {
                Instantiate(prefab1, tm.GetCellCenterWorld(tile), Quaternion.identity);
            }
            if(tm.GetTile(tile) == tile3)
            {
                Instantiate(prefab3, tile, Quaternion.identity);
            }
        }
    }

   
}
