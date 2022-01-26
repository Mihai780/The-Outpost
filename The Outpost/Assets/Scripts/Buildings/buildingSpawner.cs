using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class buildingSpawner : MonoBehaviour
{
    public Tilemap tm;
    public TileBase one, three;
    public GameObject buildingOne, buildingThree;
    public Transform parentOne, parentThree;

    void Start()
    {
        foreach(var tile in tm.cellBounds.allPositionsWithin)
        {
            if(tm.GetTile(tile) == one)
            {
                Instantiate(buildingOne, tm.GetCellCenterLocal(tile), Quaternion.identity,parentOne);
            }
            else if (tm.GetTile(tile) == three)
            {
                Instantiate(buildingThree, tm.GetCellCenterLocal(tile), Quaternion.identity,parentThree);
            }
        }
    }

    
}
