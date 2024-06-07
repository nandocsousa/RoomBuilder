using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockPoint : MonoBehaviour
{
    public float lockdistance;
    public GridMaker GridMaker;

    void Start()
    {

    }
    void Update()
    {
        for (int x = 0; x < GridMaker.platformSizeX-1; x++)
            for (int z = 0; z < GridMaker.platformSizeZ-1; z++)
            {
                float distance = Vector3.Distance(GridMaker.point[x,z], transform.position);
            if (distance <= lockdistance)
                transform.position = GridMaker.point[x,z];
            }
    }
}
