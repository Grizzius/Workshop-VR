using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScript : MonoBehaviour
{
    [SerializeField] GameObject otherEndWire;
    [SerializeField] LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, otherEndWire.transform.position);
    }
}
