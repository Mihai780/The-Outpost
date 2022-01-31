using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class SurvivorScript : MonoBehaviour
{
    public SurvivorDataSO data;
    Vector2 mousePos;
    Vector3 prevPos;
    Vector3Int mousePosInt;
    public Tilemap mainTM;

    void Start()
    {
        
    }

    
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosInt = mainTM.WorldToCell(mousePos);
        
    }

    private void OnMouseDown()
    {
        prevPos = transform.position;
    }

    public void OnMouseDrag()
    {
        transform.position = new Vector3(mousePos.x,mousePos.y ,0);
    }

    private void OnMouseUp()
    {
        if(mainTM.GetTile(mousePosInt) == buildingSpawner.instance.base1
            || mainTM.GetTile(mousePosInt) == buildingSpawner.instance.one
            || mainTM.GetTile(mousePosInt) == buildingSpawner.instance.three)
        {
            transform.position = mainTM.GetCellCenterLocal(mousePosInt);
            Debug.Log("set");
        }
        else
        {
            transform.position = prevPos;
        }
        
    }

}
