using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _enemyPool;
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private float _spawnRate = 1f;
    [SerializeField] private float _minY = -2f;
    [SerializeField] private float _maxY = 2f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _spawnRate)
        {
            SpawnEnemy();
            _timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(_minY, _maxY), 0f);
        GameObject enemyObj = _enemyPool.Get(spawnPosition, Quaternion.identity);
        var shoot = enemyObj.GetComponent<Shoot>();
        
        if (shoot != null)
            shoot.SetBulletPool(_bulletPool);
    }
}

