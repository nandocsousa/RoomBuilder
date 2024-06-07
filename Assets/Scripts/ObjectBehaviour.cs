using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
	private IObjectState currentState;

	private ObjectManager manager;

	public new Renderer renderer;

	private void Start()
	{
		manager = GameObject.FindWithTag("Object Manager").GetComponent<ObjectManager>();

        SetState(new InactiveState());
	}

	public void Update()
	{
		currentState.OnUpdateState(this);
    }

	public void SetState(IObjectState state	)
	{
		if (currentState != null)
		{
			currentState.OnExitState(this);
		}

		currentState = state;

		if (state != null)
		{
			currentState.OnEnterState(this);
		}
	}

	void OnMouseDown()
	{
		if (Input.GetMouseButton(0))
		{
			SetState(new ActiveState());
            manager.UpdateObject(this.gameObject);
		}
    }
	public void DestroyObject()
	{
		Destroy(this.gameObject);
	}
}
