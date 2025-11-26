using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private bool _isPlayer = true;

    private float _timer;
    private BulletPool _bulletPool;
    private InputReader _inputReader;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }
    
    private void Update()
    {
        if (_bulletPool == null) 
            return;
        
        if (_isPlayer)
        {
            if (_inputReader.IsShoot)
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
    
    public void SetBulletPool(BulletPool pool)
    {
        _bulletPool = pool;
    }

    private void FirePlayer()
    {
        Bullet bullet = _bulletPool.Get(_firePoint.position, Quaternion.identity);
        bullet.Init(transform.right, true);
        bullet.transform.right = transform.right;
    }

    private void FireEnemy()
    {
        Bullet bullet = _bulletPool.Get(_firePoint.position, Quaternion.identity);
        bullet.Init(Vector2.left, false);
        bullet.transform.right = Vector2.left;
    }
}

