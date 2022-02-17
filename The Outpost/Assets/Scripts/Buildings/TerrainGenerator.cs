using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int repetariPeAxaX, urcariPeAxaY;
    public List<GameObject> prefabs;
    public Vector2 origin,currentPoint,addTile1;
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
        currentPoint = origin + (x * new Vector2(-0.5f, 0.25f));
        if (x <= repetariPeAxaX)
        {
            Invoke(nameof(YCall), 0.1f);
        }
        else
        {
            SpawnBase();
        }
            
    }

    void SpawnBase()
    {
        int baseIndex = Random.Range(0, parentTile1.childCount);
        GameObject baseBegin = parentTile1.GetChild(baseIndex).gameObject;
        
    }

    void YCall()
    {
        if (!Physics2D.CircleCast(currentPoint + addTile1, 0.05f, Vector2.zero) && !Physics2D.CircleCast(currentPoint, 0.05f, Vector2.zero))
        {
            int index = Random.Range(0, prefabs.Count);
            GameObject selectedPrefab = prefabs[index];

            if (index == 0)
            {
                Instantiate(selectedPrefab, currentPoint, Quaternion.identity, parentTile1);
            }

            else if (index == 1)
            {
                Instantiate(selectedPrefab, currentPoint, Quaternion.identity, parentTile3);
            }

        }

        else if (!Physics2D.CircleCast(currentPoint, 0.05f, Vector2.zero) && Physics2D.CircleCast(currentPoint + addTile1, 0.05f, Vector2.zero))
        {
            Instantiate(prefabs[0], currentPoint, Quaternion.identity, parentTile1);
        }

        currentPoint += addTile1;

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
