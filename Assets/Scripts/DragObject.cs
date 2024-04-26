using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragObject : Object
{
    public Vector3 mOffset;
    public float mZCoord;

    private void Start()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        //mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseUp()
    {

    }

    void OnMouseDrag()
    {
        //transform.position = GetMouseWorldPos() + mOffset;
    }

    public Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}