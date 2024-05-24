using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGizmoController : MonoBehaviour
{
	public GameObject thisObject; // Choose the Object
	public float moveSpeed = .1f; // Speed of the movement

	void OnMouseDown()
	{
		Debug.Log("Pressed!");
	}

	void OnMouseUp()
	{
		Debug.Log("Released!");
	}

	void OnMouseDrag()
	{
		Debug.Log("DRAGGING!");

		if (gameObject.tag == "Xgizmo")
		{
			Debug.Log("DRAGGING! X");
			float horizontalInput = Input.GetAxis("Mouse X");
			thisObject.transform.position += new Vector3(horizontalInput * moveSpeed, 0, 0); // Move on the X axis
        }
        else if (gameObject.tag == "Zgizmo")
		{
			Debug.Log("DRAGGING! Z");
			float horizontalInput = Input.GetAxis("Mouse Y");
			thisObject.transform.position += new Vector3(0, 0, horizontalInput * moveSpeed); // Move on the Z axis
		}
	}
}
