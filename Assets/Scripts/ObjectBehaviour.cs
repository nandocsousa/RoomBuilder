using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
	private IObjectState currentState;

	public new Renderer renderer;

	private void Start()
	{
		SetState(new InactiveState());
	}

	public void Update()
	{
		currentState.OnUpdateState(this);
	}

	public void SetState(IObjectState state)
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
			SetState(new ActiveState());

		if (Input.GetMouseButton(1))
			DestroyObject();
	}
	public void DestroyObject()
	{
		Destroy(gameObject);
	}
}
