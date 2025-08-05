using UnityEngine;

public class BaseBall : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _speedRandomness = 2f;
    private void Awake()
    {
        //randomize speed of the ball
        _speed += Random.Range(-_speedRandomness, _speedRandomness);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        //move the enemy ball downwards
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
