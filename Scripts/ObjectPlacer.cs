using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject objectToInstantiate;

    private GameObject spawnedObject;

    private ARRaycastManager raycastManager;

    private Vector2 touchPosition;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    private bool GetTouchPosition(out Vector2 touchPosition)
    {

        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!GetTouchPosition(out touchPosition))
        {
            return;
        }

        if(raycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if(spawnedObject == null)
            {
                spawnedObject = Instantiate(objectToInstantiate, hitPose.position, hitPose.rotation);
            }

            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }

}
