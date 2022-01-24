using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGeneration : MonoBehaviour
{
    public IsometricRuleTile roadTile;
    public Tilemap tm;
    [SerializeField] private int[,] map;
    public int width,height;
    
    void Start()
    {
        map = BordersArray(width,height);
        RenderMap(map, tm, roadTile);
        
    }

    public int[,] BordersArray(int width,int height)
    {
        int[,] map = new int[width, height];
        for(int x=0;x<width;x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (y == 0 ||x==0 || y==height-1|| x==width-1)
                {
                    map[x, y] = 1;
                }
            }
        }
        return map;
    }

    public int[,] TerrainGen(int[,] map)
    {
        
        return map;
    }

    public void RenderMap(int[,] map, Tilemap groundTilemap,TileBase groundTileBase)
    {
        for(int x=0;x<width;x++)
        {
            for(int y=0;y<height;y++)
            {
                if (map[x, y] == 1)
                    groundTilemap.SetTile(new Vector3Int(x, y, 0), groundTileBase);
            }
        }
    }
}
