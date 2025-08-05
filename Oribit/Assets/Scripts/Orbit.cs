using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Orbit : MonoBehaviour
{
    [SerializeField] private Transform _orbitingTarget;
    [SerializeField] private float _orbitSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(_orbitingTarget.transform.position, Vector3.forward, _orbitSpeed * Time.deltaTime);
    }
}
