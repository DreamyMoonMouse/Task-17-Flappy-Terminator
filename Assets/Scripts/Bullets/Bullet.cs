using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour, IInteractable, IPoolable<Bullet>
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _lifeTime = 6f;

    private Vector2 _direction;
    private bool _isPlayerBullet;
    private Rigidbody2D _rigidbody;
    private float _timer;
    
    public event Action<Bullet> Deactivated;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0f;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        _rigidbody.freezeRotation = true;
    }
    
    private void OnEnable()
    {
        _timer = 0f;
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _lifeTime)
            Deactivate();
    }
    
    public void Init(Vector2 direction, bool isPlayerBullet)
    {
        _direction = direction.normalized;
        _rigidbody.linearVelocity = _direction * _speed;
        _timer = 0f;
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
            Deactivate();
        }
    }
    
    private void Deactivate()
    {
        Deactivated?.Invoke(this);
    }
}
