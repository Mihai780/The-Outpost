using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int repetariPeAxaX, urcariPeAxaY;
    public List<GameObject> prefabs;
    public Vector2 origin,currentPoint,addTile1,addTile3;
    public Transform parentTile1, parentTile3;
    private int x,y;

    void Start()
    {
        x = 1;
        y = 1;
        Invoke(nameof(Generate),0.5f);
    }
    
    void XCall()
    {
        currentPoint = origin + (x * new Vector2(-1f, 0.5f));
        if (x <= repetariPeAxaX)
            Invoke(nameof(YCall), 0.1f);
    }

    void YCall()
    {
        if (!Physics2D.CircleCast(currentPoint + addTile1, 0.1f, currentPoint + addTile1) && !Physics2D.CircleCast(currentPoint, 0.1f, currentPoint))
        {
            int index = Random.Range(0, prefabs.Count);
            GameObject selectedPrefab = prefabs[index];

            if (index == 0)
            {
                Instantiate(selectedPrefab, currentPoint, Quaternion.identity, parentTile1);
                currentPoint += addTile1;
            }

            else if (index == 1)
            {
                Instantiate(selectedPrefab, currentPoint, Quaternion.identity, parentTile3);
                currentPoint += addTile1;
            }

        }

        else if (!Physics2D.CircleCast(currentPoint, 0.1f, currentPoint) && Physics2D.CircleCast(currentPoint + addTile1, 0.1f, currentPoint + addTile1))
        {
            Instantiate(prefabs[0], currentPoint, Quaternion.identity, parentTile1);
            currentPoint += addTile1;
        }

        else
        {
            currentPoint += addTile1;
        }

        y++;
        if (y <= urcariPeAxaY)
        {
            Invoke(nameof(YCall), 0.1f);
        }
        else
        {
            y = 1;
            Invoke(nameof(XCall), 0.5f);
            x++;
        }
    }

    void Generate()
    {
        currentPoint = origin;

        Invoke(nameof(XCall),0.5f);
    }
}
