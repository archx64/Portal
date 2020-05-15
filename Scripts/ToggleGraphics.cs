using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ToggleGraphics : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public ARPointCloudManager pointCloudManager;

    public void ChangeValues(bool value)
    {
        VisualizePlanes(value);
        VisualizePointClouds(value);
    }

    private void VisualizePlanes(bool active)
    {
        planeManager.enabled = true;
        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(active);
        }
    }
    private void VisualizePointClouds(bool active)
    {
        pointCloudManager.enabled = true;
        foreach (ARPointCloud point in pointCloudManager.trackables)
        {
            point.gameObject.SetActive(active);
        }
    }
}
