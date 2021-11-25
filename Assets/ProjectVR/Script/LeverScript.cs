using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    [SerializeField] XROffsetGrabbable grabbableScript;
    [SerializeField] DialInteractable dialScript;

    public void enableLever()
    {
        grabbableScript.enabled = false;
        dialScript.enabled = true;
    }
}
