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
    public int width, height;
    public BoundsInt building2x2, building4x4;

    #region Unity Functions
    public static TerrainGeneration instance;
    private void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        #region incercare 1
        road = BordersArray(width,height); // strada pe margini
        RenderBorders(road,roadTM, roadTile); // strada
        road = GenerateGroundArray(width,height);
        SetTileOnBounds(road, roadTM);
        #endregion



    }
    #endregion

#region incercare1
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

    public void RenderBorders(int[,] map,Tilemap groundTilemap,TileBase groundTileBase)
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

    public int[,] GenerateGroundArray(int width,int height)
    {
        int[,] map = new int[width - 1, height - 1];
        for(int x=1;x<width-1;x+=3)
        {
            for(int y=1;y<height-1;y+=3)
            {
                GenBounds(map,x,y);
                
            }
        }
        return map;
    }

    public void GenBounds(int[,] map,int xMin,int yMin )
    {
        for(int x=xMin;x<=xMin;x++)
        {
            for(int y = yMin; y <= yMin; y++)
            {
               /* if(x==xMin+1)
                {
                    map[x, y] = 2;
                    map[x + 1, y] = 1;
                }
                else if(y==yMin+1)
                {
                    map[x, y] = 2;
                    map[x , y+1] = 1;
                }
                else if(y==yMin && x==xMin)
                {
                    map[x, y] = 2;
                    map[x+1, y + 1] = 1;
                }
                else
                {*/
                    map[x, y] = 2;
               // }
            }
        }
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
                if(map[x,y]==1)
                {
                    tm.SetTile(new Vector3Int(x, y, 0), roadTile);
                }
            }
        }
        
    }
    #endregion




}

