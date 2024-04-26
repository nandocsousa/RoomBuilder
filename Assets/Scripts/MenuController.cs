using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject[] gameobjectArray;
    public GameObject[] closeAllMenus;

    public void ShowThisMenu(int menuIndex)
    {
        for (int i = 0; i < gameobjectArray.Length; i++)
        {
            gameobjectArray[i].SetActive(false); // Deactive all other menus
        }

        gameobjectArray[menuIndex - 1].SetActive(true); // Activate specified menu
    }
    public void CloseAllMenus()
    {
        for (int i = 0; i < closeAllMenus.Length; i++)
        {
            closeAllMenus[i].SetActive(false); // Deactive all other menus
        }
    }

    public void HideObject(GameObject menu)
    {
        menu.SetActive(false);
    }
    public void ShowObject(GameObject menu)
    {
        menu.SetActive(true);
    }
}
