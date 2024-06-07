using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GridMaker : MonoBehaviour
{
    public GameObject platform;
    public float platformSizeX;
    public float platformSizeZ;
    public float lockDistance;

    [Space(10)]
    [Header("Testing Feature")]
    public bool showGridPoints;

    public Vector3[,] point;

    private void Start()
    {
        platform = GameObject.FindGameObjectWithTag("Platform");

        platformSizeX = platform.transform.localScale.x;
        platformSizeZ = platform.transform.localScale.z;

        point = new Vector3[(int)(platformSizeX),(int)(platformSizeZ)];

        Vector3 pos = Vector3.zero;

        for (int x = 0; x < platformSizeX; x++)
        {
            for (int z = 0; z < platformSizeZ; z++)
            {
                pos = new Vector3(x - platformSizeX / 2 + .5f, 0, z - platformSizeZ / 2 + .5f);

                point[x, z] = pos;

                if (showGridPoints == true) createPrimitive(pos);
            }
        }
    }
    void createPrimitive(Vector3 pos)
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.localPosition = pos;
        obj.transform.localScale = new Vector3(.1f, .1f, .1f);
    }
}
