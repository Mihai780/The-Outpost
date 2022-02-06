using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticManager : MonoBehaviour
{
    public int nrFireFighters;

    public static StaticManager instance;
    private void Awake()
    {
        instance = this;
    }
}
