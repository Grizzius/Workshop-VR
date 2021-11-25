using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerScript : MonoBehaviour
{
    [SerializeField] LockerDiodeScript[] diodeList;
    [SerializeField] GameObject door;
    int unlockedNumber;

    public void TestIfUnlocked()
    {
        Debug.Log("Start test if door unlocked");
        unlockedNumber = 0;
        foreach(LockerDiodeScript diode in diodeList)
        {
            Debug.Log("Testing locker...");
            if (!diode.unlock)
            {
                Debug.Log("locker is locked");
                break;
            }
            else
            {
                Debug.Log("locker is unlocked");
                unlockedNumber++;
            }
        }
        if (unlockedNumber == diodeList.Length)
        {
            Debug.Log("door oppened");
            door.SetActive(false);
        }
    }
}
