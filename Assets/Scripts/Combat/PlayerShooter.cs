using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform _fireSpawnPoint;
    
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
        Bullet bullet = _bulletPool.Get(_fireSpawnPoint.position, Quaternion.identity);
        bullet.Init(transform.right);
        bullet.gameObject.layer = LayerMask.NameToLayer("PlayerBullet");
    }
}