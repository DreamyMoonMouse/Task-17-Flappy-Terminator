using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _lifeTime = 6f;

    private Vector2 _direction;
    private bool _isPlayerBullet;
    private Rigidbody2D _rb;
    private float _timer;
    private BulletPool _pool;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f;
        _rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        _rb.freezeRotation = true;
    }
    
    private void OnEnable()
    {
        _timer = 0f;
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _lifeTime)
            ReturnToPool();
    }
    
    public void Init(Vector2 direction, bool isPlayerBullet, BulletPool pool)
    {
        _direction = direction.normalized;
        _rb.linearVelocity = _direction * _speed;
        _timer = 0f;
        _pool = pool;
        _isPlayerBullet = isPlayerBullet;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            if (_isPlayerBullet && other.GetComponent<Plane>() != null)
                return;
            
            if (!_isPlayerBullet && other.GetComponent<Enemy>() != null)
                return;
            
            damageable.Die();
            ReturnToPool();
        }
    }
    
    private void ReturnToPool()
    {
        if (_pool != null)
        {
            _pool.Return(this);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
