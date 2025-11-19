using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private bool _isPlayer = true;

    private float _timer;
    private ObjectPool _bulletPool;

    private void Update()
    {
        if (_bulletPool == null) return;
        
        if (_isPlayer)
        {
            if (Input.GetMouseButtonDown(0))
                FirePlayer();
        }
        else
        {
            _timer += Time.deltaTime;
            
            if (_timer >= _fireRate)
            {
                FireEnemy();
                _timer = 0f;
            }
        }
    }
    
    public void SetBulletPool(ObjectPool pool)
    {
        _bulletPool = pool;
    }

    private void FirePlayer()
    {
        var bulletObj = _bulletPool.Get(_firePoint.position, Quaternion.identity);
        var bullet = bulletObj.GetComponent<Bullet>();
        bullet.Init(transform.right, true);
        bulletObj.transform.right = transform.right;
    }

    private void FireEnemy()
    {
        var bulletObj = _bulletPool.Get(_firePoint.position, Quaternion.identity);
        var bullet = bulletObj.GetComponent<Bullet>();
        bullet.Init(Vector2.left, false);
        bulletObj.transform.right = Vector2.left;
    }
}

