using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDataLists : MonoBehaviour
{
    public List<BuildingDataSO> smallBuildings;
    public List<BuildingDataSO> bigBuildings;

    public static BuildingDataLists instance;
    private void Awake()
    {
        instance = this;
    }


}

//public enum SmallBuildings { SmallFarm, Marketplace, Church, Library, Laboratory }
//public enum BigBuildings { BigFarm, Mall, Hotel }