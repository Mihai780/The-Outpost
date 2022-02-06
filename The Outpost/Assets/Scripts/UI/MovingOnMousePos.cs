using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class MovingOnMousePos : MonoBehaviour
{
    Transform thisTransform;
    Vector2 mousePos;
     public float zoom;
    public float minValue;
    public CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        thisTransform = this.transform;
    }

   
    void Update()
    {
        
        zoom =Mathf.Clamp(zoom, minValue, 10);
        zoom -= Input.mouseScrollDelta.y * 0.2f;

        virtualCamera.m_Lens.OrthographicSize = zoom;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(!EventSystem.current.IsPointerOverGameObject())
            thisTransform.position = mousePos;
    }
}
