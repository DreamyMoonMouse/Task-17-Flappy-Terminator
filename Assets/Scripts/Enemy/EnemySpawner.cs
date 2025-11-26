using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private float _minY = -2f;
    [SerializeField] private float _maxY = 2f;

    protected override void Spawn()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(_minY, _maxY), 0f);
        Enemy enemy = _pool.Get(spawnPosition, Quaternion.identity);
        
        if (_pool is EnemyPool enemyPool)
        {
            enemy.Init(enemyPool);
        }
        
        var shooter = enemy.GetComponent<EnemyShooter>();
        
        if (shooter != null)
        {
            shooter.SetBulletPool(_bulletPool);
        }
    }
}