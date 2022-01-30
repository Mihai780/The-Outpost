using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class SurvivorScript : MonoBehaviour
{
    public SurvivorDataSO data;
    Vector2 mousePos;
    Vector3Int spawnPos;
    public Tilemap baseTM;

    void Start()
    {
        
    }

    
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }

    public void OnMouseDrag()
    {
        this.gameObject.transform.position = new Vector3(mousePos.x,mousePos.y ,0);
    }

}
