using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public GameObject floor;
    public GameObject[] wall;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeFloor(Material newMaterial)
    {
        MeshRenderer meshRenderer;
        meshRenderer = floor.GetComponent<MeshRenderer>();
        meshRenderer.material = newMaterial;
        meshRenderer.material.mainTextureScale = new Vector2(10, 10);
    }

    public void ChangeWall(Material newMaterial)
    {
        MeshRenderer[] meshRenderer;
        meshRenderer = new MeshRenderer[4];

        for (int i = 0; i < wall.Length; i++)
        {
            meshRenderer[i] = wall[i].GetComponent<MeshRenderer>();
            meshRenderer[i].material = newMaterial;
            meshRenderer[i].material.mainTextureScale = new Vector2(5, 5);
        }
    }
}
