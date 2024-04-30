using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveState : IObjectState
{
	public void OnEnterState(ObjectBehaviour obj)
	{
		Debug.Log("Entering Inactive State!");
	}
	public void OnUpdateState(ObjectBehaviour obj)
	{

	}
	public void OnExitState(ObjectBehaviour obj)
	{
		Debug.Log("Exiting Inactive State!");
	}
}

public class ActiveState : IObjectState
{
	private GameObject transformGizmo;
	private GameObject rotationGizmo;

	private Renderer renderer;

	public void OnEnterState(ObjectBehaviour obj)
	{
		Debug.Log("Entering Active State!");

		renderer = obj.renderer;
		renderer.material.color = Color.green;

		Transform thisobject = obj.gameObject.transform;

		// Verify and find the gizmos
		foreach(Transform gizmo in thisobject)
		{
			if (gizmo.tag == "TransformGizmo")
			{
				transformGizmo = gizmo.gameObject;
			}

			if (gizmo.tag == "RotationGizmo")
			{
				rotationGizmo = gizmo.gameObject;
			}
		}
	}
	public void OnUpdateState(ObjectBehaviour obj)
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			//Deactivate any other active gizmo
			rotationGizmo.SetActive(false);

			//Activate the gizmo we want to show
			transformGizmo.SetActive(true);
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			//Deactivate any other active gizmo
			transformGizmo.SetActive(false);	

			//Activate the gizmo we want to show
			rotationGizmo.SetActive(true);
		}

		if(Input.GetKeyDown(KeyCode.Escape))
			obj.SetState(new InactiveState());
	}
	public void OnExitState(ObjectBehaviour obj)
	{
		//Deactivate all gizmos
		transformGizmo.SetActive(false);
		rotationGizmo.SetActive(false);

		renderer.material.color = Color.white;

		Debug.Log("Exiting Active State!");
	}
}
