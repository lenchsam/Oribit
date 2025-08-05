using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private Transform _orbitingTarget;
    [SerializeField] private float _orbitSpeed = 5f;

    void Update()
    {
        transform.RotateAround(_orbitingTarget.transform.position, Vector3.forward, _orbitSpeed * Time.deltaTime);
    }

    public void ChangeOrbitDirection()
    {
        //putting the orbit speed to negative value will reverse the orbit direction
        _orbitSpeed = -_orbitSpeed;
    }
}
