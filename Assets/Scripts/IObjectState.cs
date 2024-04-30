using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectState
{
	void OnEnterState(ObjectBehaviour obj);
	void OnUpdateState(ObjectBehaviour obj);
	void OnExitState(ObjectBehaviour obj);
}
