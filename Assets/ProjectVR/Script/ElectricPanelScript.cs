using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPanelScript : MonoBehaviour
{
    [SerializeField] DialInteractable Lever;
    [SerializeField] GameObject redLight;
    [SerializeField] GameObject Spotlights;
    bool fuseSlot1Filled = false;
    bool fuseSlot2Filled = false;
    bool fuseSlot3Filled = false;
    public bool electricityRestored;

    private void Start()
    {
        updateLights(false);
    }
    public void SetFuseSlot1Filled(bool isActive)
    {
        fuseSlot1Filled = isActive;
        CheckCurrentRestored();
    }
    public void SetFuseSlot2Filled(bool isActive)
    {
        fuseSlot2Filled = isActive;
        CheckCurrentRestored();
    }
    public void SetFuseSlot3Filled(bool isActive)
    {
        fuseSlot3Filled = isActive;
        CheckCurrentRestored();
    }

    public void CheckCurrentRestored()
    {
        if (fuseSlot1Filled && fuseSlot2Filled && fuseSlot3Filled && Lever.CurrentAngle == Lever.RotationAngleMaximum)
        {
            updateLights(true);
            electricityRestored = true;
        }
        else
        {
            updateLights(false);
            electricityRestored = false;
        }
    }

    private void updateLights(bool isElectricityRestored)
    {

        redLight.SetActive(!isElectricityRestored);
        Spotlights.SetActive(isElectricityRestored);
    }
}
