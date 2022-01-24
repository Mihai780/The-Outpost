using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGeneration : MonoBehaviour
{
    public IsometricRuleTile roadTile;
    public TileBase groundTile;
    public Tilemap roadTM;
    [SerializeField] private int[,] road;
    public int width,height,roadIndex,groundIndex;
    public BoundsInt building2x2, building4x4;

    #region Unity Functions
    public static TerrainGeneration instance;
    private void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        road = BordersArray(width,height,roadIndex); // strada pe margini
        RenderBorders(road,roadIndex, roadTM, roadTile); // strada
        road = GenerateGroundArray(width,height,groundIndex);
        SetTileOnBounds(road, roadTM);
        
    }
    #endregion
    public int[,] BordersArray(int width,int height,int index)
    {
        int[,] map = new int[width, height];
        for(int x=0;x<width;x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (y == 0 ||x==0 || y==height-1|| x==width-1)
                {
                    map[x, y] = index;
                }
            }
        }
        return map;
    }

    public void RenderBorders(int[,] map,int index, Tilemap groundTilemap,TileBase groundTileBase)
    {
        for(int x=0;x<width;x++)
        {
            for(int y=0;y<height;y++)
            {
                if (map[x, y] == index)
                    groundTilemap.SetTile(new Vector3Int(x, y, 0), groundTileBase);
            }
        }
    }

    public int[,] GenerateGroundArray(int width,int height, int index)
    {
        int[,] map = new int[width - 1, height - 1];
        for(int x=1;x<width-1;x++)
        {
            for(int y=1;y<height-1;y++)
            {
                map[x, y] = index; 
            }
        }
        return map;
    }

    public void SetTileOnBounds(int[,] map,Tilemap tm)
    {
        for (int x = 1; x < width - 1; x++)
        {
            for (int y = 1; y < height - 1; y++)
            {
                if(map[x,y] == 2)
                {
                    tm.SetTile(new Vector3Int(x, y, 0), groundTile);
                }
                
            }
        }
        
    }
}
 
