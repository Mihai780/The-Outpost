using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="BuildingSO",menuName ="Buildings/New Building Data")]
public class BuildingDataSO : ScriptableObject
{
    public int id;
    public string buildingName;
    public Sprite sprite;
    public int survivorChance;
    public int medicineChance;
    public int ammoChance;
    public int foodChance;

}
