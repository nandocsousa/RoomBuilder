using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    SaveObject saveObject;
	private int gObjQuantity;

    public GameObject[] storedObjects;

	private void Start()
    {
        SaveSystem.Init();
		saveObject = new SaveObject();
	}

	private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            Save();

        if (Input.GetKeyDown(KeyCode.L))
            Load();
    }

    private void Save()
    {
        List<SaveObject> saveObjectsList = new List<SaveObject>(); // Create a list to store the objects to be saved

        // Store all GameObjects in the scene in an array
        storedObjects = GameObject.FindGameObjectsWithTag("prefab");

        foreach (GameObject gObj in storedObjects)
        {
            gObjQuantity++;
		}

        for (int i = 0; i < storedObjects.Length; i++)
        {
			Debug.Log(" " + storedObjects[i].transform.gameObject.name);
		}

        for (int i = 0; i < gObjQuantity; i++)
        {
            saveObject.obj[i] = storedObjects[i];
			saveObject.objPosition[i] = storedObjects[i].transform.position;
			saveObject.objRotation[i] = storedObjects[i].transform.rotation;

			saveObjectsList.Add(saveObject); // Add the SaveObject to the list
		}

        string jsonSave = JsonUtility.ToJson(saveObjectsList); // Convert the list of SaveObjects to a JSON string

        SaveSystem.Save(jsonSave);

        Debug.Log("Saved!");
        Debug.Log(jsonSave);
    }

    private void Load()
    {
        string jsonLoad = SaveSystem.Load(); // Retrieve the saved JSON string

        if (jsonLoad != null)
        {
			// Deserialize the JSON string back into a list of SaveObjects
			List<SaveObject> saveObjectsList = JsonUtility.FromJson<List<SaveObject>>(jsonLoad); 

			for (int i = 0; i < gObjQuantity; i++)
			{
				GameObject loadObject = saveObject.obj[i].transform.gameObject;

				loadObject.transform.position = new Vector3(saveObject.objPosition[i].x, saveObject.objPosition[i].y, saveObject.objPosition[i].z);
				loadObject.transform.rotation = new Quaternion(saveObject.objRotation[i].x, saveObject.objRotation[i].y, saveObject.objRotation[i].z, 0);

				saveObjectsList.Add(saveObject); // Add the SaveObject to the list
			}

		}
        else Debug.Log("Not Loaded!");
    }

    public class SaveObject // Represents the data structure for saving and loading GameObjects
    {
        public GameObject[] obj;
        public Vector3[] objPosition;
        public Quaternion[] objRotation;
    }
}