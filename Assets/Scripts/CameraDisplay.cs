using UnityEngine;
using UnityEngine.UI;

public class CameraDisplay : MonoBehaviour
{
    public RawImage rawImage; // UI component to display the camera feed
    private WebCamTexture webCamTexture;

    void Start()
    {
        // Check if the device has any camera available
        if (WebCamTexture.devices.Length > 0)
        {
            // Get the default camera
            WebCamDevice cameraDevice = WebCamTexture.devices[0];

            // Create a new WebCamTexture using the camera name
            webCamTexture = new WebCamTexture(cameraDevice.name);

            // Assign the WebCamTexture to the RawImage
            rawImage.texture = webCamTexture;

            // Start the camera feed
            webCamTexture.Play();
        }
        else
        {
            Debug.LogError("No camera found on this device.");
        }
    }

    void OnDisable()
    {
        // Stop the camera feed when the object is disabled
        if (webCamTexture != null)
        {
            webCamTexture.Stop();
        }
    }
}
