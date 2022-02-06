using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefighter : MonoBehaviour
{
    public Firefighter()
    {
        StaticManager.instance.nrFireFighters++;
        Debug.Log(StaticManager.instance.nrFireFighters);
    }

    ~Firefighter()
    {
        StaticManager.instance.nrFireFighters--;
        Debug.Log(StaticManager.instance.nrFireFighters);
    }
}
