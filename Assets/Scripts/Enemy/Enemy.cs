using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour, IInteractable, IDamageable
{
    [SerializeField] private float _lifeTime = 5f;
    
    private float _timer;
    private EnemyPool _pool;
    
    private void OnEnable()
    {
        _timer = 0f;
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _lifeTime)
            Die();
    }
    
    public void Init(EnemyPool pool)
    {
        _pool = pool;
    }
    
    public void Die()
    {
        _pool.Return(this);
    }
}