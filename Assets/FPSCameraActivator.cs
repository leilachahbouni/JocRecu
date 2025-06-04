using UnityEngine;

public class FPSCameraActivator : MonoBehaviour
{
    public Camera fpsCamera;

    void Start()
    {
        if (fpsCamera != null)
        {
            fpsCamera.enabled = true;
            Debug.Log("✅ Cámara en primera persona activada.");
        }
        else
        {
            Debug.LogWarning("⚠️ No se asignó una cámara FPS.");
        }
    }
}
