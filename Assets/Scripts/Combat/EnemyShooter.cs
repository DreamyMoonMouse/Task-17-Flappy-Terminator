using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform _fireSpawnPoint;
    [SerializeField] private float _fireRate = 1f;
    
    private float _timer;
    private BulletPool _bulletPool;

    private void Update()
    {
        if (_bulletPool == null) 
            return;
        
        _timer += Time.deltaTime;
        
        if (_timer >= _fireRate)
        {
            Fire();
            _timer = 0f;
        }
    }
    
    public void SetBulletPool(BulletPool pool)
    {
        _bulletPool = pool;
    }

    private void Fire()
    {
        Bullet bullet = _bulletPool.Get(_fireSpawnPoint.position, Quaternion.identity);
        bullet.Init(Vector2.left);
        bullet.gameObject.layer = LayerMask.NameToLayer("EnemyBullet");
    }
}