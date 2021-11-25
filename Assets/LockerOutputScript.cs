using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerOutputScript : MonoBehaviour
{
    public int lockValue;
    // Start is called before the first frame update
    void Start()
    {
        Mathf.Clamp(lockValue, -1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
