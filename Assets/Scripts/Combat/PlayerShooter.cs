using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    
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
        
        if (_inputReader.IsShoot)
        {
            Fire();
        }
    }
    
    public void SetBulletPool(BulletPool pool)
    {
        _bulletPool = pool;
    }

    private void Fire()
    {
        Bullet bullet = _bulletPool.Get(_firePoint.position, Quaternion.identity);bullet.Init(transform.right, true);
        bullet.Init(transform.right, true);
        bullet.transform.right = transform.right;
    }
}