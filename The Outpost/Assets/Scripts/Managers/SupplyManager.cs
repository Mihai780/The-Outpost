using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyManager : MonoBehaviour
{
    public SupplyShow ammo;
    public SupplyShow medicine;
    public SupplyShow materials;
    public SupplyShow food;

    public static SupplyManager instance;
    private void Start()
    {
        instance = this;
    }


    public void ModifyValue(SupplyShow supply,int value)
    {
        if(supply.currSupply<supply.maxSupply)
        supply.currSupply += value;
    }
}
