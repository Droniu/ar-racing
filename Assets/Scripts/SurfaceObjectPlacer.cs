using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SurfaceObjectPlacer : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject objectToPlacePrefab;
    private GameObject placedObject;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (raycastManager.Raycast(touch.position, raycastHits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = raycastHits[0].pose;

                    if (placedObject == null)
                    {
                        placedObject = Instantiate(objectToPlacePrefab, hitPose.position, hitPose.rotation);
                    }
                }
            }
        }
    }
}

