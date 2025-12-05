using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour, IInteractable, IPoolable<Bullet>
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _lifeTime = 6f;
    [SerializeField] private LayerMask _targetLayers = -1;

    private Vector2 _direction;
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
    
    public void Init(Vector2 direction)
    {
        _direction = direction.normalized;
        _rigidbody.linearVelocity = _direction * _speed;
        _timer = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & _targetLayers) != 0)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.Die();
                Deactivate();
            }
        }
    }
    
    private void Deactivate()
    {
        Deactivated?.Invoke(this);
    }
}
