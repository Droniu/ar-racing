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
        // Sprawdź, czy użytkownik dotknął ekranu
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Wykonaj raycast, gdy użytkownik dotknie ekranu
            if (touch.phase == TouchPhase.Began)
            {
                if (raycastManager.Raycast(touch.position, raycastHits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = raycastHits[0].pose;

                    // Jeśli jeszcze nie umieszczono obiektu, umieść go. W przeciwnym razie przesuń istniejący obiekt.
                    if (placedObject == null)
                    {
                        placedObject = Instantiate(objectToPlacePrefab, hitPose.position, hitPose.rotation);
                    }
                    else
                    {
                        
                        //placedObject.transform.position = hitPose.position;
                        //placedObject.transform.rotation = hitPose.rotation;
                    }
                }
            }
        }
    }
}

