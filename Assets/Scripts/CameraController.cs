using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Camera cam;
	public float rotationSpeed = 1000f; // Speed of the rotation
	public GameObject cameraRotator;
	public GameObject rotationIcon;
	private bool perspective = true;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1)) // Front View
		{
			cam.transform.position = new Vector3(0f, 1.75f, -10f);
			cam.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			perspective = false;
			cameraRotator.SetActive(false);
			rotationIcon.SetActive(false);
		}

		if (Input.GetKeyDown(KeyCode.Alpha2)) // Top View
		{
			cam.transform.position = new Vector3(0f, 10f, 0f);
			cam.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
			perspective = false;
			cameraRotator.SetActive(false);
			rotationIcon.SetActive(false);
		}

		if (Input.GetKeyDown(KeyCode.Alpha3)) // Perspective View
		{
			cam.transform.position = new Vector3(0f, 6.25f, -10f);
			cam.transform.rotation = Quaternion.Euler(30f, 0f, 0f);
			perspective = true;
			cameraRotator.SetActive(true);
			cameraRotator.transform.position = new Vector3(0f, 3.5f, -7.65f);
			cameraRotator.transform.rotation = Quaternion.Euler(60f, 0f, 0f);
			rotationIcon.SetActive(true);
		}
	}
}
