using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject currentObj = null;

    public void UpdateObject(GameObject obj)
    {
        currentObj = obj;
    }
}
