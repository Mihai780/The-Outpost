using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int repetariPeAxaX, urcariPeAxaY;
    public List<GameObject> prefabs;
    public Vector2 origin,currentPoint,addTile1,addTile3;


    void Start()
    {
        currentPoint = origin;
        for(int x=1;x<=repetariPeAxaX;x++)
        {
            for(int y=1;y<=urcariPeAxaY;y++)
            {
                //Verifici daca pe pozitia curenta si pe urmatoarea se poate pune un tile
                    //daca poti pe amandoua dai random
                        //-tile1 sau 2
                    //daca poti doar pe tile-ul curent pui tile1 si muti
                    //daca nu poti pe nicicunul doar muti

                if(!Physics2D.CircleCast(currentPoint + addTile1, 0.1f, currentPoint + addTile1) && !Physics2D.CircleCast(currentPoint, 0.1f, currentPoint))
                {
                    int index = Random.Range(0, prefabs.Count);
                    GameObject selectedPrefab = prefabs[index];
                    Instantiate(selectedPrefab, currentPoint, Quaternion.identity);
                    if (index == 0)
                        currentPoint += addTile1;
                    else if(index == 1)
                        currentPoint += addTile3;

                }

                else if(!Physics2D.CircleCast(currentPoint, 0.1f, currentPoint))
                {
                    Instantiate(prefabs[0], currentPoint, Quaternion.identity);
                    currentPoint += addTile1;
                }

                else
                {
                    currentPoint += addTile1;
                }
            }
            currentPoint = origin + (x* new Vector2(-1f,0.5f));
        }

        
    }
    
}
