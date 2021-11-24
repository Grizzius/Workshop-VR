using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwapScript : MonoBehaviour
{
    [SerializeField] GameObject DefaultMenu;
    GameObject activeMenu;
    private void Start()
    {
        activeMenu = DefaultMenu;
        activeMenu.SetActive(true);
    }

    public void SwapOption(GameObject newActiveMenu)
    {
        activeMenu.SetActive(false);
        activeMenu = newActiveMenu;
        activeMenu.SetActive(true);
        Debug.Log(activeMenu.activeSelf);
    }
}
