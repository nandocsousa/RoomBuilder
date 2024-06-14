using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveLoad : MonoBehaviour
{
    private void Start()
    {
        SaveSystem.Init();
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
        GameObject[] storedObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);


        foreach (GameObject obj in storedObjects)
        {
            // Create a SaveObject for each GameObject, storing its reference, position and rotation
            SaveObject saveObject = new SaveObject
            {
                obj = obj,
                objPosition = obj.transform.position,
                objRotation = obj.transform.rotation
            };

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
            List<SaveObject> saveObjectsList = JsonUtility.FromJson<List<SaveObject>>(jsonLoad); // Deserialize the JSON string back into a list of SaveObjects

            foreach (SaveObject saveObject in saveObjectsList)
            {
                // Retrieves the GameObject associated with the SaveObject and sets the position and rotation of the GameObject to match the saved values
                GameObject loadObject = saveObject.obj;
                loadObject.transform.position = saveObject.objPosition;
                loadObject.transform.rotation = saveObject.objRotation;

                Debug.Log("Loaded!");
            }
                
        }
        else Debug.Log("Not Loaded!");
    }

    private class SaveObject // Represents the data structure for saving and loading GameObjects
    {
        public GameObject obj;
        public Vector3 objPosition;
        public Quaternion objRotation;
    }
}