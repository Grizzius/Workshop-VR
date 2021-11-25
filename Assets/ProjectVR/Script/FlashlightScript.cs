using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    [SerializeField] bool lightEnabled;
    [SerializeField] Light spotLight;

    private void Start()
    {
        spotLight.enabled = lightEnabled;
    }
    public void ToggleEnabled()
    {
        lightEnabled = !lightEnabled;
        spotLight.enabled = lightEnabled;
    }
}
