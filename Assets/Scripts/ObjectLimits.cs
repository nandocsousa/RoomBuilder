using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ObjectLimits : MonoBehaviour
{
    public GameObject platform;
    public float platformSizeX;
    public float platformSizeZ;

    public float Xsize;
    public float Zsize;

    private void Start()
    {
        platform = GameObject.FindGameObjectWithTag("Platform");

        platformSizeX = platform.transform.localScale.x;
        platformSizeZ = platform.transform.localScale.z;
    }
    private void Update()
    {
        if (transform.position.x >= platformSizeX / 2 - (Xsize - .01f))
        {
            Debug.Log("+1x");
            transform.position = new Vector3(platformSizeX / 2 - Xsize, 0, transform.position.z);
        }

        else if (transform.position.x <= (platformSizeX / 2) * -1 + (Xsize - .01f))
        {
            Debug.Log("-1x");
            transform.position = new Vector3((platformSizeX * -1) / 2 + Xsize, 0, transform.position.z);
        }

        else if (transform.position.z >= platformSizeZ / 2 - (Zsize - .01f))
        {
            Debug.Log("+1z");
            transform.position = new Vector3(transform.position.x, 0, platformSizeZ / 2 - Zsize);
        }

        else if (transform.position.z <= (platformSizeZ / 2) * -1 + (Zsize - .01f))
        {
            Debug.Log("-1z");
            transform.position = new Vector3(transform.position.x, 0, (platformSizeZ * -1) / 2 + Zsize);
        }
    }
}
