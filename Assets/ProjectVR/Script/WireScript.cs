using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScript : MonoBehaviour
{
    [SerializeField] WireScript otherEndWire;
    [SerializeField] LineRenderer lineRenderer;
    public GameObject connectionPoint;
    int transferValue;
    SocketTarget socketTarget;

    private void Start()
    {
        socketTarget = GetComponent<SocketTarget>();
    }
    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, otherEndWire.transform.position);
    }

    public void IsConnected(GameObject connectionPoint)
    {
        
        if (connectionPoint.GetComponent<LockerInputScript>() != null)
        {
            isConnectedToInput(connectionPoint);
        }
        else if (connectionPoint.GetComponent<LockerOutputScript>() != null)
        {
            isConnectedToOutput(connectionPoint);
        }
    }

    public void isConnectedToInput(GameObject InputconnectionPoint)
    {
        LockerInputScript connectionInput = InputconnectionPoint.GetComponent<LockerInputScript>();
        otherEndWire.transferValue = connectionInput.lockingValue;
        otherEndWire.isConnectedToOutput(otherEndWire.connectionPoint);
    }

    public void isConnectedToOutput(GameObject OutputconnectionPoint)
    {
        LockerOutputScript connectionOutput = OutputconnectionPoint.GetComponent<LockerOutputScript>();
        connectionOutput.lockValue = transferValue;
    }
}
