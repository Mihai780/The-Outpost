﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class buildingSpawner : MonoBehaviour
{
    public Tilemap tm,baseTM;
    public TileBase one, three,base1;
    public GameObject buildingOne, buildingThree;
    public Transform parentOne, parentThree;

    public static buildingSpawner instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnBuildings();
        GenerateBase();


    }

    void GenerateBase()
    {
        int gen = Random.Range(1, 100),nr=0;
        foreach(var tile in tm.cellBounds.allPositionsWithin)
        {
            gen = Random.Range(1, 100);
            if (tm.GetTile(tile)==one && gen==2)
            {
                nr++;
                baseTM.SetTile(tile,base1);
                if(tm.HasTile(new Vector3Int(tile.x+2,tile.y,0)))
                {
                    baseTM.SetTile(new Vector3Int(tile.x + 2, tile.y, 0), base1);
                }
                if (tm.HasTile(new Vector3Int(tile.x, tile.y+2, 0)))
                {
                    baseTM.SetTile(new Vector3Int(tile.x, tile.y+2, 0), base1);
                }
                if (tm.HasTile(new Vector3Int(tile.x, tile.y - 2, 0)))
                {
                    baseTM.SetTile(new Vector3Int(tile.x, tile.y - 2, 0), base1);
                }
                if (tm.HasTile(new Vector3Int(tile.x-2, tile.y, 0)))
                {
                    baseTM.SetTile(new Vector3Int(tile.x-2, tile.y , 0), base1);
                }
                break;
            }
        }
        if (nr == 0)
            GenerateBase();
    }

    void SpawnBuildings()
    {
        foreach (var tile in tm.cellBounds.allPositionsWithin)
        {
            if (tm.GetTile(tile) == one)
            {
                Instantiate(buildingOne, tm.GetCellCenterLocal(tile), Quaternion.identity, parentOne);
            }
            else if (tm.GetTile(tile) == three)
            {
                Instantiate(buildingThree, tm.GetCellCenterLocal(tile), Quaternion.identity, parentThree);
            }
        }
    }
}
