using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGen : MonoBehaviour
{
    public int width, height;
    public Tilemap tm;
    public IsometricRuleTile roadTile;
    public TileBase groundTile;

    private static Dictionary<TileModes,TileBase> tileClasses = new Dictionary<TileModes,TileBase>();
    
    void Start()
    {
        tileClasses.Add(TileModes.Empty, null);
        tileClasses.Add(TileModes.Road, roadTile);
        tileClasses.Add(TileModes.Ground, groundTile);
        GenerateWorld();
    }

    void GenerateWorld()
    {
        SetBorders(); // strazile de pe margini
      //  SetGround();
    }

    void SetBorders()
    {
        for(int x=0; x<width;x++)
        {
            for(int y = 0; y< height; y++)
            {
                if(x==0 || y==0 || x==width-1 || y==height-1)
                {
                    tm.SetTile(new Vector3Int(x, y, 0), tileClasses[TileModes.Road]);
                }
            }
        }
    }

    void SetGround()
    {
        foreach(var tile in tm.cellBounds.allPositionsWithin)
        {
            tm.SetTile(tile, tileClasses[TileModes.Ground]);
        }
    }
   
}

public enum TileModes {Empty,Road,Ground}