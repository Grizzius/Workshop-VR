using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDiodeScript : MonoBehaviour
{
    [SerializeField] Material LockedMaterial;
    [SerializeField] Material MidMaterial;
    [SerializeField] Material UnlockMaterial;
    [SerializeField] LockerScript locker;
    [SerializeField] LockerOutputScript[] assignedOutputs;
    int unlockedValue;
    public bool unlock;

    private void Start()
    {
        CountUnlockedValue();
    }

    public void CountUnlockedValue()
    {
        unlockedValue = 0;
        foreach (LockerOutputScript assignedOutput in assignedOutputs)
        {
            unlockedValue += assignedOutput.lockValue;
        }
        SwapColor(Mathf.Clamp(unlockedValue, -1, 1));
    }

    public void SwapColor(int state)
    {
        switch (state)
        {
            case -1:
                GetComponent<Renderer>().material = LockedMaterial;
                unlock = false;
                break;
            case 0:
                GetComponent<Renderer>().material = MidMaterial;
                unlock = false;
                break;
            case 1:
                GetComponent<Renderer>().material = UnlockMaterial;
                unlock = true;
                locker.TestIfUnlocked();
                break;

        }
    }
}
