using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private byte _spawnSpeed = 10;
    [SerializeField] private byte _spawnRadius = 5;
    
    public void SpawnEnemy()
    {
        Vector3 spawnPosition = RandomPosition();
        Instantiate(_prefabToSpawn, spawnPosition, Quaternion.identity);
    }
    Vector3 RandomPosition()
    {
        return new Vector3(
            Random.Range(-(_spawnPoint.position.x + _spawnRadius), (_spawnPoint.position.x + _spawnRadius)),
            _spawnPoint.position.y,
            _spawnPoint.position.z
        );
    }
}
