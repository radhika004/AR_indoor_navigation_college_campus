using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using ZXing;

public class GetImageAlternative : MonoBehaviour
{
    [SerializeField]
    private ARCameraBackground arCameraBackground;

    [SerializeField]
    private RenderTexture targetRenderTexture;

    [SerializeField]
    private TextMeshProUGUI qrCodeText;

    private Texture2D cameraImageTexture;
    private BarcodeReader reader = new BarcodeReader(); // Create a barcode reader instance

    private void Update()
    {
        // Render the AR camera background to the target render texture
        Graphics.Blit(null, targetRenderTexture, arCameraBackground.material);

        // Create a Texture2D to hold the image data from the render texture
        cameraImageTexture = new Texture2D(targetRenderTexture.width, targetRenderTexture.height, TextureFormat.RGBA32, false);

        // Copy the render texture data to the Texture2D
        Graphics.CopyTexture(targetRenderTexture, cameraImageTexture);

        // Detect and decode the barcode inside the bitmap
        var result = reader.Decode(cameraImageTexture.GetPixels32(), cameraImageTexture.width, cameraImageTexture.height);

        // Do something with the result
        if (result != null)
        {
            qrCodeText.text = result.Text;
        }
    }
}