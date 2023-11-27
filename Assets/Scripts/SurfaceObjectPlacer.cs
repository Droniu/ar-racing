using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SurfaceObjectPlacer : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject carPrefab;
    public GameObject trackPrefab;
    private GameObject placedCar;
    private GameObject placedTrack;
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

                    Vector3 carPosition = new Vector3(hitPose.position.x, hitPose.position.y + 0.02f, hitPose.position.z); // dostosuj wysokość Y
                    if (placedCar == null)
                    {
                        placedCar = Instantiate(carPrefab, carPosition, hitPose.rotation);
                    }

                    if (placedTrack == null)
                    {
                        placedTrack = Instantiate(trackPrefab, hitPose.position, hitPose.rotation);
                    }
                }
            }
        }
    }
}
