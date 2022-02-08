using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Survivor Data",menuName ="Survivors/New Data")]

public class SurvivorDataSO : ScriptableObject
{
    public int id;
    public string nameSurvClass;
    public int buildingLevel;
    public int scavangeingLevel;
    public int strenghtLevel;
    public int researchLevel;
    public int leaderLevel;
    public int enduranceLevel;
    public int speedLevel;
    public GameObject prefabWithScript;
}
