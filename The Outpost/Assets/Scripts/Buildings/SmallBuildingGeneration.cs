using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBuildingGeneration : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private int foodChance;
    [SerializeField] private int ammoChance;
    [SerializeField] private int medicineChance;
    [SerializeField] private int survivorChance;
    [SerializeField] private SpriteRenderer spriteRend;
    [HideInInspector] public string buildingName;

    void Start()
    {
        id = Random.Range(0,5);
        GetInfoOnID();
    }

    public  void GetInfoOnID()
    {
        
            for(int i=0;i<=BuildingDataLists.instance.smallBuildings.Count;i++)
            {
                if (id == BuildingDataLists.instance.smallBuildings[i].id)
                {
                    foodChance = BuildingDataLists.instance.smallBuildings[i].foodChance;
                    ammoChance = BuildingDataLists.instance.smallBuildings[i].ammoChance;
                    survivorChance = BuildingDataLists.instance.smallBuildings[i].survivorChance;
                    medicineChance = BuildingDataLists.instance.smallBuildings[i].medicineChance;
                    spriteRend.sprite = BuildingDataLists.instance.smallBuildings[i].sprite;
                    buildingName = BuildingDataLists.instance.smallBuildings[i].buildingName;
                }
            } 
    }

}


