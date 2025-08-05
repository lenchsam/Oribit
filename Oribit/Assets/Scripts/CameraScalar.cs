using UnityEngine;

[ExecuteInEditMode]
public class CameraScalar : MonoBehaviour
{
    [SerializeField] private float _targetWidth = 5f;

    [SerializeField] private float _targetAspect = 0.5625f;

    private Camera _camera;

    void Awake()
    {
        _camera = GetComponent<Camera>();
        UpdateOrthographicSize();
    }

    public void UpdateOrthographicSize()
    {
        float currentAspect = (float)Screen.width / Screen.height;

        float targetHeight = _targetWidth / _targetAspect;
        float heightBasedSize = targetHeight / 2f;

        if (currentAspect >= _targetAspect)
        {
            // we are limited by height
            _camera.orthographicSize = heightBasedSize;
        }
        else
        {
            // limited by width
            _camera.orthographicSize = (_targetWidth / currentAspect) / 2f;
        }
    }
}
