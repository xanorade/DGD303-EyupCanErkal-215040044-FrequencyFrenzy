using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CRT : MonoBehaviour {
    public Shader crtShader;

    [Range(1.0f, 10.0f)]
    public float curvature = 1.0f;

    [Range(1.0f, 100.0f)]
    public float vignetteWidth = 30.0f;

    private Material _crtMat;
    private Camera _camera;
    private Camera _camera1;
    private Camera _camera2;

    private void Awake()
    {
        _camera2 = GetComponent<Camera>();
        _camera1 = GetComponent<Camera>();
        _camera = GetComponent<Camera>();
    }

    void Start() {
        _crtMat ??= new Material(crtShader);
        _crtMat.hideFlags = HideFlags.HideAndDontSave;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        _crtMat.SetFloat("_Curvature", curvature);
        _crtMat.SetFloat("_VignetteWidth", vignetteWidth);
        Graphics.Blit(source, destination, _crtMat);
    }

    private void LateUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            RenderTexture rt = new RenderTexture(1920, 1080, 24);
            _camera.targetTexture = rt;
            Texture2D screenshot = new Texture2D(1920, 1080, TextureFormat.RGB24, false);
            _camera1.Render();
            RenderTexture.active = rt;
            screenshot.ReadPixels(new Rect(0, 0, 1920, 1080), 0, 0);
            _camera2.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);
        }
    }
}