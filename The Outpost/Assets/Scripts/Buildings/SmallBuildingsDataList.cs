using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBuildingsDataList : MonoBehaviour
{
    public Dictionary<int, BuildingDataSO> data = new Dictionary<int, BuildingDataSO>();

    public static SmallBuildingsDataList instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }
}
