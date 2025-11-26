using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private float _spawnRate = 1f;
    [SerializeField] private float _minY = -2f;
    [SerializeField] private float _maxY = 2f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _spawnRate)
        {
            Spawn();
            _timer = 0f;
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(_minY, _maxY), 0f);
        Enemy enemy = _enemyPool.Get(spawnPosition, Quaternion.identity);
        var shooter = enemy.GetComponent<Shoot>();
        
        if (shooter != null)
        {
            shooter.SetBulletPool(_bulletPool);
        }
    }
}