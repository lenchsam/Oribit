using UnityEngine;
using UnityEngine.Events;

public class Orbit : MonoBehaviour
{
    [SerializeField] private Transform _orbitingTarget;
    [SerializeField] private float _orbitSpeed = 5f;

    public UnityEvent OnDeath = new UnityEvent();

    void Update()
    {
        transform.RotateAround(_orbitingTarget.transform.position, Vector3.forward, _orbitSpeed * Time.deltaTime);
    }
    private void OnDisable()
    {
        Debug.Log($"{gameObject.name} has been destroyed.");
        OnDeath.Invoke();
    }

    public void ChangeOrbitDirection()
    {
        //putting the orbit speed to negative value will reverse the orbit direction
        _orbitSpeed = -_orbitSpeed;
    }
}
