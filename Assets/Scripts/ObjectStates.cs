using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

public class EditingState : IObjectState
{
    public void OnEnterState(ObjectBehaviour obj)
    {
        Debug.Log("Entering Moving State!");
    }
    public void OnUpdateState(ObjectBehaviour obj)
    {
		//Receive order by gizmos to move
		//Swap movements/rotations/gridMovement Here
    }
    public void OnExitState(ObjectBehaviour obj)
    {
        Debug.Log("Exiting Moving State!");
    }
}

public class ActiveState : IObjectState
{
	private GameObject transformGizmo;
	private GameObject rotationGizmo;

	private Renderer renderer;
	private Collider collider;

    private ObjectManager manager;

    private GridMaker gridMaker;
	private bool gridState;

    public void OnEnterState(ObjectBehaviour obj)
	{
		Debug.Log("Entering Active State!");

		renderer = obj.renderer;
		renderer.material.color = Color.green;

		collider = obj.GetComponent<Collider>();
		//Deactivate collider
		collider.enabled = false;

		manager = GameObject.FindWithTag("Object Manager").GetComponent<ObjectManager>();
        gridMaker = GameObject.FindWithTag("Grid Maker").GetComponent<GridMaker>();

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

		if(Input.GetKeyDown(KeyCode.D))
		{
			//Destroy object
            obj.DestroyObject();
        }

		if (Input.GetKeyUp(KeyCode.G) && gridState == false)
		{
			//Activate the grid
			gridState = true;

			//Deactivate any other active gizmo
			rotationGizmo.SetActive(false);

			//Activate the gizmo we want to show
			transformGizmo.SetActive(true);

            renderer.material.color = Color.blue;
        }
		else if (Input.GetKeyUp(KeyCode.G) && gridState == true)
        {
			gridState = false; //Deactivate the grid

            renderer.material.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
			obj.SetState(new InactiveState()); //Enter Inactive state

		if(manager.currentObj != obj.gameObject && manager.currentObj != null)
            obj.SetState(new InactiveState()); //Enter Inactive state

        if (gridState == true) //Check positions of the grid
        {
            for (int x = 0; x < gridMaker.platformSizeX; x++)
                for (int z = 0; z < gridMaker.platformSizeZ; z++)
                {
                    float distance = Vector3.Distance(gridMaker.point[x, z], obj.transform.position);
                    if (distance <= gridMaker.lockDistance)
                        obj.transform.position = gridMaker.point[x, z];
                }
        }
        //After leaving editing mode
        //lock to the points if grid is true and return to editing
		//otherwise just stay active
    }
    public void OnExitState(ObjectBehaviour obj)
	{
		//Deactivate all gizmos
		transformGizmo.SetActive(false);
		rotationGizmo.SetActive(false);
		gridState = false;

		renderer.material.color = Color.white;
		collider.enabled = true;

		Debug.Log("Exiting Active State!");
	}
}
