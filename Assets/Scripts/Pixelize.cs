using UnityEngine;

[RequireComponent(typeof (Camera))]
public class Pixelize : MonoBehaviour
{
    public int horizontalResolution = 640;
    public int verticalResolution = 480;
    public bool interpolated;

    public void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        horizontalResolution = Mathf.Clamp(horizontalResolution, 1, 2048);
        verticalResolution = Mathf.Clamp(verticalResolution, 1, 2048);

        var scaled = RenderTexture.GetTemporary(horizontalResolution, verticalResolution);

        if (interpolated)
        {
            scaled.filterMode = FilterMode.Bilinear;
        }
        else
        {
            scaled.filterMode = FilterMode.Point;
        }

        Graphics.Blit(src, scaled);
        Graphics.Blit(scaled, dest);
        RenderTexture.ReleaseTemporary(scaled);
    }
}
