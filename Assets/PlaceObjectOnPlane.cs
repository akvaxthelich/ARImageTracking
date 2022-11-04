using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectOnPlane : MonoBehaviour
{
    public GameObject boxMonster;
    public GameObject marker;

    PlaneMessenger pm;

    void Start()
    {
        pm = FindObjectOfType<PlaneMessenger>();
        pm.OnPlaneFound += UpdateObject;
        pm.OnPlaneNotFound += RemoveObject;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Instantiate(boxMonster, marker.transform.position, marker.transform.rotation);
            }
        }
    }

    void UpdateObject(PlaneMessenger.PlaneData plane)
    {
        marker.SetActive(true);
        marker.transform.SetPositionAndRotation(plane.pos, plane.rot);
    }

    void RemoveObject()
    {
        marker.SetActive(false);
    }

    private void OnDestroy()
    {
        pm.OnPlaneFound -= UpdateObject;
        pm.OnPlaneNotFound -= RemoveObject;
    }

}