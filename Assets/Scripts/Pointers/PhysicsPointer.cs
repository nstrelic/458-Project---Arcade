using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPointer : MonoBehaviour
{
    public float defaultLength = 3.0f;

    private LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLength();   
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }

    private Vector3 CalculateEnd()
    {
        //create a new raycast from controller
        RaycastHit hit = CreateForwardRaycast();

        //The default end position if nothing is hit
        Vector3 endPosition = DefaultEnd(defaultLength);

        //if something is hit, set that as the new end position
        if (hit.collider)
            endPosition = hit.point;

        return endPosition;
    }

    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;
        //create new ray from hand position
        Ray ray = new Ray(transform.position, transform.forward);

        //store data from raycast into hit
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }

    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }
}
