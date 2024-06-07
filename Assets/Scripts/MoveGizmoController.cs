using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGizmoController : MonoBehaviour
{
    private ObjectBehaviour objBehaviour;

    public GameObject thisObject; // Choose the Object
	public float moveSpeed; // Speed of the movement

    private void Start()
    {
        objBehaviour = thisObject.GetComponent<ObjectBehaviour>();
    }
    void OnMouseDown()
	{
		Debug.Log("Pressed!");
        objBehaviour.SetState(new EditingState());
    }

	void OnMouseUp()
	{
		Debug.Log("Released!");
        objBehaviour.SetState(new ActiveState());
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
