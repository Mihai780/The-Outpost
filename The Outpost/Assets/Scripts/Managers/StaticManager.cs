using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticManager : MonoBehaviour
{
    
    public List<SurvivorDataSO> survData;

    public static StaticManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void InstantiateGO(GameObject obj)
    {
        Instantiate(obj);
    }

    public void Reduction(int nr)
    {
        nr--;
    }
}
