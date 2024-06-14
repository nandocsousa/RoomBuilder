using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab;

    public void SpawnPrefab()
    {
        Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
