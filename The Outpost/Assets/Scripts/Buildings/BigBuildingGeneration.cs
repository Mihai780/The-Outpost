using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBuildingGeneration : MonoBehaviour
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
        id = Random.Range(0, 3);
        
        GetInfoOnID();
    }

    public void GetInfoOnID()
    {

        for (int i = 0; i <= BuildingDataLists.instance.bigBuildings.Count; i++)
        {
            if (id == BuildingDataLists.instance.bigBuildings[i].id)
            {
                foodChance = BuildingDataLists.instance.bigBuildings[i].foodChance;
                ammoChance = BuildingDataLists.instance.bigBuildings[i].ammoChance;
                survivorChance = BuildingDataLists.instance.bigBuildings[i].survivorChance;
                medicineChance = BuildingDataLists.instance.bigBuildings[i].medicineChance;
                spriteRend.sprite = BuildingDataLists.instance.bigBuildings[i].sprite;
                buildingName = BuildingDataLists.instance.bigBuildings[i].buildingName;
            }
        }
    }
}
