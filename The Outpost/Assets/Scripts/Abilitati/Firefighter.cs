using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFighter : MonoBehaviour
{
    static int count=-1;

    public FireFighter()
    {
        count++;
        Debug.Log(count);
    }

    ~FireFighter()
    {
        count--;
        Debug.Log(count);
    }
}
