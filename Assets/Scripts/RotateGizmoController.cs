using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGizmoController : MonoBehaviour
{
    public GameObject thisObject; // Choose the Object
    public float rotationSpeed = 1000f; // Speed of the rotation

	void OnMouseDrag()
	{
		float horizontalInput = Input.GetAxis("Mouse X");
		thisObject.transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime); // Rotate object on Y axis
	}
}