using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.Events;


public class PlaneMessenger : MonoBehaviour
{
    public class PlaneData
    {
        public Vector3 pos;
        public Quaternion rot;
    }

    public UnityAction<PlaneData> OnPlaneFound;
    public UnityAction OnPlaneNotFound;

    ARRaycastManager rm;
    Vector3 viewportCenter = new Vector3(0.5f, 0.5f, 0.0f);

    void Start()
    {
        rm = GetComponent<ARRaycastManager>();
    }


    void Update()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(viewportCenter);
        var hits = new List<ARRaycastHit>();

        rm.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
        if (hits.Count > 0)
        {
            var plane = new PlaneData();
            plane.pos = hits[0].pose.position;
            plane.rot = hits[0].pose.rotation;
            OnPlaneFound?.Invoke(plane);
        }
        else
        {
            OnPlaneNotFound?.Invoke();
        }
    }
}