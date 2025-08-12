using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [Space(10)]
    [SerializeField] private float _smoothTime = 0.3f;
    private Vector3 _velocity = Vector3.zero;

    private bool isMoving = false;

    public void MoveCameraTo(Transform target)
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveCameraCoroutine(target));
        }
    }
    private IEnumerator MoveCameraCoroutine(Transform target)
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime, Mathf.Infinity, Time.unscaledDeltaTime);

            yield return null;
        }
        transform.position = targetPosition;

        isMoving = false;
    }
}
