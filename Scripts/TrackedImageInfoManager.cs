using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackedImageInfoManager : MonoBehaviour
{
    ARTrackedImageManager trackedImageManager;
    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    private void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(var trackedImage in args.added)
        {
            //trackedImage.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

}
