using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasPointer : MonoBehaviour
{
    public float defaultLength = 3.0f;

    public EventSystem eventSystem = null;
    public StandaloneInputModule inputModule = null;

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
        lineRenderer.SetPosition(1, GetEnd());
    }
    private Vector3 GetEnd()
    {
        float distance = GetCanvasDistance();
        Vector3 endPos = CalculateEnd(defaultLength);

        if (distance != 0)
            endPos = CalculateEnd(distance);

        return endPos;
    }

    private float GetCanvasDistance()
    {
        // Get the data
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.position = inputModule.inputOverride.mousePosition;

        //Raycast with the data
        List<RaycastResult> results = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, results);

        //Get closet object
        RaycastResult closest = FindFirstRaycast(results);
        float distance = closest.distance;

        return Mathf.Clamp(distance, 0.0f, defaultLength);
    }

    private RaycastResult FindFirstRaycast(List<RaycastResult> results)
    {
        //Go through each raycast result
        foreach(RaycastResult result in results)
        {
            if (!result.gameObject)
                continue;

            //return first raycast with a gameobject
            return result;
        }

        return new RaycastResult();
    }

    private Vector3 CalculateEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }

}
