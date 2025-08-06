using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnSpeed = 0.2f;
    [SerializeField] private byte _spawnRadius = 5;

    [SerializeField] private ObjectPooler _objectPooler;

    public void SpawnEnemy()
    {
        Vector3 spawnPosition = RandomPosition();

        // Use the object pooler to get an instance of the prefab
        GameObject enemy = _objectPooler.GetGameObjectFromPool(BallType.Normal);
        enemy.transform.position = spawnPosition;
    }
    Vector3 RandomPosition()
    {
        return new Vector3(
            Random.Range(-(_spawnPoint.position.x + _spawnRadius), (_spawnPoint.position.x + _spawnRadius)),
            _spawnPoint.position.y,
            _spawnPoint.position.z
        );
    }
    public void StopSpawning()
    {
        CancelInvoke("SpawnEnemy");
    }
    public void OnGameRestart()
    {
        InvokeRepeating("SpawnEnemy", 0f, _spawnSpeed);
    }


}
