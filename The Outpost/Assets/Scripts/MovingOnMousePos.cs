using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingOnMousePos : MonoBehaviour
{
    Transform thisTransform;
    Vector2 mousePos;

    private void Start()
    {
        thisTransform = this.transform;
    }

   
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(!EventSystem.current.IsPointerOverGameObject())
            thisTransform.position = mousePos;
    }
}
