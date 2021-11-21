using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptionMenuScript : MonoBehaviour
{

    GameObject optionMenu;
    public GameObject DefaultMenu;
    private void OnEnable()
    {
        SwapOption(DefaultMenu);
    }
    public void SwapOption(GameObject NewOptionMenu)
    {
        Destroy(optionMenu);
        var newOptionMenu = Instantiate(NewOptionMenu, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        newOptionMenu.transform.parent = gameObject.transform;
        newOptionMenu.transform.localScale = new Vector3(1, 1, 1);
        optionMenu = newOptionMenu;
    }
}
