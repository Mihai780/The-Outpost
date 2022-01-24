using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBuildingGeneration : MonoBehaviour
{
    [SerializeField] private int id;
    
    
    

    void Start()
    {
        id = Random.Range(0,5);
        GetInfoOnID();
    }

    public static void GetInfoOnID()
    {
        
    }

}


