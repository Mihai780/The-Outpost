using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width, height ,k=0;
    public List<GameObject> prefabs;
    public Vector2 currentPoint;
    

    void Start()
    {
        while(k<10)
        {
            int index = Random.Range(0, prefabs.Count);
            GameObject selectedPrefab = prefabs[index];

            if(index == 0)
            {
                currentPoint = currentPoint + new Vector2(1f, 0.5f);
                Instantiate(selectedPrefab, currentPoint, Quaternion.identity);
                
            }
            else if(index==1)
            {
                currentPoint = currentPoint + new Vector2(2f, 1f);
                Instantiate(selectedPrefab, currentPoint, Quaternion.identity);

            }
            
            k++;
        }
        
    }

    
}
