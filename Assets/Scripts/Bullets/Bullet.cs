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
            gameObject.SetActive(false);
    }
    
    public void Init(Vector2 direction, bool isPlayerBullet)
    {
        _direction = direction.normalized;
        _isPlayerBullet = isPlayerBullet;
        _rb.linearVelocity = _direction * _speed;
        _timer = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isPlayerBullet)
        {
            if (other.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.Die();
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (other.TryGetComponent<Plane>(out var plane))
            {
                plane.Kill();
                gameObject.SetActive(false);
            }
        }
    }
}
