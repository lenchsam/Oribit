using UnityEngine;

public class BaseBall : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _speedRandomness = 2f;

    [SerializeField] ObjectPooler _objectPooler;
    private void Awake()
    {
        //randomize speed of the ball
        _speed += Random.Range(-_speedRandomness, _speedRandomness);

        //get the object pooler from the scene
        _objectPooler = FindAnyObjectByType<ObjectPooler>();
    }

    void OnBecameInvisible()
    {
        //return the ball to the object pooler when it goes off screen
        _objectPooler.ReturnGameObjectToPool(gameObject);
    }

    private void Update()
    {
        //move the enemy ball downwards
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
