using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public GameObject floor;
    public GameObject wall;

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
        MeshRenderer meshRenderer;
        meshRenderer = wall.GetComponent<MeshRenderer>();
        meshRenderer.material = newMaterial;
        meshRenderer.material.mainTextureScale = new Vector2(10, 10);
    }
}
