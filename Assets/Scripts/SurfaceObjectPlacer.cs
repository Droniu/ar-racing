using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SurfaceObjectPlacer : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public GameObject objectToPlace;
    private GameObject lastInstantiatedObject;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

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

                    if (lastInstantiatedObject != null)
                    {
                        Destroy(lastInstantiatedObject);
                    }

                    lastInstantiatedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                    lastInstantiatedObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Dostosuj skalę według potrzeb
                }
            }
        }
    }
}
