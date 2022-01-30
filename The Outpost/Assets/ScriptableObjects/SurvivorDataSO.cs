using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Survivor Data",menuName ="Survivors/New Data")]
public class SurvivorDataSO : ScriptableObject
{
    public int buildingLevel;
    public int scavangeingLevel;
    public int soldierLevel;
    public int engineerLevel;
    public int leaderLevel;
}
